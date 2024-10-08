﻿using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Camera_move : MonoBehaviour
{
    public static Camera_move instance;
    private InputAction TouchPressAction;
    private InputAction TouchPositionAction;

    private Coroutine draUpdateCoroutine;
    public Vector2 ClickPosition;
    public Vector2 EndPosition;
    public bool DebugMod = true;
    [SerializeField]
    private float minRotation = 0f; // Y轴最小旋转角度
    [SerializeField]
    private float maxRotation = 45f; // Y轴最大旋转角度
    [SerializeField]
    private float sensitivity = 0.015f; // 旋转灵敏度
    private PlayerInput pi;
    public bool Invert_X; 
    public bool Invert_Y;
    public bool enableAtStart;

    private void Start()
	{
        SetEnable(enableAtStart);

    }
	private void Awake()
    {
        pi = GetComponent<PlayerInput>();
        TouchPressAction = pi.actions.FindAction("TouchPress");
        TouchPositionAction = pi.actions.FindAction("TouchPosition");
        if (instance == null)
        {
            instance = this;

        }
    }


    private void OnEnable()
    {
        TouchPressAction.performed += TouchPress;
        TouchPressAction.canceled += TouchReleased;
    }

    private void OnDisable()
    {
        TouchPressAction.performed -= TouchPress;
        TouchPressAction.canceled -= TouchReleased;
    }

    private void TouchPress(InputAction.CallbackContext ctx)
    {
        // 记录按下时的鼠标位置
        ClickPosition = TouchPositionAction.ReadValue<Vector2>();
        if (DebugMod)
        {
            Debug.Log("ClickPosition = " + ClickPosition);
        }

		if (draUpdateCoroutine == null)
		{
			draUpdateCoroutine = StartCoroutine(DragUpdate());
		}
	}

    private void TouchReleased(InputAction.CallbackContext ctx)
    {
        if (draUpdateCoroutine != null)
        {
            StopCoroutine(draUpdateCoroutine);
            draUpdateCoroutine = null;
            if (DebugMod)
            {
                Debug.Log("EndPosition = " + EndPosition);
            }
        }
    }

    private float NormalizeAngle(float angle)
    {
        if (angle > 180)
        {
            angle -= 360;
        }
        return angle;
    }

    private IEnumerator DragUpdate()
    {
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = NormalizeAngle(currentRotation.x);  // 将 X 轴的旋转角度规范化
        currentRotation.y = NormalizeAngle(currentRotation.y);  // 将 Y 轴的旋转角度规范化

        int InvertX = 1;
        int InvertY = 1;

        if (Invert_X)
        {
            InvertX = InvertX * -1;
        }
        if (Invert_Y)
        {
            InvertY = InvertY * -1;
        }
        while (true)
        {
            // 持续更新 EndPosition
            EndPosition = TouchPositionAction.ReadValue<Vector2>();

            // 计算位置差值
            float deltaX = (EndPosition.x - ClickPosition.x) * InvertY * sensitivity;
            float deltaY = (EndPosition.y - ClickPosition.y) * InvertX * sensitivity;

            // 更新物体的旋转
            float newRotationY = NormalizeAngle(currentRotation.y + deltaX);
            float newRotationX = Mathf.Clamp(currentRotation.x + deltaY, minRotation, maxRotation);

			//if (DebugMod)
			//{
            //    Debug.Log(currentRotation.x + "+" + deltaY);
            //}
            

            // 应用旋转，使用 Quaternion.Euler
            transform.localRotation = Quaternion.Euler(newRotationX, newRotationY, 0f);

            // Yield execution of this coroutine and return to the main loop until next frame
            yield return null;
        }
    }


    public void SetLocalRotation(float RotaX, float RotaY, float RotaZ)
    {
        Quaternion quaternionRotation = Quaternion.Euler(new Vector3(RotaX, RotaY, RotaZ));
        transform.localRotation = quaternionRotation;
    }


    public void SetEnable(bool enabled)
    {
        if (enabled)
            pi.actions.Enable();
        else
            pi.actions.Disable();
    }
}
