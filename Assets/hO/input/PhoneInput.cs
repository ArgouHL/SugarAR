//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Ho/input/PhoneInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PhoneInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PhoneInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PhoneInput"",
    ""maps"": [
        {
            ""name"": ""ArTouch"",
            ""id"": ""1c36ddf9-294c-48c0-aefd-9b4390ef0b7c"",
            ""actions"": [
                {
                    ""name"": ""TouchPos"",
                    ""type"": ""Value"",
                    ""id"": ""1fda6d1d-edb9-4595-bf73-b9228b9781a0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""326ca7f8-f3bc-4435-93dc-36630da7081b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fcb8e0ce-d94a-4ca3-a0f5-df9da376b76e"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfe7e4cb-2312-450b-b0f4-9dd8f28e0834"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialog"",
            ""id"": ""d2c64a3a-1d51-4738-81fc-330bc2f0d869"",
            ""actions"": [
                {
                    ""name"": ""TouchPos"",
                    ""type"": ""Value"",
                    ""id"": ""d37ea871-e578-41d8-a0dc-7519ef0be985"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Button"",
                    ""id"": ""b37314eb-5882-44ab-9c1a-6dc0d43c3114"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a5c47fd4-3507-486a-bd34-537e31697915"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70a042b9-08bd-45a3-b488-9808ecec4f41"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ArTouch
        m_ArTouch = asset.FindActionMap("ArTouch", throwIfNotFound: true);
        m_ArTouch_TouchPos = m_ArTouch.FindAction("TouchPos", throwIfNotFound: true);
        m_ArTouch_Touch = m_ArTouch.FindAction("Touch", throwIfNotFound: true);
        // Dialog
        m_Dialog = asset.FindActionMap("Dialog", throwIfNotFound: true);
        m_Dialog_TouchPos = m_Dialog.FindAction("TouchPos", throwIfNotFound: true);
        m_Dialog_Touch = m_Dialog.FindAction("Touch", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // ArTouch
    private readonly InputActionMap m_ArTouch;
    private List<IArTouchActions> m_ArTouchActionsCallbackInterfaces = new List<IArTouchActions>();
    private readonly InputAction m_ArTouch_TouchPos;
    private readonly InputAction m_ArTouch_Touch;
    public struct ArTouchActions
    {
        private @PhoneInput m_Wrapper;
        public ArTouchActions(@PhoneInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPos => m_Wrapper.m_ArTouch_TouchPos;
        public InputAction @Touch => m_Wrapper.m_ArTouch_Touch;
        public InputActionMap Get() { return m_Wrapper.m_ArTouch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ArTouchActions set) { return set.Get(); }
        public void AddCallbacks(IArTouchActions instance)
        {
            if (instance == null || m_Wrapper.m_ArTouchActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ArTouchActionsCallbackInterfaces.Add(instance);
            @TouchPos.started += instance.OnTouchPos;
            @TouchPos.performed += instance.OnTouchPos;
            @TouchPos.canceled += instance.OnTouchPos;
            @Touch.started += instance.OnTouch;
            @Touch.performed += instance.OnTouch;
            @Touch.canceled += instance.OnTouch;
        }

        private void UnregisterCallbacks(IArTouchActions instance)
        {
            @TouchPos.started -= instance.OnTouchPos;
            @TouchPos.performed -= instance.OnTouchPos;
            @TouchPos.canceled -= instance.OnTouchPos;
            @Touch.started -= instance.OnTouch;
            @Touch.performed -= instance.OnTouch;
            @Touch.canceled -= instance.OnTouch;
        }

        public void RemoveCallbacks(IArTouchActions instance)
        {
            if (m_Wrapper.m_ArTouchActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IArTouchActions instance)
        {
            foreach (var item in m_Wrapper.m_ArTouchActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ArTouchActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ArTouchActions @ArTouch => new ArTouchActions(this);

    // Dialog
    private readonly InputActionMap m_Dialog;
    private List<IDialogActions> m_DialogActionsCallbackInterfaces = new List<IDialogActions>();
    private readonly InputAction m_Dialog_TouchPos;
    private readonly InputAction m_Dialog_Touch;
    public struct DialogActions
    {
        private @PhoneInput m_Wrapper;
        public DialogActions(@PhoneInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPos => m_Wrapper.m_Dialog_TouchPos;
        public InputAction @Touch => m_Wrapper.m_Dialog_Touch;
        public InputActionMap Get() { return m_Wrapper.m_Dialog; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogActions set) { return set.Get(); }
        public void AddCallbacks(IDialogActions instance)
        {
            if (instance == null || m_Wrapper.m_DialogActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_DialogActionsCallbackInterfaces.Add(instance);
            @TouchPos.started += instance.OnTouchPos;
            @TouchPos.performed += instance.OnTouchPos;
            @TouchPos.canceled += instance.OnTouchPos;
            @Touch.started += instance.OnTouch;
            @Touch.performed += instance.OnTouch;
            @Touch.canceled += instance.OnTouch;
        }

        private void UnregisterCallbacks(IDialogActions instance)
        {
            @TouchPos.started -= instance.OnTouchPos;
            @TouchPos.performed -= instance.OnTouchPos;
            @TouchPos.canceled -= instance.OnTouchPos;
            @Touch.started -= instance.OnTouch;
            @Touch.performed -= instance.OnTouch;
            @Touch.canceled -= instance.OnTouch;
        }

        public void RemoveCallbacks(IDialogActions instance)
        {
            if (m_Wrapper.m_DialogActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IDialogActions instance)
        {
            foreach (var item in m_Wrapper.m_DialogActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_DialogActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public DialogActions @Dialog => new DialogActions(this);
    public interface IArTouchActions
    {
        void OnTouchPos(InputAction.CallbackContext context);
        void OnTouch(InputAction.CallbackContext context);
    }
    public interface IDialogActions
    {
        void OnTouchPos(InputAction.CallbackContext context);
        void OnTouch(InputAction.CallbackContext context);
    }
}
