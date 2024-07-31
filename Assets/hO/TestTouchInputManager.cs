using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestTouchInputManager : MonoBehaviour
{
    private AndriodTestInput andriodTestInput;


   



    private void Awake()
    {
        andriodTestInput = new AndriodTestInput();
        andriodTestInput.PhoneInput.Enable();
    }

    private void OnEnable()
    {
        andriodTestInput.PhoneInput.Press.performed += TestTouch;
        andriodTestInput.PhoneInput.Press.canceled += TestTouch;

    }

    private void OnDisable()
    {
        andriodTestInput.PhoneInput.Press.performed -= TestTouch;
        andriodTestInput.PhoneInput.Press.canceled -= TestTouch;
    }

    public void TestTouch(InputAction.CallbackContext obj)
    {
        Debug.Log(andriodTestInput.PhoneInput.PressPosition.ReadValue<Vector2>());
    }
}


public class Testt : MonoBehaviour
{
    delegate void TestAction();
    TestAction ActionA;

    delegate void TestActionInt(int inputInt);
    TestActionInt ActionB;

    void FunctionA1(){ Debug.Log("a"); }
    void FunctionA2() { Debug.Log("aa"); }

    void FunctionB1(int i) { Debug.Log(i); }
    void FunctionB2(int i) { Debug.Log(i*2); }

    private void Start()
    {
        ActionA += FunctionA1;
        ActionA += FunctionA2;
        ActionB += FunctionB1;
        ActionB += FunctionB2;
        ActionA.Invoke();
        ActionB.Invoke(2);
        ActionA -= FunctionA2;
        ActionB -= FunctionB1;
        ActionA.Invoke();
        ActionB.Invoke(3);
    }




}