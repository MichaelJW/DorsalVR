// GENERATED AUTOMATICALLY FROM 'Assets/Input/DolphinControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DolphinControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DolphinControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DolphinControls"",
    ""maps"": [
        {
            ""name"": ""GameCube"",
            ""id"": ""8b1f429f-d3e8-4548-942e-7f2eb47dc734"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""5d62f93c-57b8-47b7-9dd0-ec59ca7549e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""d8cd58a9-4918-4f4a-8987-3a852a27e70c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Stick X"",
                    ""type"": ""Value"",
                    ""id"": ""7d53ab81-ede9-44f8-a1f1-e9623ba93ff7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""381b2c54-e329-4f2c-a3c6-d712fec40530"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cc9333e-b4c8-48a3-8a95-d766b60b6b09"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e787a5d1-b2a8-4726-9c2f-e949fb11acb4"",
                    ""path"": ""<SteeringWheelDorsalDevice>/tilt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Stick X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameCube
        m_GameCube = asset.FindActionMap("GameCube", throwIfNotFound: true);
        m_GameCube_A = m_GameCube.FindAction("A", throwIfNotFound: true);
        m_GameCube_B = m_GameCube.FindAction("B", throwIfNotFound: true);
        m_GameCube_LeftStickX = m_GameCube.FindAction("Left Stick X", throwIfNotFound: true);
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

    // GameCube
    private readonly InputActionMap m_GameCube;
    private IGameCubeActions m_GameCubeActionsCallbackInterface;
    private readonly InputAction m_GameCube_A;
    private readonly InputAction m_GameCube_B;
    private readonly InputAction m_GameCube_LeftStickX;
    public struct GameCubeActions
    {
        private @DolphinControls m_Wrapper;
        public GameCubeActions(@DolphinControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_GameCube_A;
        public InputAction @B => m_Wrapper.m_GameCube_B;
        public InputAction @LeftStickX => m_Wrapper.m_GameCube_LeftStickX;
        public InputActionMap Get() { return m_Wrapper.m_GameCube; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameCubeActions set) { return set.Get(); }
        public void SetCallbacks(IGameCubeActions instance)
        {
            if (m_Wrapper.m_GameCubeActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_GameCubeActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_GameCubeActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_GameCubeActionsCallbackInterface.OnA;
                @B.started -= m_Wrapper.m_GameCubeActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_GameCubeActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_GameCubeActionsCallbackInterface.OnB;
                @LeftStickX.started -= m_Wrapper.m_GameCubeActionsCallbackInterface.OnLeftStickX;
                @LeftStickX.performed -= m_Wrapper.m_GameCubeActionsCallbackInterface.OnLeftStickX;
                @LeftStickX.canceled -= m_Wrapper.m_GameCubeActionsCallbackInterface.OnLeftStickX;
            }
            m_Wrapper.m_GameCubeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @LeftStickX.started += instance.OnLeftStickX;
                @LeftStickX.performed += instance.OnLeftStickX;
                @LeftStickX.canceled += instance.OnLeftStickX;
            }
        }
    }
    public GameCubeActions @GameCube => new GameCubeActions(this);
    public interface IGameCubeActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnLeftStickX(InputAction.CallbackContext context);
    }
}
