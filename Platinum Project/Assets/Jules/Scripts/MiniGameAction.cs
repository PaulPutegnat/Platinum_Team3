// GENERATED AUTOMATICALLY FROM 'Assets/Jules/Scripts/MiniGameAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MiniGameAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MiniGameAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MiniGameAction"",
    ""maps"": [
        {
            ""name"": ""MiniGame"",
            ""id"": ""a57a313c-96b4-4f09-8db5-63f7c43bb9b4"",
            ""actions"": [
                {
                    ""name"": ""SlidingBarP1"",
                    ""type"": ""Button"",
                    ""id"": ""11e6ffb5-b1ce-4658-869f-ef5c32760261"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlidingBarP2"",
                    ""type"": ""Button"",
                    ""id"": ""3f06103b-5ec3-445f-baeb-6966e12c8c06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpamQTEP1"",
                    ""type"": ""Button"",
                    ""id"": ""691cf0f1-c54e-457c-af94-e5c0e3c25ced"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpamQTEP2"",
                    ""type"": ""Button"",
                    ""id"": ""0e06671f-9ad8-4079-a780-0873a035eb20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2b1f76d1-6015-4089-99fe-4fc259cfae4b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlidingBarP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d32f99e-7ddb-48f5-aca8-c60c41537d1a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlidingBarP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0b20ee6-4d1f-4d05-8923-76563b8370b3"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlidingBarP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0714bad-7f96-4056-ae8c-35a3811b3bae"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlidingBarP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cc53fe4-def0-4fa1-a139-1b5a2e2ce7cf"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpamQTEP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5cbabd9-7fbe-4e19-82b2-5b7d919d7146"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpamQTEP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7dade3d-2be3-4e18-8c5e-b50406cc4dd5"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpamQTEP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a305e3b1-8ae6-44ba-b4b0-b9fba07f2823"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpamQTEP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MiniGame
        m_MiniGame = asset.FindActionMap("MiniGame", throwIfNotFound: true);
        m_MiniGame_SlidingBarP1 = m_MiniGame.FindAction("SlidingBarP1", throwIfNotFound: true);
        m_MiniGame_SlidingBarP2 = m_MiniGame.FindAction("SlidingBarP2", throwIfNotFound: true);
        m_MiniGame_SpamQTEP1 = m_MiniGame.FindAction("SpamQTEP1", throwIfNotFound: true);
        m_MiniGame_SpamQTEP2 = m_MiniGame.FindAction("SpamQTEP2", throwIfNotFound: true);
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

    // MiniGame
    private readonly InputActionMap m_MiniGame;
    private IMiniGameActions m_MiniGameActionsCallbackInterface;
    private readonly InputAction m_MiniGame_SlidingBarP1;
    private readonly InputAction m_MiniGame_SlidingBarP2;
    private readonly InputAction m_MiniGame_SpamQTEP1;
    private readonly InputAction m_MiniGame_SpamQTEP2;
    public struct MiniGameActions
    {
        private @MiniGameAction m_Wrapper;
        public MiniGameActions(@MiniGameAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @SlidingBarP1 => m_Wrapper.m_MiniGame_SlidingBarP1;
        public InputAction @SlidingBarP2 => m_Wrapper.m_MiniGame_SlidingBarP2;
        public InputAction @SpamQTEP1 => m_Wrapper.m_MiniGame_SpamQTEP1;
        public InputAction @SpamQTEP2 => m_Wrapper.m_MiniGame_SpamQTEP2;
        public InputActionMap Get() { return m_Wrapper.m_MiniGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MiniGameActions set) { return set.Get(); }
        public void SetCallbacks(IMiniGameActions instance)
        {
            if (m_Wrapper.m_MiniGameActionsCallbackInterface != null)
            {
                @SlidingBarP1.started -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSlidingBarP1;
                @SlidingBarP1.performed -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSlidingBarP1;
                @SlidingBarP1.canceled -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSlidingBarP1;
                @SlidingBarP2.started -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSlidingBarP2;
                @SlidingBarP2.performed -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSlidingBarP2;
                @SlidingBarP2.canceled -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSlidingBarP2;
                @SpamQTEP1.started -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSpamQTEP1;
                @SpamQTEP1.performed -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSpamQTEP1;
                @SpamQTEP1.canceled -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSpamQTEP1;
                @SpamQTEP2.started -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSpamQTEP2;
                @SpamQTEP2.performed -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSpamQTEP2;
                @SpamQTEP2.canceled -= m_Wrapper.m_MiniGameActionsCallbackInterface.OnSpamQTEP2;
            }
            m_Wrapper.m_MiniGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SlidingBarP1.started += instance.OnSlidingBarP1;
                @SlidingBarP1.performed += instance.OnSlidingBarP1;
                @SlidingBarP1.canceled += instance.OnSlidingBarP1;
                @SlidingBarP2.started += instance.OnSlidingBarP2;
                @SlidingBarP2.performed += instance.OnSlidingBarP2;
                @SlidingBarP2.canceled += instance.OnSlidingBarP2;
                @SpamQTEP1.started += instance.OnSpamQTEP1;
                @SpamQTEP1.performed += instance.OnSpamQTEP1;
                @SpamQTEP1.canceled += instance.OnSpamQTEP1;
                @SpamQTEP2.started += instance.OnSpamQTEP2;
                @SpamQTEP2.performed += instance.OnSpamQTEP2;
                @SpamQTEP2.canceled += instance.OnSpamQTEP2;
            }
        }
    }
    public MiniGameActions @MiniGame => new MiniGameActions(this);
    public interface IMiniGameActions
    {
        void OnSlidingBarP1(InputAction.CallbackContext context);
        void OnSlidingBarP2(InputAction.CallbackContext context);
        void OnSpamQTEP1(InputAction.CallbackContext context);
        void OnSpamQTEP2(InputAction.CallbackContext context);
    }
}
