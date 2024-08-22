using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    InputSystem_Actions action;
    Rigidbody2D rb;
    Vector2 moveDirection;
    private void Start()
    {
        InitAction();
        rb = GetComponent<Rigidbody2D>();
    }
    void InitAction()
    {
        action = new InputSystem_Actions();
        action.Gameplay.Move.performed += context =>
        {
            moveDirection = context.ReadValue<Vector2>();
        };
        action.Gameplay.Move.canceled += context =>
        {
            moveDirection = Vector2.zero;
        };
        action.Enable();
    }

    private void FixedUpdate()
    {
        MoveTo(moveDirection.x);
    }


    private void MoveTo(float x)
    {
        rb.linearVelocityX = x * speed;
    }
}
