using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArSelect : MonoBehaviour
{
    public static ArSelect instance;


    public delegate void SearchAction(string hitName);
    public static SearchAction OnHit;
    private void Awake()
    {
       
        instance = this;
        SetActive(false);
        
    }

    private void OnEnable()
    {
        InputManager.instance.input.ArTouch.Touch.performed += OnTouch;
        Mainsys.OnArEnable += SetActive;
    }

    private void OnDisable()
    {
        InputManager.instance.input.ArTouch.Touch.performed -= OnTouch;
        Mainsys.OnArEnable -= SetActive;
    }

    private void OnTouch(InputAction.CallbackContext obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.instance.input.ArTouch.TouchPos.ReadValue<Vector2>());
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100);
        if(Physics.Raycast(ray ,out hit,20f,1<<6))
        {
            OnHit?.Invoke(hit.collider.name);
            Debug.Log(hit.collider.name);
        }
    }

    public void SetActive(bool b)
    {
        Debug.Log("ArSelect"+b);
        if(b)
            InputManager.instance.EnableInput(InputType.AR);
        else
            InputManager.instance.DisableInput(InputType.AR);
    }

}
