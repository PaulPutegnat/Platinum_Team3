using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controler : MonoBehaviour
{
    public float movementSpeed = 6;
    public float jumpForce = 30; 
    float _distToGround;
    public float turnSmoothTime = 0.1f;
    float _turnSmoothVelocity;

    public Vector2 _movementInput = Vector2.zero;
    private Rigidbody _rigidbody;
    private float _acceleration;
    public float Accel;
    

    [Header("Coyote Time")]
    public bool jump;
    public float Initial_CT;
    float CT;
    public float GravMultiplier;

    //Mouvements
    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    //Saut

    public void OnJump(InputAction.CallbackContext context)
    {
        jump = context.action.triggered;
        
    }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _distToGround = GetComponent<BoxCollider>().bounds.extents.y;
    }
    void Update()
    {
        
        /*//Mouvements du personnage

          var movement = _movementInput.x;
        if (_movementInput.x < 0.1 && _movementInput.x > -0.1)
        {
            _movementInput.x = 0f;
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x / 2, _rigidbody.velocity.y, _rigidbody.velocity.z);

        }

        if (movement != 0)
        {
            _acceleration += Accel*Time.deltaTime;
            _acceleration = Mathf.Clamp(_acceleration, 0,1f);
            Debug.Log(_acceleration);
        }
        else
        {
            _acceleration = 0f;
        }

        _rigidbody.velocity = new Vector3(movement * (Time.deltaTime * (movementSpeed * _acceleration)) , _rigidbody.velocity.y, 0);


        //JUMP
        if (IsGrounded())
        {
            CT = Initial_CT;
        }
        else
        {
            CT -= Time.deltaTime;
        }

        if (jump && (IsGrounded() || CT > 0))
        {
            //Vector2.up * Physics.gravity.y * (fallMultiplierFloat - 1) * Time.deltaTime;
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce, 0);
            CT = 0;
        }

        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += new Vector3(0,Physics.gravity.y*GravMultiplier*Time.deltaTime,0);
        }



        //Debug.DrawLine(transform.position, /*transform.position + (-Vector3.up * _distToGround),Color.red);

        // Rotation du personnage

        Vector3 direction = new Vector3(movement, 0f, 0f).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }*/
    }

    private void FixedUpdate()
    {
        //Mouvements du personnage

        var movement = _movementInput.x;
        if (_movementInput.x < 0.1 && _movementInput.x > -0.1)
        {
            _movementInput.x = 0f;
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x / 2, _rigidbody.velocity.y, _rigidbody.velocity.z);

        }

        if (movement != 0)
        {
            _acceleration += Accel;
            _acceleration = Mathf.Clamp(_acceleration, 0, 1f);
            // Debug.Log(_acceleration);
        }
        else
        {
            _acceleration = 0f;
        }

        _rigidbody.velocity = new Vector3(movement * ((movementSpeed * _acceleration)), _rigidbody.velocity.y, 0);


        //JUMP
        if (IsGrounded())
        {
            CT = Initial_CT;
        }
        else
        {
            CT -= Time.deltaTime;
        }

        if (jump && (IsGrounded() || CT > 0))
        {
            //Vector2.up * Physics.gravity.y * (fallMultiplierFloat - 1) * Time.deltaTime;
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, jumpForce, 0);
            CT = 0;
        }

        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += new Vector3(0, -GravMultiplier, 0);
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

}
