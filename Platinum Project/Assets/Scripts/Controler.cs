using UnityEngine;
using UnityEngine.InputSystem;

public class Controler : MonoBehaviour
{
    public float movementSpeed = 6;
    float distToGround;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Vector2 MovementInput = Vector2.zero;
    private Rigidbody _rigidbody;

    bool jump;

    // Mouvements
    public void OnMove(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
    }

    // Saut

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
        distToGround = GetComponent<BoxCollider>().bounds.extents.y;
    }
    void Update()
    {
        // Mouvements du personnage

        var movement = MovementInput.x;
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        Debug.Log(IsGrounded());
        if (jump && IsGrounded())
        {
            Debug.Log("jump");
            _rigidbody.AddForce(new Vector3(0, 100,0));
        }
        //Debug.DrawLine(transform.position, /*transform.position + */(-Vector3.up * distToGround),Color.red);

        // Rotation du personnage

        Vector3 direction = new Vector3(movement, 0f, 0f).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(gameObject.transform.position - Vector3.up * (distToGround + 0.1f), -Vector3.up, 0.1f);
    }
   private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (-Vector3.up * distToGround));
    }
}
