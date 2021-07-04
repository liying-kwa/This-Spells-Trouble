// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""0c9baf4d-3251-473b-8367-85632241437b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6fb3a9ec-769a-4a81-a382-93192844a797"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f038c5ee-6c2d-4108-bcb1-6de035def9de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""289f9890-0122-4137-b5c0-a01a44cde8fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d71e4b47-0796-40a8-a260-52115745c45d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b90bbba-30f8-4ff8-9162-284c938cf990"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""790a4794-a708-4c09-a029-29abff75009f"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CharacterSelection"",
            ""id"": ""ea08e204-2ea7-4349-87fa-b4c9db48ba8c"",
            ""actions"": [
                {
                    ""name"": ""JoinPlayer"",
                    ""type"": ""Button"",
                    ""id"": ""e1131421-ed9c-4a8d-929d-0e992152e895"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DirectionalUp"",
                    ""type"": ""Button"",
                    ""id"": ""c4044925-e2a4-47b0-b2bf-727faf56774b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AnalogUp"",
                    ""type"": ""Button"",
                    ""id"": ""f0a05396-dc83-4ba4-ac88-740257075974"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DirectionalDown"",
                    ""type"": ""Button"",
                    ""id"": ""d3d334b7-3d1b-4835-b081-5d3ba031eb79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AnalogDown"",
                    ""type"": ""Button"",
                    ""id"": ""e47c1ce1-c8ae-4b87-96b1-251e47fd5016"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ready"",
                    ""type"": ""Button"",
                    ""id"": ""036550cb-a6f8-4c23-b1ba-1c27aeadd2aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fbfcb79c-8f33-4c5b-a607-648dc35809dc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoinPlayer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03325085-48d3-44be-aded-f3d852503372"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DirectionalUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56254b26-64d2-42fe-95a6-c5a10cb5645e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnalogUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""839588e0-d25c-4088-ba99-c661b6af9c4b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DirectionalDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b03106e1-028c-4467-be8a-efdcb8cf858e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnalogDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04ae0133-4ae3-4dcd-b601-776ee7e0e7d0"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ready"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Aim = m_Gameplay.FindAction("Aim", throwIfNotFound: true);
        m_Gameplay_Fire = m_Gameplay.FindAction("Fire", throwIfNotFound: true);
        // CharacterSelection
        m_CharacterSelection = asset.FindActionMap("CharacterSelection", throwIfNotFound: true);
        m_CharacterSelection_JoinPlayer = m_CharacterSelection.FindAction("JoinPlayer", throwIfNotFound: true);
        m_CharacterSelection_DirectionalUp = m_CharacterSelection.FindAction("DirectionalUp", throwIfNotFound: true);
        m_CharacterSelection_AnalogUp = m_CharacterSelection.FindAction("AnalogUp", throwIfNotFound: true);
        m_CharacterSelection_DirectionalDown = m_CharacterSelection.FindAction("DirectionalDown", throwIfNotFound: true);
        m_CharacterSelection_AnalogDown = m_CharacterSelection.FindAction("AnalogDown", throwIfNotFound: true);
        m_CharacterSelection_Ready = m_CharacterSelection.FindAction("Ready", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Aim;
    private readonly InputAction m_Gameplay_Fire;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Aim => m_Wrapper.m_Gameplay_Aim;
        public InputAction @Fire => m_Wrapper.m_Gameplay_Fire;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAim;
                @Fire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // CharacterSelection
    private readonly InputActionMap m_CharacterSelection;
    private ICharacterSelectionActions m_CharacterSelectionActionsCallbackInterface;
    private readonly InputAction m_CharacterSelection_JoinPlayer;
    private readonly InputAction m_CharacterSelection_DirectionalUp;
    private readonly InputAction m_CharacterSelection_AnalogUp;
    private readonly InputAction m_CharacterSelection_DirectionalDown;
    private readonly InputAction m_CharacterSelection_AnalogDown;
    private readonly InputAction m_CharacterSelection_Ready;
    public struct CharacterSelectionActions
    {
        private @PlayerControls m_Wrapper;
        public CharacterSelectionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @JoinPlayer => m_Wrapper.m_CharacterSelection_JoinPlayer;
        public InputAction @DirectionalUp => m_Wrapper.m_CharacterSelection_DirectionalUp;
        public InputAction @AnalogUp => m_Wrapper.m_CharacterSelection_AnalogUp;
        public InputAction @DirectionalDown => m_Wrapper.m_CharacterSelection_DirectionalDown;
        public InputAction @AnalogDown => m_Wrapper.m_CharacterSelection_AnalogDown;
        public InputAction @Ready => m_Wrapper.m_CharacterSelection_Ready;
        public InputActionMap Get() { return m_Wrapper.m_CharacterSelection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterSelectionActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterSelectionActions instance)
        {
            if (m_Wrapper.m_CharacterSelectionActionsCallbackInterface != null)
            {
                @JoinPlayer.started -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnJoinPlayer;
                @JoinPlayer.performed -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnJoinPlayer;
                @JoinPlayer.canceled -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnJoinPlayer;
                @DirectionalUp.started -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnDirectionalUp;
                @DirectionalUp.performed -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnDirectionalUp;
                @DirectionalUp.canceled -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnDirectionalUp;
                @AnalogUp.started -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnAnalogUp;
                @AnalogUp.performed -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnAnalogUp;
                @AnalogUp.canceled -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnAnalogUp;
                @DirectionalDown.started -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnDirectionalDown;
                @DirectionalDown.performed -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnDirectionalDown;
                @DirectionalDown.canceled -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnDirectionalDown;
                @AnalogDown.started -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnAnalogDown;
                @AnalogDown.performed -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnAnalogDown;
                @AnalogDown.canceled -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnAnalogDown;
                @Ready.started -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnReady;
                @Ready.performed -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnReady;
                @Ready.canceled -= m_Wrapper.m_CharacterSelectionActionsCallbackInterface.OnReady;
            }
            m_Wrapper.m_CharacterSelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JoinPlayer.started += instance.OnJoinPlayer;
                @JoinPlayer.performed += instance.OnJoinPlayer;
                @JoinPlayer.canceled += instance.OnJoinPlayer;
                @DirectionalUp.started += instance.OnDirectionalUp;
                @DirectionalUp.performed += instance.OnDirectionalUp;
                @DirectionalUp.canceled += instance.OnDirectionalUp;
                @AnalogUp.started += instance.OnAnalogUp;
                @AnalogUp.performed += instance.OnAnalogUp;
                @AnalogUp.canceled += instance.OnAnalogUp;
                @DirectionalDown.started += instance.OnDirectionalDown;
                @DirectionalDown.performed += instance.OnDirectionalDown;
                @DirectionalDown.canceled += instance.OnDirectionalDown;
                @AnalogDown.started += instance.OnAnalogDown;
                @AnalogDown.performed += instance.OnAnalogDown;
                @AnalogDown.canceled += instance.OnAnalogDown;
                @Ready.started += instance.OnReady;
                @Ready.performed += instance.OnReady;
                @Ready.canceled += instance.OnReady;
            }
        }
    }
    public CharacterSelectionActions @CharacterSelection => new CharacterSelectionActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
    public interface ICharacterSelectionActions
    {
        void OnJoinPlayer(InputAction.CallbackContext context);
        void OnDirectionalUp(InputAction.CallbackContext context);
        void OnAnalogUp(InputAction.CallbackContext context);
        void OnDirectionalDown(InputAction.CallbackContext context);
        void OnAnalogDown(InputAction.CallbackContext context);
        void OnReady(InputAction.CallbackContext context);
    }
}
