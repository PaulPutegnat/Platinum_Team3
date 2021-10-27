// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/PlayerControls.inputactions'

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
            ""name"": ""Player"",
            ""id"": ""65933aae-cba0-47b9-acbc-fc4a551029a9"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""23061fb7-41cd-4ff7-94d0-51c6bebccad3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bd93e288-fe41-42d3-b758-18603d874768"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PressG"",
                    ""type"": ""Button"",
                    ""id"": ""b30efb4c-7649-4381-b50d-978c0f82827d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressH"",
                    ""type"": ""Button"",
                    ""id"": ""5f564d11-149c-4785-94b8-d67a60f4cd79"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Echap"",
                    ""type"": ""Button"",
                    ""id"": ""fd7e0692-6ecd-46ed-9803-bc541e693501"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ZQSD"",
                    ""id"": ""bc6814bc-92b7-471c-b0eb-a03d75c9c77a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6e7a25e8-63f1-4c0c-8a5d-db099ad13d15"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9968a5d0-bca0-485e-bf32-6cb6c7f3c667"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6be15a7a-a05f-4c18-a7ec-ca3bb151cd6b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8e09c79b-457c-43bb-b4e0-f04b6ba46809"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8c6de6e2-7755-418c-a0ff-2af8f5fa3594"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c13c4d47-5434-4be5-802f-ff19b2d24995"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""059ad1b4-61dc-4b38-aa5a-b515fb7c8a5a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""149eb70e-4816-48da-98a4-fe28aa358b1b"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PressG"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d500f87-f554-4873-8b1d-dbd41d330b63"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PressH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ec1d657-a3ca-498a-8787-d6077658357b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Echap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ced620dc-099a-4eb3-b40e-44dac515a1f9"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Echap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Trapper"",
            ""id"": ""63a5c3ee-d382-4084-9565-6bb08fa995fc"",
            ""actions"": [
                {
                    ""name"": ""Trap Selection"",
                    ""type"": ""Button"",
                    ""id"": ""a093115c-94bc-413e-9c04-0ffa77239479"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1eeda40e-7f38-4650-8f67-2a1e501db7e8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Trap Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f2ec948-1cd4-4f28-98f3-a3f431aaab34"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Trap Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd4a4bdc-0691-42b8-85f6-8c07e1cbf4d3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Trap Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7dd2c390-34e1-408e-b68e-2544ffd1c948"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Trap Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Neutral"",
            ""id"": ""a1a56e4e-99c6-4f2f-85b2-ef5406c30205"",
            ""actions"": [
                {
                    ""name"": ""Menu Selection"",
                    ""type"": ""Value"",
                    ""id"": ""e02f4e07-8b56-4f57-b60c-87713047c611"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Comfirmation"",
                    ""type"": ""Button"",
                    ""id"": ""c515da0d-61ff-4e68-875e-6fe1bd2ae422"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""2b94c29d-edf5-42ce-9341-46b1d5b7b454"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""PlayTest"",
                    ""type"": ""Button"",
                    ""id"": ""1d0dcf97-da46-44d1-826d-c39ebf57f474"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""58b5adc1-504b-4ac8-a192-4398a34b6a3d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Menu Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fc0e7f38-94ab-429f-8f4f-fe2b9f09c65c"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b8c560f4-2893-4b70-b763-bc9931790b2c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Menu Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""874fe082-cde4-47dd-99d3-1315d8734aad"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Menu Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d7245edc-f055-4586-9bf1-6993ec7abd8d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Comfirmation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb044919-0265-4bdc-adff-df874b64b837"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3152a024-0ade-47b7-9864-4bf416d01a3c"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""PlayTest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_PressG = m_Player.FindAction("PressG", throwIfNotFound: true);
        m_Player_PressH = m_Player.FindAction("PressH", throwIfNotFound: true);
        m_Player_Echap = m_Player.FindAction("Echap", throwIfNotFound: true);
        // Trapper
        m_Trapper = asset.FindActionMap("Trapper", throwIfNotFound: true);
        m_Trapper_TrapSelection = m_Trapper.FindAction("Trap Selection", throwIfNotFound: true);
        // Neutral
        m_Neutral = asset.FindActionMap("Neutral", throwIfNotFound: true);
        m_Neutral_MenuSelection = m_Neutral.FindAction("Menu Selection", throwIfNotFound: true);
        m_Neutral_Comfirmation = m_Neutral.FindAction("Comfirmation", throwIfNotFound: true);
        m_Neutral_Back = m_Neutral.FindAction("Back", throwIfNotFound: true);
        m_Neutral_PlayTest = m_Neutral.FindAction("PlayTest", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_PressG;
    private readonly InputAction m_Player_PressH;
    private readonly InputAction m_Player_Echap;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @PressG => m_Wrapper.m_Player_PressG;
        public InputAction @PressH => m_Wrapper.m_Player_PressH;
        public InputAction @Echap => m_Wrapper.m_Player_Echap;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @PressG.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressG;
                @PressG.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressG;
                @PressG.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressG;
                @PressH.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressH;
                @PressH.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressH;
                @PressH.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressH;
                @Echap.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEchap;
                @Echap.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEchap;
                @Echap.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEchap;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @PressG.started += instance.OnPressG;
                @PressG.performed += instance.OnPressG;
                @PressG.canceled += instance.OnPressG;
                @PressH.started += instance.OnPressH;
                @PressH.performed += instance.OnPressH;
                @PressH.canceled += instance.OnPressH;
                @Echap.started += instance.OnEchap;
                @Echap.performed += instance.OnEchap;
                @Echap.canceled += instance.OnEchap;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Trapper
    private readonly InputActionMap m_Trapper;
    private ITrapperActions m_TrapperActionsCallbackInterface;
    private readonly InputAction m_Trapper_TrapSelection;
    public struct TrapperActions
    {
        private @PlayerControls m_Wrapper;
        public TrapperActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TrapSelection => m_Wrapper.m_Trapper_TrapSelection;
        public InputActionMap Get() { return m_Wrapper.m_Trapper; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TrapperActions set) { return set.Get(); }
        public void SetCallbacks(ITrapperActions instance)
        {
            if (m_Wrapper.m_TrapperActionsCallbackInterface != null)
            {
                @TrapSelection.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnTrapSelection;
                @TrapSelection.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnTrapSelection;
                @TrapSelection.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnTrapSelection;
            }
            m_Wrapper.m_TrapperActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TrapSelection.started += instance.OnTrapSelection;
                @TrapSelection.performed += instance.OnTrapSelection;
                @TrapSelection.canceled += instance.OnTrapSelection;
            }
        }
    }
    public TrapperActions @Trapper => new TrapperActions(this);

    // Neutral
    private readonly InputActionMap m_Neutral;
    private INeutralActions m_NeutralActionsCallbackInterface;
    private readonly InputAction m_Neutral_MenuSelection;
    private readonly InputAction m_Neutral_Comfirmation;
    private readonly InputAction m_Neutral_Back;
    private readonly InputAction m_Neutral_PlayTest;
    public struct NeutralActions
    {
        private @PlayerControls m_Wrapper;
        public NeutralActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MenuSelection => m_Wrapper.m_Neutral_MenuSelection;
        public InputAction @Comfirmation => m_Wrapper.m_Neutral_Comfirmation;
        public InputAction @Back => m_Wrapper.m_Neutral_Back;
        public InputAction @PlayTest => m_Wrapper.m_Neutral_PlayTest;
        public InputActionMap Get() { return m_Wrapper.m_Neutral; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NeutralActions set) { return set.Get(); }
        public void SetCallbacks(INeutralActions instance)
        {
            if (m_Wrapper.m_NeutralActionsCallbackInterface != null)
            {
                @MenuSelection.started -= m_Wrapper.m_NeutralActionsCallbackInterface.OnMenuSelection;
                @MenuSelection.performed -= m_Wrapper.m_NeutralActionsCallbackInterface.OnMenuSelection;
                @MenuSelection.canceled -= m_Wrapper.m_NeutralActionsCallbackInterface.OnMenuSelection;
                @Comfirmation.started -= m_Wrapper.m_NeutralActionsCallbackInterface.OnComfirmation;
                @Comfirmation.performed -= m_Wrapper.m_NeutralActionsCallbackInterface.OnComfirmation;
                @Comfirmation.canceled -= m_Wrapper.m_NeutralActionsCallbackInterface.OnComfirmation;
                @Back.started -= m_Wrapper.m_NeutralActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_NeutralActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_NeutralActionsCallbackInterface.OnBack;
                @PlayTest.started -= m_Wrapper.m_NeutralActionsCallbackInterface.OnPlayTest;
                @PlayTest.performed -= m_Wrapper.m_NeutralActionsCallbackInterface.OnPlayTest;
                @PlayTest.canceled -= m_Wrapper.m_NeutralActionsCallbackInterface.OnPlayTest;
            }
            m_Wrapper.m_NeutralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MenuSelection.started += instance.OnMenuSelection;
                @MenuSelection.performed += instance.OnMenuSelection;
                @MenuSelection.canceled += instance.OnMenuSelection;
                @Comfirmation.started += instance.OnComfirmation;
                @Comfirmation.performed += instance.OnComfirmation;
                @Comfirmation.canceled += instance.OnComfirmation;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @PlayTest.started += instance.OnPlayTest;
                @PlayTest.performed += instance.OnPlayTest;
                @PlayTest.canceled += instance.OnPlayTest;
            }
        }
    }
    public NeutralActions @Neutral => new NeutralActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPressG(InputAction.CallbackContext context);
        void OnPressH(InputAction.CallbackContext context);
        void OnEchap(InputAction.CallbackContext context);
    }
    public interface ITrapperActions
    {
        void OnTrapSelection(InputAction.CallbackContext context);
    }
    public interface INeutralActions
    {
        void OnMenuSelection(InputAction.CallbackContext context);
        void OnComfirmation(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnPlayTest(InputAction.CallbackContext context);
    }
}
