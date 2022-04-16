//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/ProjectInput/UserInputActions.inputactions
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

namespace ProjectInput
{
    public partial class @UserInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @UserInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserInputActions"",
    ""maps"": [
        {
            ""name"": ""RTS_Controls"",
            ""id"": ""1bf51959-d84e-4b3d-8ad0-4a495887a1e1"",
            ""actions"": [
                {
                    ""name"": ""CursorPosition"",
                    ""type"": ""Value"",
                    ""id"": ""9f09e103-e20e-46e8-8475-4932ab758caa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraMovement"",
                    ""type"": ""Value"",
                    ""id"": ""32e6f7ec-2ee7-4a10-a28a-e8e999367ace"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SelectSceneArea"",
                    ""type"": ""Value"",
                    ""id"": ""6815888a-29e3-4a80-9d7e-4ac5126985ee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2df1d594-3054-40d7-b226-96f8225ff85b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""CursorPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WSAD Keys"",
                    ""id"": ""7a2ab997-6705-45e8-a145-2d6a04a7ee6a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""553ed1bc-67a8-40e8-bab2-857f8e01e619"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""450bf1fc-317f-4f63-b52b-166cd1afa8b8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""02effe98-a6ca-405b-90ce-0f37e059e990"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""64992c3e-f799-4729-9887-85be63c5cee4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""CameraMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8bb90357-acfd-4f9f-a1ef-170514c24865"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyboard"",
                    ""action"": ""SelectSceneArea"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseAndKeyboard"",
            ""bindingGroup"": ""MouseAndKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // RTS_Controls
            m_RTS_Controls = asset.FindActionMap("RTS_Controls", throwIfNotFound: true);
            m_RTS_Controls_CursorPosition = m_RTS_Controls.FindAction("CursorPosition", throwIfNotFound: true);
            m_RTS_Controls_CameraMovement = m_RTS_Controls.FindAction("CameraMovement", throwIfNotFound: true);
            m_RTS_Controls_SelectSceneArea = m_RTS_Controls.FindAction("SelectSceneArea", throwIfNotFound: true);
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

        // RTS_Controls
        private readonly InputActionMap m_RTS_Controls;
        private IRTS_ControlsActions m_RTS_ControlsActionsCallbackInterface;
        private readonly InputAction m_RTS_Controls_CursorPosition;
        private readonly InputAction m_RTS_Controls_CameraMovement;
        private readonly InputAction m_RTS_Controls_SelectSceneArea;
        public struct RTS_ControlsActions
        {
            private @UserInputActions m_Wrapper;
            public RTS_ControlsActions(@UserInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @CursorPosition => m_Wrapper.m_RTS_Controls_CursorPosition;
            public InputAction @CameraMovement => m_Wrapper.m_RTS_Controls_CameraMovement;
            public InputAction @SelectSceneArea => m_Wrapper.m_RTS_Controls_SelectSceneArea;
            public InputActionMap Get() { return m_Wrapper.m_RTS_Controls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RTS_ControlsActions set) { return set.Get(); }
            public void SetCallbacks(IRTS_ControlsActions instance)
            {
                if (m_Wrapper.m_RTS_ControlsActionsCallbackInterface != null)
                {
                    @CursorPosition.started -= m_Wrapper.m_RTS_ControlsActionsCallbackInterface.OnCursorPosition;
                    @CursorPosition.performed -= m_Wrapper.m_RTS_ControlsActionsCallbackInterface.OnCursorPosition;
                    @CursorPosition.canceled -= m_Wrapper.m_RTS_ControlsActionsCallbackInterface.OnCursorPosition;
                    @CameraMovement.started -= m_Wrapper.m_RTS_ControlsActionsCallbackInterface.OnCameraMovement;
                    @CameraMovement.performed -= m_Wrapper.m_RTS_ControlsActionsCallbackInterface.OnCameraMovement;
                    @CameraMovement.canceled -= m_Wrapper.m_RTS_ControlsActionsCallbackInterface.OnCameraMovement;
                    @SelectSceneArea.started -= m_Wrapper.m_RTS_ControlsActionsCallbackInterface.OnSelectSceneArea;
                    @SelectSceneArea.performed -= m_Wrapper.m_RTS_ControlsActionsCallbackInterface.OnSelectSceneArea;
                    @SelectSceneArea.canceled -= m_Wrapper.m_RTS_ControlsActionsCallbackInterface.OnSelectSceneArea;
                }
                m_Wrapper.m_RTS_ControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @CursorPosition.started += instance.OnCursorPosition;
                    @CursorPosition.performed += instance.OnCursorPosition;
                    @CursorPosition.canceled += instance.OnCursorPosition;
                    @CameraMovement.started += instance.OnCameraMovement;
                    @CameraMovement.performed += instance.OnCameraMovement;
                    @CameraMovement.canceled += instance.OnCameraMovement;
                    @SelectSceneArea.started += instance.OnSelectSceneArea;
                    @SelectSceneArea.performed += instance.OnSelectSceneArea;
                    @SelectSceneArea.canceled += instance.OnSelectSceneArea;
                }
            }
        }
        public RTS_ControlsActions @RTS_Controls => new RTS_ControlsActions(this);
        private int m_MouseAndKeyboardSchemeIndex = -1;
        public InputControlScheme MouseAndKeyboardScheme
        {
            get
            {
                if (m_MouseAndKeyboardSchemeIndex == -1) m_MouseAndKeyboardSchemeIndex = asset.FindControlSchemeIndex("MouseAndKeyboard");
                return asset.controlSchemes[m_MouseAndKeyboardSchemeIndex];
            }
        }
        public interface IRTS_ControlsActions
        {
            void OnCursorPosition(InputAction.CallbackContext context);
            void OnCameraMovement(InputAction.CallbackContext context);
            void OnSelectSceneArea(InputAction.CallbackContext context);
        }
    }
}