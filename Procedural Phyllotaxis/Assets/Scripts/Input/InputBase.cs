// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputBase.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputBase : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputBase()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputBase"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""ecd8dac7-2722-4123-a5ae-12531ce4f9ca"",
            ""actions"": [
                {
                    ""name"": ""LeftStick XY Pos"",
                    ""type"": ""Value"",
                    ""id"": ""f11ac0cf-0881-4555-ad40-8163f606ee8f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStick XY Pos"",
                    ""type"": ""Value"",
                    ""id"": ""dcfb96ee-401f-4171-b049-78b0dfd37a8d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Face Button"",
                    ""type"": ""Button"",
                    ""id"": ""f93c4a99-1c11-4ecd-a07f-139ed4784cd5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Face Button"",
                    ""type"": ""Button"",
                    ""id"": ""21164d60-fa17-4517-8cb5-3228c3974705"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Top Face Button"",
                    ""type"": ""Button"",
                    ""id"": ""e21adca5-64a9-412d-a490-b99052bb477b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bottom Face Button"",
                    ""type"": ""Button"",
                    ""id"": ""46847deb-3c84-4c32-a31c-b961bb140109"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Triggers"",
                    ""type"": ""Value"",
                    ""id"": ""f974f8dd-c5e5-4eac-9a09-cf532bcf5da3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoulders"",
                    ""type"": ""Value"",
                    ""id"": ""9680719c-4c88-4952-95f5-a468d4b5d57d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bf2b6d9f-49cf-48a2-b5b9-337d21a1d90e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""LeftStick XY Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03e49cc7-b4ca-484b-b947-bdc9d0381eee"",
                    ""path"": ""<HID::Logitech Logitech Extreme 3D>/hat"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""LeftStick XY Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ef4c51b-b869-4e85-a1e1-54dfafe07d0a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""RightStick XY Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7366c8bf-c13e-4de2-b4f3-4ddafd1a5fee"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Left Face Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d425bb4e-44e9-4704-8404-3b95ca749897"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Right Face Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1833a748-9ff4-4629-8ee0-53eb28fc11d8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Top Face Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae4e135f-ad0c-4506-90be-e35f1eeb0c32"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Bottom Face Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Triggers"",
                    ""id"": ""a6ce4ab6-cea2-4a0f-9e08-0dd68640dcf7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Triggers"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9ae6dadb-330e-4e23-a53e-e8ed52e0f258"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Triggers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""097ee949-c3e5-4f97-b9d0-2b15932c8490"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Triggers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ThumbStick"",
                    ""id"": ""dc85d39a-0921-43dc-98b4-49b9156d3333"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Triggers"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c83d3467-1fc6-4140-bcfb-d4ebf2c5f822"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Triggers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f278484a-8c09-4a7a-a6e1-3538d60eef97"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Triggers"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Shoulders"",
                    ""id"": ""23e5bfc6-d767-4b2a-8da4-b1c6c9a985a2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoulders"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0d0091fc-243c-4b45-b469-d4250e4b4a1b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Shoulders"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7f79e77c-0bb3-448a-8c7e-ee4f5a3962d8"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PhylloControls"",
                    ""action"": ""Shoulders"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PhylloControls"",
            ""bindingGroup"": ""PhylloControls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_LeftStickXYPos = m_Player.FindAction("LeftStick XY Pos", throwIfNotFound: true);
        m_Player_RightStickXYPos = m_Player.FindAction("RightStick XY Pos", throwIfNotFound: true);
        m_Player_LeftFaceButton = m_Player.FindAction("Left Face Button", throwIfNotFound: true);
        m_Player_RightFaceButton = m_Player.FindAction("Right Face Button", throwIfNotFound: true);
        m_Player_TopFaceButton = m_Player.FindAction("Top Face Button", throwIfNotFound: true);
        m_Player_BottomFaceButton = m_Player.FindAction("Bottom Face Button", throwIfNotFound: true);
        m_Player_Triggers = m_Player.FindAction("Triggers", throwIfNotFound: true);
        m_Player_Shoulders = m_Player.FindAction("Shoulders", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_LeftStickXYPos;
    private readonly InputAction m_Player_RightStickXYPos;
    private readonly InputAction m_Player_LeftFaceButton;
    private readonly InputAction m_Player_RightFaceButton;
    private readonly InputAction m_Player_TopFaceButton;
    private readonly InputAction m_Player_BottomFaceButton;
    private readonly InputAction m_Player_Triggers;
    private readonly InputAction m_Player_Shoulders;
    public struct PlayerActions
    {
        private @InputBase m_Wrapper;
        public PlayerActions(@InputBase wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftStickXYPos => m_Wrapper.m_Player_LeftStickXYPos;
        public InputAction @RightStickXYPos => m_Wrapper.m_Player_RightStickXYPos;
        public InputAction @LeftFaceButton => m_Wrapper.m_Player_LeftFaceButton;
        public InputAction @RightFaceButton => m_Wrapper.m_Player_RightFaceButton;
        public InputAction @TopFaceButton => m_Wrapper.m_Player_TopFaceButton;
        public InputAction @BottomFaceButton => m_Wrapper.m_Player_BottomFaceButton;
        public InputAction @Triggers => m_Wrapper.m_Player_Triggers;
        public InputAction @Shoulders => m_Wrapper.m_Player_Shoulders;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @LeftStickXYPos.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStickXYPos;
                @LeftStickXYPos.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStickXYPos;
                @LeftStickXYPos.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStickXYPos;
                @RightStickXYPos.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightStickXYPos;
                @RightStickXYPos.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightStickXYPos;
                @RightStickXYPos.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightStickXYPos;
                @LeftFaceButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftFaceButton;
                @LeftFaceButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftFaceButton;
                @LeftFaceButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftFaceButton;
                @RightFaceButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightFaceButton;
                @RightFaceButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightFaceButton;
                @RightFaceButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightFaceButton;
                @TopFaceButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTopFaceButton;
                @TopFaceButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTopFaceButton;
                @TopFaceButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTopFaceButton;
                @BottomFaceButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBottomFaceButton;
                @BottomFaceButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBottomFaceButton;
                @BottomFaceButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBottomFaceButton;
                @Triggers.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggers;
                @Triggers.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggers;
                @Triggers.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggers;
                @Shoulders.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoulders;
                @Shoulders.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoulders;
                @Shoulders.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoulders;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftStickXYPos.started += instance.OnLeftStickXYPos;
                @LeftStickXYPos.performed += instance.OnLeftStickXYPos;
                @LeftStickXYPos.canceled += instance.OnLeftStickXYPos;
                @RightStickXYPos.started += instance.OnRightStickXYPos;
                @RightStickXYPos.performed += instance.OnRightStickXYPos;
                @RightStickXYPos.canceled += instance.OnRightStickXYPos;
                @LeftFaceButton.started += instance.OnLeftFaceButton;
                @LeftFaceButton.performed += instance.OnLeftFaceButton;
                @LeftFaceButton.canceled += instance.OnLeftFaceButton;
                @RightFaceButton.started += instance.OnRightFaceButton;
                @RightFaceButton.performed += instance.OnRightFaceButton;
                @RightFaceButton.canceled += instance.OnRightFaceButton;
                @TopFaceButton.started += instance.OnTopFaceButton;
                @TopFaceButton.performed += instance.OnTopFaceButton;
                @TopFaceButton.canceled += instance.OnTopFaceButton;
                @BottomFaceButton.started += instance.OnBottomFaceButton;
                @BottomFaceButton.performed += instance.OnBottomFaceButton;
                @BottomFaceButton.canceled += instance.OnBottomFaceButton;
                @Triggers.started += instance.OnTriggers;
                @Triggers.performed += instance.OnTriggers;
                @Triggers.canceled += instance.OnTriggers;
                @Shoulders.started += instance.OnShoulders;
                @Shoulders.performed += instance.OnShoulders;
                @Shoulders.canceled += instance.OnShoulders;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PhylloControlsSchemeIndex = -1;
    public InputControlScheme PhylloControlsScheme
    {
        get
        {
            if (m_PhylloControlsSchemeIndex == -1) m_PhylloControlsSchemeIndex = asset.FindControlSchemeIndex("PhylloControls");
            return asset.controlSchemes[m_PhylloControlsSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnLeftStickXYPos(InputAction.CallbackContext context);
        void OnRightStickXYPos(InputAction.CallbackContext context);
        void OnLeftFaceButton(InputAction.CallbackContext context);
        void OnRightFaceButton(InputAction.CallbackContext context);
        void OnTopFaceButton(InputAction.CallbackContext context);
        void OnBottomFaceButton(InputAction.CallbackContext context);
        void OnTriggers(InputAction.CallbackContext context);
        void OnShoulders(InputAction.CallbackContext context);
    }
}
