using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Camera_move : MonoBehaviour
{
    [SerializeField]
    private InputAction mouseClick;
    [SerializeField]
    private InputAction mousePosition;

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
    private void OnEnable()
    {
        mouseClick.Enable();
        mousePosition.Enable();
        mouseClick.performed += MousePressed;
        mouseClick.canceled += MouseReleased;
    }

    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.canceled -= MouseReleased;
        mouseClick.Disable();
        mousePosition.Disable();
    }

    private void MousePressed(InputAction.CallbackContext ctx)
    {
        // 记录按下时的鼠标位置
        ClickPosition = mousePosition.ReadValue<Vector2>();
		if (DebugMod ==true)
		{
            //Debug.Log("ClickPosition = " + ClickPosition);
        }
        

        if (draUpdateCoroutine == null)
        {
            draUpdateCoroutine = StartCoroutine(DragUpdate());
        }
    }

    private void MouseReleased(InputAction.CallbackContext ctx)
    {
        if (draUpdateCoroutine != null)
        {
            StopCoroutine(draUpdateCoroutine);
            draUpdateCoroutine = null;
            if (DebugMod == true)
            {
                //Debug.Log("EndPosition = " + EndPosition);
            }
                
        }
    }

    private IEnumerator DragUpdate()
    {
        while (true)
        {
            // 持续更新 EndPosition
            EndPosition = mousePosition.ReadValue<Vector2>();

            // 计算位置差值
            float deltaX = (EndPosition.x - ClickPosition.x) * sensitivity;
            float deltaY = (EndPosition.y - ClickPosition.y) * sensitivity;

            if (DebugMod)
            {
                Debug.Log("NowPosition = " + EndPosition);
                Debug.Log("deltaX = " + deltaX);
                Debug.Log("deltaY = " + deltaY);
            }

            // 更新物体的旋转
            Vector3 currentRotation = transform.eulerAngles;

            // 将旋转角度转换到负值范围
            float newRotationY = NormalizeAngle(currentRotation.y + deltaX);
            float newRotationX = Mathf.Clamp(currentRotation.x + deltaY, minRotation, maxRotation);

            // 应用旋转，使用 Quaternion.Euler
            transform.rotation = Quaternion.Euler(newRotationX, newRotationY, 0f);

            // Yield execution of this coroutine and return to the main loop until next frame
            yield return null;
        }
    }

    private float NormalizeAngle(float angle)
    {
        // 将角度转换到 -180 到 180 度范围
        angle = angle % 360f;
        if (angle > 180f) angle -= 360f;
        return angle;
    }




}
