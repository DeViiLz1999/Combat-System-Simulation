//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/InputSystem/PlayerControls.inputactions
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

public partial class @PlayerControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player actions"",
            ""id"": ""4f9a4ce8-6bbd-42bf-a3c8-b5b7877f9437"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""20a9d1e5-241b-4a51-a71d-fe3280d2320f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b0697116-bb9d-4bbc-887c-cd77ab891f4d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c400fccf-08e9-47b1-96f6-67e87a83eddc"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8150f4a3-dea7-43b7-8fcd-c3df0036342f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""faf65b38-9012-4057-a8b5-ff15e5eecf43"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""172da008-7a1d-4735-ad5d-33767551b63b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d686a1f2-6ec8-4245-b817-879344ad7ad0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8f2327e1-09a0-4585-9d4c-79be896ff966"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38e9488e-2535-4185-9daa-fce3b8c4338c"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""251d95ae-556c-46bc-820c-85f6c56075a0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player controls"",
            ""id"": ""0cba58a0-8c34-4ccb-be10-9bacf75d8934"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""e943f415-5cc7-4470-9810-ec795cb9a2ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""SlowTap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LightAttack"",
                    ""type"": ""Button"",
                    ""id"": ""eba5c73e-4025-4059-912a-2c65ff5aa3ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HeavyAttack"",
                    ""type"": ""Button"",
                    ""id"": ""ccfb4401-859d-471e-aa19-174824460a5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c9547d70-ec85-4f05-949b-2186cd6947cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""d090e3a8-2073-49a9-9eca-6b20c63ca59c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Block"",
                    ""type"": ""Button"",
                    ""id"": ""b7dcb73e-85b2-466b-8e8f-16fef2b0ffe6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Taunt"",
                    ""type"": ""Button"",
                    ""id"": ""66c504b4-afa9-4649-b077-76d7e7d4f03a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""73f98911-bf79-4266-911b-cb53a5574d97"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3df01aee-def4-4ddd-956a-352c5156d1ab"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d5d3f3e-3941-4d3d-82eb-46cad219e1af"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71a96066-2afa-40b2-afcf-d371af6a660c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LightAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c25b268a-9add-41a9-93d2-1d6c161914e7"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e8d8f1d-ee81-472d-8e2f-15ff0389dba7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aeff49eb-5c36-48eb-a89b-d8dec7ceb574"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdaa15e9-4499-4d51-b50a-47e2b20b8353"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f74d5d1-2575-44c2-9fe3-5a8a266aa02e"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1863c633-6b8e-48df-ba56-ff1720167000"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdff23a1-c420-4820-bd5c-6c6b4d0d04f1"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fae809d6-6d64-48aa-84b2-f4f7b4bc1234"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Block"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abefc392-79c2-4beb-b6be-794e3f1ac664"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Taunt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8cba0d0-0b06-4c77-b714-6d60d5d5a07e"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Taunt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player actions
        m_Playeractions = asset.FindActionMap("Player actions", throwIfNotFound: true);
        m_Playeractions_Move = m_Playeractions.FindAction("Move", throwIfNotFound: true);
        m_Playeractions_Look = m_Playeractions.FindAction("Look", throwIfNotFound: true);
        // Player controls
        m_Playercontrols = asset.FindActionMap("Player controls", throwIfNotFound: true);
        m_Playercontrols_Roll = m_Playercontrols.FindAction("Roll", throwIfNotFound: true);
        m_Playercontrols_LightAttack = m_Playercontrols.FindAction("LightAttack", throwIfNotFound: true);
        m_Playercontrols_HeavyAttack = m_Playercontrols.FindAction("HeavyAttack", throwIfNotFound: true);
        m_Playercontrols_Jump = m_Playercontrols.FindAction("Jump", throwIfNotFound: true);
        m_Playercontrols_LockOn = m_Playercontrols.FindAction("LockOn", throwIfNotFound: true);
        m_Playercontrols_Block = m_Playercontrols.FindAction("Block", throwIfNotFound: true);
        m_Playercontrols_Taunt = m_Playercontrols.FindAction("Taunt", throwIfNotFound: true);
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

    // Player actions
    private readonly InputActionMap m_Playeractions;
    private IPlayeractionsActions m_PlayeractionsActionsCallbackInterface;
    private readonly InputAction m_Playeractions_Move;
    private readonly InputAction m_Playeractions_Look;
    public struct PlayeractionsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayeractionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Playeractions_Move;
        public InputAction @Look => m_Wrapper.m_Playeractions_Look;
        public InputActionMap Get() { return m_Wrapper.m_Playeractions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayeractionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayeractionsActions instance)
        {
            if (m_Wrapper.m_PlayeractionsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayeractionsActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_PlayeractionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public PlayeractionsActions @Playeractions => new PlayeractionsActions(this);

    // Player controls
    private readonly InputActionMap m_Playercontrols;
    private IPlayercontrolsActions m_PlayercontrolsActionsCallbackInterface;
    private readonly InputAction m_Playercontrols_Roll;
    private readonly InputAction m_Playercontrols_LightAttack;
    private readonly InputAction m_Playercontrols_HeavyAttack;
    private readonly InputAction m_Playercontrols_Jump;
    private readonly InputAction m_Playercontrols_LockOn;
    private readonly InputAction m_Playercontrols_Block;
    private readonly InputAction m_Playercontrols_Taunt;
    public struct PlayercontrolsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayercontrolsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_Playercontrols_Roll;
        public InputAction @LightAttack => m_Wrapper.m_Playercontrols_LightAttack;
        public InputAction @HeavyAttack => m_Wrapper.m_Playercontrols_HeavyAttack;
        public InputAction @Jump => m_Wrapper.m_Playercontrols_Jump;
        public InputAction @LockOn => m_Wrapper.m_Playercontrols_LockOn;
        public InputAction @Block => m_Wrapper.m_Playercontrols_Block;
        public InputAction @Taunt => m_Wrapper.m_Playercontrols_Taunt;
        public InputActionMap Get() { return m_Wrapper.m_Playercontrols; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayercontrolsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayercontrolsActions instance)
        {
            if (m_Wrapper.m_PlayercontrolsActionsCallbackInterface != null)
            {
                @Roll.started -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnRoll;
                @LightAttack.started -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnLightAttack;
                @LightAttack.performed -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnLightAttack;
                @LightAttack.canceled -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnLightAttack;
                @HeavyAttack.started -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.performed -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.canceled -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnHeavyAttack;
                @Jump.started -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnJump;
                @LockOn.started -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnLockOn;
                @Block.started -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnBlock;
                @Block.performed -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnBlock;
                @Block.canceled -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnBlock;
                @Taunt.started -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnTaunt;
                @Taunt.performed -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnTaunt;
                @Taunt.canceled -= m_Wrapper.m_PlayercontrolsActionsCallbackInterface.OnTaunt;
            }
            m_Wrapper.m_PlayercontrolsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @LightAttack.started += instance.OnLightAttack;
                @LightAttack.performed += instance.OnLightAttack;
                @LightAttack.canceled += instance.OnLightAttack;
                @HeavyAttack.started += instance.OnHeavyAttack;
                @HeavyAttack.performed += instance.OnHeavyAttack;
                @HeavyAttack.canceled += instance.OnHeavyAttack;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @Block.started += instance.OnBlock;
                @Block.performed += instance.OnBlock;
                @Block.canceled += instance.OnBlock;
                @Taunt.started += instance.OnTaunt;
                @Taunt.performed += instance.OnTaunt;
                @Taunt.canceled += instance.OnTaunt;
            }
        }
    }
    public PlayercontrolsActions @Playercontrols => new PlayercontrolsActions(this);
    public interface IPlayeractionsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IPlayercontrolsActions
    {
        void OnRoll(InputAction.CallbackContext context);
        void OnLightAttack(InputAction.CallbackContext context);
        void OnHeavyAttack(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnBlock(InputAction.CallbackContext context);
        void OnTaunt(InputAction.CallbackContext context);
    }
}
