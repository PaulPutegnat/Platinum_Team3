using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class TESTCONTROLER : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 6;
    public float jumpForce = 30;
    float _distToGround;
    public float turnSmoothTime = 0.1f;
    float _turnSmoothVelocity;

    [HideInInspector]
    public Vector2 _movementInput = Vector2.zero;



    private Rigidbody _rigidbody;
    private float _acceleration;

    [Range(0.0f, 3f)]
    public float maxspeed;

    [Range(0.0f, 3f)]
    public float Accel;

    [SerializeField] private float deadZoneController = 0.1f;

    [Header("Coyote Time")]
    public bool jump;
    public float Initial_CT;
    float CT;
    public float GravMultiplier;

    [Range(1f, 3f)]
    public float airControlDiviser;

    private bool Slide;
    private bool IsLocked = false;
    private float VelocityYLastFrame;
    private float VelocityXLastFrame;
    [SerializeField]bool HasChangedDirection = false;
    private BoxCollider box;
    private Vector3 InitialSize;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Console.Clear();
    }
    private void Start()
    {
        _distToGround = GetComponent<BoxCollider>().bounds.extents.y;
        box = GetComponent<BoxCollider>();
        InitialSize = box.size;
    }

    private void FixedUpdate()
    {
        //Mouvements du personnage

        var movement = _movementInput.x;

        //JUMP
        if (IsGrounded())
        {
            CT = Initial_CT;
            HasChangedDirection = false;
        }
        else
        {
            CT -= Time.deltaTime;

            if ((VelocityXLastFrame >= 0 && movement <= 0) || (VelocityXLastFrame <= 0 && movement >= 0))
            {
                HasChangedDirection = true;
            }
        }

       
       
        if (_movementInput.x < deadZoneController && _movementInput.x > -deadZoneController)
        {
            _movementInput.x = 0f;
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x / 2, _rigidbody.velocity.y, _rigidbody.velocity.z);
        }

        if (movement != 0)
        {
            _acceleration += Accel;
            _acceleration = Mathf.Clamp(_acceleration,0, maxspeed);

        }
        else
        {
            _acceleration = 0f;
        }

        _rigidbody.velocity = new Vector3(movement * ((movementSpeed * _acceleration)), _rigidbody.velocity.y, 0);

         if (jump && (IsGrounded() || CT > 0))
         { 
             //Vector2.up * Physics.gravity.y * (fallMultiplierFloat - 1) * Time.deltaTime;
             float InertyMultiplier = Mathf.Clamp(Mathf.Abs(_rigidbody.velocity.x) / maxspeed, 0.6f, 1) ;
             _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce* InertyMultiplier, 0);
             CT = 0;
         }

         if (_rigidbody.velocity.y < 0)
         {
             _rigidbody.velocity += new Vector3(0, -GravMultiplier, 0);
         }



        if (Slide)
        {
            if (Mathf.Abs(VelocityYLastFrame) > 4f)
            {
                _rigidbody.velocity = new Vector3(VelocityYLastFrame, 0, 0);
                box.size = new Vector3(box.size.x, box.size.y / 2, box.size.z);
                
                VelocityYLastFrame /= 1.02f;
            }
            else
            {
                _rigidbody.velocity = new Vector3(0,0,0);
                VelocityYLastFrame = 0f;
                Slide = false;
                IsLocked = false;
                box.size = InitialSize;
            }

        }

        //Debug.DrawLine(transform.position, /*transform.position + */(-Vector3.up * _distToGround),Color.red);

        // Rotation du personnage

        Vector3 direction = new Vector3(movement, 0f, 0f).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        jump = false;
        VelocityXLastFrame = _rigidbody.velocity.x;
    }

    bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position - Vector3.up * (_distToGround + 0.1f), -Vector3.up, 0.1f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (-Vector3.up * _distToGround));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        _movementInput = Vector2.zero;
        if (!IsLocked)
        {
            if (!HasChangedDirection)
            {
                _movementInput = context.ReadValue<Vector2>();
            }
            else
            {
                _movementInput = context.ReadValue<Vector2>() * airControlDiviser;
            }
        }



    }
    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.action.triggered;

    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (!IsLocked)
        {
        Slide = context.ReadValueAsButton();
        VelocityYLastFrame = _rigidbody.velocity.x;
        IsLocked = true;
        }

    }

}

