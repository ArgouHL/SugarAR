using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-3)]
public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public PhoneInput input;
    private void Awake()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            input = new();
            DontDestroyOnLoad(gameObject);
        }      
    }

    public void EnableInput(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.Dialog:
                input.Dialog.Enable();
                break;
            case InputType.AR:
                input.ArTouch.Enable();
                break;
            default:
                break;
        }

    }

    public void DisableInput(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.Dialog:
                input.Dialog.Disable();
                break;
            case InputType.AR:
                input.ArTouch.Disable();
                break;
            default:
                break;
        }

    }


}

public enum InputType { Dialog,AR}
