//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/DialogSys/Input/DialogInput 1.inputactions
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

public partial class @DialogInput1: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DialogInput1()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DialogInput 1"",
    ""maps"": [
        {
            ""name"": ""MoblieUI"",
            ""id"": ""5b81d9b1-b39c-4749-817e-80e05c4a7a85"",
            ""actions"": [
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""cb47eb89-5bf4-4ab2-bb3e-0d48ad1b0104"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PressPosition"",
                    ""type"": ""Value"",
                    ""id"": ""87c4fd12-4af9-4a6f-85c1-d39fb3a3d42a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f65f36d2-7380-4555-a321-909d734ea6b8"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e29bc1c-6030-4f80-a3e9-c987bde3f405"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MoblieUI
        m_MoblieUI = asset.FindActionMap("MoblieUI", throwIfNotFound: true);
        m_MoblieUI_Press = m_MoblieUI.FindAction("Press", throwIfNotFound: true);
        m_MoblieUI_PressPosition = m_MoblieUI.FindAction("PressPosition", throwIfNotFound: true);
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

    // MoblieUI
    private readonly InputActionMap m_MoblieUI;
    private List<IMoblieUIActions> m_MoblieUIActionsCallbackInterfaces = new List<IMoblieUIActions>();
    private readonly InputAction m_MoblieUI_Press;
    private readonly InputAction m_MoblieUI_PressPosition;
    public struct MoblieUIActions
    {
        private @DialogInput1 m_Wrapper;
        public MoblieUIActions(@DialogInput1 wrapper) { m_Wrapper = wrapper; }
        public InputAction @Press => m_Wrapper.m_MoblieUI_Press;
        public InputAction @PressPosition => m_Wrapper.m_MoblieUI_PressPosition;
        public InputActionMap Get() { return m_Wrapper.m_MoblieUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoblieUIActions set) { return set.Get(); }
        public void AddCallbacks(IMoblieUIActions instance)
        {
            if (instance == null || m_Wrapper.m_MoblieUIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MoblieUIActionsCallbackInterfaces.Add(instance);
            @Press.started += instance.OnPress;
            @Press.performed += instance.OnPress;
            @Press.canceled += instance.OnPress;
            @PressPosition.started += instance.OnPressPosition;
            @PressPosition.performed += instance.OnPressPosition;
            @PressPosition.canceled += instance.OnPressPosition;
        }

        private void UnregisterCallbacks(IMoblieUIActions instance)
        {
            @Press.started -= instance.OnPress;
            @Press.performed -= instance.OnPress;
            @Press.canceled -= instance.OnPress;
            @PressPosition.started -= instance.OnPressPosition;
            @PressPosition.performed -= instance.OnPressPosition;
            @PressPosition.canceled -= instance.OnPressPosition;
        }

        public void RemoveCallbacks(IMoblieUIActions instance)
        {
            if (m_Wrapper.m_MoblieUIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMoblieUIActions instance)
        {
            foreach (var item in m_Wrapper.m_MoblieUIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MoblieUIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MoblieUIActions @MoblieUI => new MoblieUIActions(this);
    public interface IMoblieUIActions
    {
        void OnPress(InputAction.CallbackContext context);
        void OnPressPosition(InputAction.CallbackContext context);
    }
}