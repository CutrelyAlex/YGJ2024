using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    InputSystem_Actions action;
    Vector2 moveDirection;

    public bool engineOn = true;
    public bool stoping;
    public bool speeding;
    public float acceleration; // X轴加速度
    public float stopAcceleration; // X轴减速度
    public float Yacceleration; // Y轴加速度
    public float maxSpeed;
    public Vector2 currentVector;
    public Vector2 targetVector;

    private void Start()
    {
        InitAction();
        rb = GetComponent<Rigidbody2D>();
    }

    void InitAction()
    {
        action = new InputSystem_Actions();

        // 移动输入处理（油门）
        action.Gameplay.Move.performed += context =>
        {
            speeding = true;
            moveDirection = context.ReadValue<Vector2>();
        };

        action.Gameplay.Move.canceled += context =>
        {
            speeding = false;
            moveDirection = Vector2.zero;
        };

        // 刹车输入处理
        action.Gameplay.Brake.performed += context =>
        {
            stoping = true;
        };

        action.Gameplay.Brake.canceled += context =>
        {
            stoping = false;
        };

        action.Enable();
    }

    private void FixedUpdate()
    {
        if (engineOn)
        {
            CarMove();
        }
    }

    void CarMove()
    {
        Vector2 newVelocity = currentVector;

        // X轴加速或减速逻辑
        if (speeding)
        {
            targetVector.x = moveDirection.x * maxSpeed;
            newVelocity.x = Mathf.Lerp(currentVector.x, targetVector.x, acceleration * Time.fixedDeltaTime);
        }

        if (stoping)
        {
            newVelocity.x = Mathf.Lerp(newVelocity.x, 0, stopAcceleration * Time.fixedDeltaTime);
        }

        // Y轴加速逻辑
        targetVector.y = moveDirection.y * maxSpeed;
        newVelocity.y = Mathf.Lerp(currentVector.y, targetVector.y, Yacceleration * Time.fixedDeltaTime);

        // 更新当前速度
        currentVector = newVelocity;
        rb.linearVelocity = currentVector;
    }
}
