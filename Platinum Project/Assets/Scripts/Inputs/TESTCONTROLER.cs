using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class TESTCONTROLER : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 6;
    public float jumpForce = 30;

    [Range(0.2f, 1f)]
    public float JumpCheckLength;

    [SerializeField]
    [Range(0.6f, 1f)]
    float neutralJumpForce;

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

    [Range(0.1f, 0.3f)]
    public float Initial_CT;

    float CT;
    public float GravMultiplier;

    [Range(1f, 3f)]
    public float airControlDiviser;


    [Header("Slide")]
    public bool Slide;
    private bool UnderObjectLastFrame = false;

    [Range(1f,3f)]
    public float SlidingUnderBoost;

    [Range(25f, 75f)]
    public float BrakeForceAfterSlidingUnder;



    private bool IsLocked = false;
    private float SlideVelocityLastFrame;
    private float VelocityXLastFrame;
    private float VelocityYLastFrame;
    bool HasChangedDirection = false;
    private BoxCollider box;
    private Vector3 InitialSize;

    private Animator animatotor;

    public ParticleSystem dustParticleSystem;
    public ParticleSystem JumpParticleSystem;

    private void Awake()
    {
        
        _rigidbody = GetComponent<Rigidbody>();
        animatotor = GetComponentInChildren<Animator>();
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
            dustParticleSystem.enableEmission = true;
            
            CT = Initial_CT;
            HasChangedDirection = false;
        }
        else
        {
            dustParticleSystem.enableEmission = false;
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
             float InertyMultiplier = Mathf.Clamp(Mathf.Abs(_rigidbody.velocity.x) / maxspeed, neutralJumpForce, 1) ;
             JumpParticleSystem.Play();
             _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce* InertyMultiplier, 0);
             CT = 0;
         }

         if (_rigidbody.velocity.y < 0)
         {
             _rigidbody.velocity += new Vector3(0, -GravMultiplier, 0);
         }



        if (Slide)
        {
            animatotor.SetBool("IsSliding", true);
            float InitialDeceleration = 1.025f;
            float SlideDeceleration = 1f + BrakeForceAfterSlidingUnder/1000;

            if (Mathf.Abs(SlideVelocityLastFrame) > 4f)
            {
                _rigidbody.velocity = new Vector3(SlideVelocityLastFrame, _rigidbody.velocity.y, 0);
                box.center = new Vector3(0, 0.5f, 0);
                box.size = new Vector3(InitialSize.x, InitialSize.y / 2, InitialSize.z);
                

                if (!IsSlidingUnder())
                {
                    if (UnderObjectLastFrame)
                    {
                        SlideVelocityLastFrame /= SlideDeceleration;
                    }
                    else
                    {
                        SlideVelocityLastFrame /= InitialDeceleration;
                    }

                }
                else
                {
                    _rigidbody.velocity = new Vector3(SlideVelocityLastFrame * SlidingUnderBoost, 0, 0);
                    UnderObjectLastFrame = true;
                }


            }
            else
            {
                ResetSlide();
                _rigidbody.velocity = new Vector3(0,0,0);
                SlideVelocityLastFrame = 0f;

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

        animatotor.SetFloat("Velocity",Mathf.Abs(_rigidbody.velocity.x));
        animatotor.SetBool("IsGrounded", IsGrounded());

        //C'est moche mais j'en ai rien à foutre
        animatotor.gameObject.transform.rotation = new Quaternion(0,0,0,0);
        animatotor.gameObject.transform.localPosition = new Vector3(0,0.5f,0);
        VelocityYLastFrame = _rigidbody.velocity.y;


    }

    public void ResetSlide()
    {
        animatotor.SetBool("IsSliding", false);
        Slide = false;
        IsLocked = false;
        UnderObjectLastFrame = false;
        box.center = new Vector3(0, 1, 0);
        box.size = InitialSize;
        
    }
    bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position /*- (Vector3.up * _distToGround)*/, -Vector3.up, JumpCheckLength);
    }

    bool IsSlidingUnder()
    {
        Vector3 origin = gameObject.transform.position + Vector3.up * (GetComponent<BoxCollider>().bounds.extents.y);
        return Physics.Raycast(origin, Vector3.up,3f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (-Vector3.up * (_distToGround + JumpCheckLength)));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine( transform.position + Vector3.up * (GetComponent<BoxCollider>().bounds.extents.y), transform.position + Vector3.up * (GetComponent<BoxCollider>().bounds.extents.y) + Vector3.up * 3);
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
                _movementInput = context.ReadValue<Vector2>() / airControlDiviser;
            }
        }



    }
    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.action.triggered;

    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (!IsLocked && IsGrounded())
        {
        Slide = context.ReadValueAsButton();
        SlideVelocityLastFrame = _rigidbody.velocity.x;
        IsLocked = true;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (IsGrounded() && VelocityYLastFrame < -30)
        {
            //PLAY SOUND
            JumpParticleSystem.Play();
            Debug.Log("play sound");
        }
    }
}

