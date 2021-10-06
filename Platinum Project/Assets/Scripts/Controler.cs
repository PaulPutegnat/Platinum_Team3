
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Controler : MonoBehaviour
{
    CharacterController controller;

    public float movementSpeed = 6;
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
        controller = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Mouvements du personnage

        var movement = MovementInput.x;
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if (jump)
        {
            _rigidbody.AddForce(new Vector3(0, 10,0));
        }

        // Rotation du personnage

        Vector3 direction = new Vector3(movement, 0f, 0f).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
}
