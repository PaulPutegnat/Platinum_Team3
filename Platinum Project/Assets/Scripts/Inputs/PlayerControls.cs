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
                },
                {
                    ""name"": ""Sliding"",
                    ""type"": ""Button"",
                    ""id"": ""a51c1b86-9d8e-4a76-b007-a49f85c3fc4e"",
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
                    ""groups"": ""Gamepad"",
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
                    ""groups"": ""Gamepad"",
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
                    ""groups"": ""Gamepad"",
                    ""action"": ""Echap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d222977c-5ac1-40c9-b589-3dfbd2101b6f"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sliding"",
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
                },
                {
                    ""name"": ""SlidingBarP1"",
                    ""type"": ""Button"",
                    ""id"": ""027a09cc-7fc8-4d6f-91c6-050bc52e4f06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SlidingBarP2"",
                    ""type"": ""Button"",
                    ""id"": ""a56b8ce7-f54c-47c5-b55c-c45f509fff0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpamQTEP1"",
                    ""type"": ""Button"",
                    ""id"": ""83a0a0a1-9a6c-4117-ac03-4f6b80349fd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpamQTEP2"",
                    ""type"": ""Button"",
                    ""id"": ""43ca17f9-9e23-44ab-b545-b5eab31a3cac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FortuneWheel"",
                    ""type"": ""Button"",
                    ""id"": ""52842daa-391f-4b0e-866f-ea1b5b311a64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimingP1"",
                    ""type"": ""Value"",
                    ""id"": ""387d9ee7-6dc4-4f8c-961f-fcc12c7c01d5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimingP2"",
                    ""type"": ""Value"",
                    ""id"": ""006253db-2618-4b84-8678-9ce9ae21cb44"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootP1"",
                    ""type"": ""Button"",
                    ""id"": ""543e5385-85bf-4a03-a5ea-78f39fffd773"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""ShootP2"",
                    ""type"": ""Button"",
                    ""id"": ""96aa8d67-6e52-474f-a963-2caed415f4af"",
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
                    ""groups"": ""Gamepad"",
                    ""action"": ""Trap Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a9deea7-841d-4ab3-a3ec-48e807001d57"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SpamQTEP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddc24656-7e91-4cc9-81b5-49c74a1e21ca"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SpamQTEP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6979f2b1-4a2f-4bef-8cf9-7220e6835160"",
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
                    ""id"": ""2286dad7-8c92-4ab4-aff1-1ba20cf08fc0"",
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
                    ""id"": ""8791c1b2-7c0a-4d67-9447-ac81b1903551"",
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
                    ""id"": ""624fbdd0-29ba-420b-8ded-075f3cc97c8c"",
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
                    ""id"": ""ec92aa19-0a42-4036-bdba-24ef5a2434cb"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SpamQTEP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb8fe9ec-f080-4b66-a94b-0605130eb22d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SpamQTEP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f6e2d2f-23c4-4192-8dd7-47cdc9aa1153"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""FortuneWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb49a3ce-06d0-4c25-807c-4d03f6485e30"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""FortuneWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1985666-3d43-43fc-8911-3a3beea13ce8"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AimingP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5f1733d-0003-40b1-a57b-c178eaa6fcc2"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShootP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eead13e8-8023-46f5-bbd6-bb245acae1de"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03a9f2a5-0771-4b09-a941-ea83f7e003e9"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""AimingP2"",
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
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""d6d9777d-a9d8-4136-975c-de8651796733"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayTest"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""6e923089-8d17-41b3-8e5b-9d367aad3019"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""4c34d77f-d081-4728-9f8f-8f3ce7d0df74"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""456bb7ce-e5b9-42f9-ad78-2299f1a0b535"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""95d7a002-f74d-43da-be14-fae3e316d009"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""be381822-b1e0-4cd8-83d5-49fcd6b1014d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f6d568b1-aa98-4ee9-add2-5ce242acb1a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c4336ce1-6c72-4f6d-b8bc-e0d98c544b77"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""86925f59-6591-48d4-b42f-35e2bcea17b2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""daf474e7-d9bc-4e42-b6d3-22c48741850b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bac66d4a-53f1-44af-9d1c-173961432e3b"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""13bfa6fd-58da-40a2-b4a1-7f4fdf70f5f0"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""3b367d1d-7e10-481f-96dd-9bbed2091f21"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""67dab250-a157-4ced-a1cf-251226b9971c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""91b99b15-9ff5-456d-9626-843ac2c68a14"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a20e5d03-08d3-401f-90b4-7080c7176158"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e35359c2-0f48-486c-baed-c95368d58ab3"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bf98e638-3c1e-42a2-aaa7-90d87c885a29"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2d153dc3-9eba-4c17-8d31-4e3fc41233dd"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""44888ebb-0b0b-4fc4-8ddd-ce1f0b07aade"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""25a8c3be-42fd-4943-bb10-2df065eee17b"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e52f5904-44fa-4589-be35-260d97a04f4e"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""073b9eea-1705-481a-be69-41cea1ecbb97"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""396d459f-cb20-4cda-ad99-2d4b79aef23f"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6096a4ae-dd50-4325-bf04-37c5452ba2de"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4c5b758e-4093-41e0-9f05-c4004dee7292"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3915a86a-b95c-4748-967b-9f7e89f7d89f"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""493bc46b-0787-4512-bcaa-30a98621c00d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""198f4e85-b007-4f4a-87ca-2c7225a289f4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f84923ff-f837-4d59-972b-21cba280240e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4fb1e047-e26c-4d43-9c7c-9a191b5332a8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ff0ac64a-1ce2-44a6-a0a0-e97a0e58f65b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1f6ee913-a908-41f0-b0a8-12671dcbd768"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f142bde0-16a9-4b96-a27a-853d47a4d916"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9bf114fe-21bc-4a70-a13a-56f680ae77db"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c102bef0-c2c7-45a8-9d52-97018c566d18"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d826b40f-20c6-477f-81e0-25e50799b660"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15129997-ab64-421a-b082-9c192c576b4a"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94574e89-8a74-4925-b72c-f1b3320db9ea"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f0154d2-f287-40dc-ac2a-968e7625624d"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48e7e6a1-c537-427d-8736-d940615530bc"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eda1c497-2536-4cde-82df-6774a543c9e7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""358dc6e0-329c-462a-b6e2-00a60146db6c"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a59b33e-aedc-4ad8-83af-9e2cb26acf9f"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ead256ad-fb11-4c5b-aaa0-5d17788bef94"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c9f108c-712e-40a4-8e44-fc76fe211714"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88306d2c-1363-4d0c-a335-13e78846b2a2"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""133ea99f-25f4-4a7a-9b26-97af4e3090a6"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""012e6c28-e28b-4b9c-b436-151b99d0dee5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8853ddab-dc51-44c4-a772-bb584aa2a85e"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8769e43-143d-4794-bb57-ec6ac4ea47f7"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
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
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_PressG = m_Player.FindAction("PressG", throwIfNotFound: true);
        m_Player_PressH = m_Player.FindAction("PressH", throwIfNotFound: true);
        m_Player_Echap = m_Player.FindAction("Echap", throwIfNotFound: true);
        m_Player_Sliding = m_Player.FindAction("Sliding", throwIfNotFound: true);
        // Trapper
        m_Trapper = asset.FindActionMap("Trapper", throwIfNotFound: true);
        m_Trapper_TrapSelection = m_Trapper.FindAction("Trap Selection", throwIfNotFound: true);
        m_Trapper_SlidingBarP1 = m_Trapper.FindAction("SlidingBarP1", throwIfNotFound: true);
        m_Trapper_SlidingBarP2 = m_Trapper.FindAction("SlidingBarP2", throwIfNotFound: true);
        m_Trapper_SpamQTEP1 = m_Trapper.FindAction("SpamQTEP1", throwIfNotFound: true);
        m_Trapper_SpamQTEP2 = m_Trapper.FindAction("SpamQTEP2", throwIfNotFound: true);
        m_Trapper_FortuneWheel = m_Trapper.FindAction("FortuneWheel", throwIfNotFound: true);
        m_Trapper_AimingP1 = m_Trapper.FindAction("AimingP1", throwIfNotFound: true);
        m_Trapper_AimingP2 = m_Trapper.FindAction("AimingP2", throwIfNotFound: true);
        m_Trapper_ShootP1 = m_Trapper.FindAction("ShootP1", throwIfNotFound: true);
        m_Trapper_ShootP2 = m_Trapper.FindAction("ShootP2", throwIfNotFound: true);
        // Neutral
        m_Neutral = asset.FindActionMap("Neutral", throwIfNotFound: true);
        m_Neutral_MenuSelection = m_Neutral.FindAction("Menu Selection", throwIfNotFound: true);
        m_Neutral_Comfirmation = m_Neutral.FindAction("Comfirmation", throwIfNotFound: true);
        m_Neutral_Back = m_Neutral.FindAction("Back", throwIfNotFound: true);
        m_Neutral_PlayTest = m_Neutral.FindAction("PlayTest", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Sliding;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @PressG => m_Wrapper.m_Player_PressG;
        public InputAction @PressH => m_Wrapper.m_Player_PressH;
        public InputAction @Echap => m_Wrapper.m_Player_Echap;
        public InputAction @Sliding => m_Wrapper.m_Player_Sliding;
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
                @Sliding.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSliding;
                @Sliding.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSliding;
                @Sliding.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSliding;
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
                @Sliding.started += instance.OnSliding;
                @Sliding.performed += instance.OnSliding;
                @Sliding.canceled += instance.OnSliding;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Trapper
    private readonly InputActionMap m_Trapper;
    private ITrapperActions m_TrapperActionsCallbackInterface;
    private readonly InputAction m_Trapper_TrapSelection;
    private readonly InputAction m_Trapper_SlidingBarP1;
    private readonly InputAction m_Trapper_SlidingBarP2;
    private readonly InputAction m_Trapper_SpamQTEP1;
    private readonly InputAction m_Trapper_SpamQTEP2;
    private readonly InputAction m_Trapper_FortuneWheel;
    private readonly InputAction m_Trapper_AimingP1;
    private readonly InputAction m_Trapper_AimingP2;
    private readonly InputAction m_Trapper_ShootP1;
    private readonly InputAction m_Trapper_ShootP2;
    public struct TrapperActions
    {
        private @PlayerControls m_Wrapper;
        public TrapperActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TrapSelection => m_Wrapper.m_Trapper_TrapSelection;
        public InputAction @SlidingBarP1 => m_Wrapper.m_Trapper_SlidingBarP1;
        public InputAction @SlidingBarP2 => m_Wrapper.m_Trapper_SlidingBarP2;
        public InputAction @SpamQTEP1 => m_Wrapper.m_Trapper_SpamQTEP1;
        public InputAction @SpamQTEP2 => m_Wrapper.m_Trapper_SpamQTEP2;
        public InputAction @FortuneWheel => m_Wrapper.m_Trapper_FortuneWheel;
        public InputAction @AimingP1 => m_Wrapper.m_Trapper_AimingP1;
        public InputAction @AimingP2 => m_Wrapper.m_Trapper_AimingP2;
        public InputAction @ShootP1 => m_Wrapper.m_Trapper_ShootP1;
        public InputAction @ShootP2 => m_Wrapper.m_Trapper_ShootP2;
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
                @SlidingBarP1.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSlidingBarP1;
                @SlidingBarP1.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSlidingBarP1;
                @SlidingBarP1.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSlidingBarP1;
                @SlidingBarP2.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSlidingBarP2;
                @SlidingBarP2.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSlidingBarP2;
                @SlidingBarP2.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSlidingBarP2;
                @SpamQTEP1.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSpamQTEP1;
                @SpamQTEP1.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSpamQTEP1;
                @SpamQTEP1.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSpamQTEP1;
                @SpamQTEP2.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSpamQTEP2;
                @SpamQTEP2.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSpamQTEP2;
                @SpamQTEP2.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnSpamQTEP2;
                @FortuneWheel.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnFortuneWheel;
                @FortuneWheel.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnFortuneWheel;
                @FortuneWheel.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnFortuneWheel;
                @AimingP1.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnAimingP1;
                @AimingP1.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnAimingP1;
                @AimingP1.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnAimingP1;
                @AimingP2.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnAimingP2;
                @AimingP2.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnAimingP2;
                @AimingP2.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnAimingP2;
                @ShootP1.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnShootP1;
                @ShootP1.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnShootP1;
                @ShootP1.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnShootP1;
                @ShootP2.started -= m_Wrapper.m_TrapperActionsCallbackInterface.OnShootP2;
                @ShootP2.performed -= m_Wrapper.m_TrapperActionsCallbackInterface.OnShootP2;
                @ShootP2.canceled -= m_Wrapper.m_TrapperActionsCallbackInterface.OnShootP2;
            }
            m_Wrapper.m_TrapperActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TrapSelection.started += instance.OnTrapSelection;
                @TrapSelection.performed += instance.OnTrapSelection;
                @TrapSelection.canceled += instance.OnTrapSelection;
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
                @FortuneWheel.started += instance.OnFortuneWheel;
                @FortuneWheel.performed += instance.OnFortuneWheel;
                @FortuneWheel.canceled += instance.OnFortuneWheel;
                @AimingP1.started += instance.OnAimingP1;
                @AimingP1.performed += instance.OnAimingP1;
                @AimingP1.canceled += instance.OnAimingP1;
                @AimingP2.started += instance.OnAimingP2;
                @AimingP2.performed += instance.OnAimingP2;
                @AimingP2.canceled += instance.OnAimingP2;
                @ShootP1.started += instance.OnShootP1;
                @ShootP1.performed += instance.OnShootP1;
                @ShootP1.canceled += instance.OnShootP1;
                @ShootP2.started += instance.OnShootP2;
                @ShootP2.performed += instance.OnShootP2;
                @ShootP2.canceled += instance.OnShootP2;
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

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPressG(InputAction.CallbackContext context);
        void OnPressH(InputAction.CallbackContext context);
        void OnEchap(InputAction.CallbackContext context);
        void OnSliding(InputAction.CallbackContext context);
    }
    public interface ITrapperActions
    {
        void OnTrapSelection(InputAction.CallbackContext context);
        void OnSlidingBarP1(InputAction.CallbackContext context);
        void OnSlidingBarP2(InputAction.CallbackContext context);
        void OnSpamQTEP1(InputAction.CallbackContext context);
        void OnSpamQTEP2(InputAction.CallbackContext context);
        void OnFortuneWheel(InputAction.CallbackContext context);
        void OnAimingP1(InputAction.CallbackContext context);
        void OnAimingP2(InputAction.CallbackContext context);
        void OnShootP1(InputAction.CallbackContext context);
        void OnShootP2(InputAction.CallbackContext context);
    }
    public interface INeutralActions
    {
        void OnMenuSelection(InputAction.CallbackContext context);
        void OnComfirmation(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnPlayTest(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
    }
}
