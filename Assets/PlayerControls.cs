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
            ""name"": ""Battle"",
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
                    ""name"": ""Spell1"",
                    ""type"": ""Button"",
                    ""id"": ""5051e8dd-5165-4aad-924d-f8775422de2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spell2"",
                    ""type"": ""Button"",
                    ""id"": ""289f9890-0122-4137-b5c0-a01a44cde8fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spell3"",
                    ""type"": ""Button"",
                    ""id"": ""efd2b622-12e5-4477-a525-2845777aef74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spell4"",
                    ""type"": ""Button"",
                    ""id"": ""d0e39c88-96f8-4a14-8af7-6e5a78221df8"",
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
                    ""action"": ""Spell2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c929b0f-73f9-43d8-b348-d854bd7a08ec"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f253cfda-bfd5-4ebb-a49b-ef48d5900d5c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92a12828-bc7d-4498-965a-c50da9a16ff4"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spell3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CharSelection"",
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
                    ""name"": ""PreviousCharacter"",
                    ""type"": ""Button"",
                    ""id"": ""c4044925-e2a4-47b0-b2bf-727faf56774b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextCharacter"",
                    ""type"": ""Button"",
                    ""id"": ""d3d334b7-3d1b-4835-b081-5d3ba031eb79"",
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
                    ""action"": ""PreviousCharacter"",
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
                    ""action"": ""NextCharacter"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""56254b26-64d2-42fe-95a6-c5a10cb5645e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousCharacter"",
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
                    ""action"": ""NextCharacter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Battle
        m_Battle = asset.FindActionMap("Battle", throwIfNotFound: true);
        m_Battle_Move = m_Battle.FindAction("Move", throwIfNotFound: true);
        m_Battle_Aim = m_Battle.FindAction("Aim", throwIfNotFound: true);
        m_Battle_Spell1 = m_Battle.FindAction("Spell1", throwIfNotFound: true);
        m_Battle_Spell2 = m_Battle.FindAction("Spell2", throwIfNotFound: true);
        m_Battle_Spell3 = m_Battle.FindAction("Spell3", throwIfNotFound: true);
        m_Battle_Spell4 = m_Battle.FindAction("Spell4", throwIfNotFound: true);
        // CharSelection
        m_CharSelection = asset.FindActionMap("CharSelection", throwIfNotFound: true);
        m_CharSelection_JoinPlayer = m_CharSelection.FindAction("JoinPlayer", throwIfNotFound: true);
        m_CharSelection_PreviousCharacter = m_CharSelection.FindAction("PreviousCharacter", throwIfNotFound: true);
        m_CharSelection_NextCharacter = m_CharSelection.FindAction("NextCharacter", throwIfNotFound: true);
        m_CharSelection_Ready = m_CharSelection.FindAction("Ready", throwIfNotFound: true);
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

    // Battle
    private readonly InputActionMap m_Battle;
    private IBattleActions m_BattleActionsCallbackInterface;
    private readonly InputAction m_Battle_Move;
    private readonly InputAction m_Battle_Aim;
    private readonly InputAction m_Battle_Spell1;
    private readonly InputAction m_Battle_Spell2;
    private readonly InputAction m_Battle_Spell3;
    private readonly InputAction m_Battle_Spell4;
    public struct BattleActions
    {
        private @PlayerControls m_Wrapper;
        public BattleActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Battle_Move;
        public InputAction @Aim => m_Wrapper.m_Battle_Aim;
        public InputAction @Spell1 => m_Wrapper.m_Battle_Spell1;
        public InputAction @Spell2 => m_Wrapper.m_Battle_Spell2;
        public InputAction @Spell3 => m_Wrapper.m_Battle_Spell3;
        public InputAction @Spell4 => m_Wrapper.m_Battle_Spell4;
        public InputActionMap Get() { return m_Wrapper.m_Battle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BattleActions set) { return set.Get(); }
        public void SetCallbacks(IBattleActions instance)
        {
            if (m_Wrapper.m_BattleActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnMove;
                @Aim.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnAim;
                @Spell1.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell1;
                @Spell1.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell1;
                @Spell1.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell1;
                @Spell2.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell2;
                @Spell2.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell2;
                @Spell2.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell2;
                @Spell3.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell3;
                @Spell3.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell3;
                @Spell3.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell3;
                @Spell4.started -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell4;
                @Spell4.performed -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell4;
                @Spell4.canceled -= m_Wrapper.m_BattleActionsCallbackInterface.OnSpell4;
            }
            m_Wrapper.m_BattleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Spell1.started += instance.OnSpell1;
                @Spell1.performed += instance.OnSpell1;
                @Spell1.canceled += instance.OnSpell1;
                @Spell2.started += instance.OnSpell2;
                @Spell2.performed += instance.OnSpell2;
                @Spell2.canceled += instance.OnSpell2;
                @Spell3.started += instance.OnSpell3;
                @Spell3.performed += instance.OnSpell3;
                @Spell3.canceled += instance.OnSpell3;
                @Spell4.started += instance.OnSpell4;
                @Spell4.performed += instance.OnSpell4;
                @Spell4.canceled += instance.OnSpell4;
            }
        }
    }
    public BattleActions @Battle => new BattleActions(this);

    // CharSelection
    private readonly InputActionMap m_CharSelection;
    private ICharSelectionActions m_CharSelectionActionsCallbackInterface;
    private readonly InputAction m_CharSelection_JoinPlayer;
    private readonly InputAction m_CharSelection_PreviousCharacter;
    private readonly InputAction m_CharSelection_NextCharacter;
    private readonly InputAction m_CharSelection_Ready;
    public struct CharSelectionActions
    {
        private @PlayerControls m_Wrapper;
        public CharSelectionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @JoinPlayer => m_Wrapper.m_CharSelection_JoinPlayer;
        public InputAction @PreviousCharacter => m_Wrapper.m_CharSelection_PreviousCharacter;
        public InputAction @NextCharacter => m_Wrapper.m_CharSelection_NextCharacter;
        public InputAction @Ready => m_Wrapper.m_CharSelection_Ready;
        public InputActionMap Get() { return m_Wrapper.m_CharSelection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharSelectionActions set) { return set.Get(); }
        public void SetCallbacks(ICharSelectionActions instance)
        {
            if (m_Wrapper.m_CharSelectionActionsCallbackInterface != null)
            {
                @JoinPlayer.started -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnJoinPlayer;
                @JoinPlayer.performed -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnJoinPlayer;
                @JoinPlayer.canceled -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnJoinPlayer;
                @PreviousCharacter.started -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnPreviousCharacter;
                @PreviousCharacter.performed -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnPreviousCharacter;
                @PreviousCharacter.canceled -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnPreviousCharacter;
                @NextCharacter.started -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnNextCharacter;
                @NextCharacter.performed -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnNextCharacter;
                @NextCharacter.canceled -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnNextCharacter;
                @Ready.started -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnReady;
                @Ready.performed -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnReady;
                @Ready.canceled -= m_Wrapper.m_CharSelectionActionsCallbackInterface.OnReady;
            }
            m_Wrapper.m_CharSelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @JoinPlayer.started += instance.OnJoinPlayer;
                @JoinPlayer.performed += instance.OnJoinPlayer;
                @JoinPlayer.canceled += instance.OnJoinPlayer;
                @PreviousCharacter.started += instance.OnPreviousCharacter;
                @PreviousCharacter.performed += instance.OnPreviousCharacter;
                @PreviousCharacter.canceled += instance.OnPreviousCharacter;
                @NextCharacter.started += instance.OnNextCharacter;
                @NextCharacter.performed += instance.OnNextCharacter;
                @NextCharacter.canceled += instance.OnNextCharacter;
                @Ready.started += instance.OnReady;
                @Ready.performed += instance.OnReady;
                @Ready.canceled += instance.OnReady;
            }
        }
    }
    public CharSelectionActions @CharSelection => new CharSelectionActions(this);
    public interface IBattleActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnSpell1(InputAction.CallbackContext context);
        void OnSpell2(InputAction.CallbackContext context);
        void OnSpell3(InputAction.CallbackContext context);
        void OnSpell4(InputAction.CallbackContext context);
    }
    public interface ICharSelectionActions
    {
        void OnJoinPlayer(InputAction.CallbackContext context);
        void OnPreviousCharacter(InputAction.CallbackContext context);
        void OnNextCharacter(InputAction.CallbackContext context);
        void OnReady(InputAction.CallbackContext context);
    }
}
