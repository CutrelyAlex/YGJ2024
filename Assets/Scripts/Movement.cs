using UnityEngine;

public class Movement : Singleton<Movement>
{
    Rigidbody2D rb;
    InputSystem_Actions action;
    Vector2 moveDirection;

    public bool engineOn;
    public bool braking;
    public bool stoping;
    public bool speeding;
    public float acceleration; // X轴加速度
    public float stopAcceleration; // X轴减速度
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
        // action = new InputSystem_Actions();
        action = InputSystem.Instance.action;
        // 移动输入处理（油门）
        action.Gameplay.Move.performed += context =>
        {
            if (engineOn)
            {
                speeding = true;
                moveDirection = context.ReadValue<Vector2>();
            }
        };

        action.Gameplay.Move.canceled += context =>
        {
            if (engineOn)
            {
                speeding = false;
                moveDirection = Vector2.zero;
            }
        };

        // 刹车输入处理
        action.Gameplay.Brake.performed += context =>
        {
            if (engineOn)
            {
                stoping = true;
                braking = true;
            }
        };

        action.Gameplay.Brake.canceled += context =>
        {
            if (engineOn)
            {
                stoping = false;
                braking = false;
            }
        };

        // 油门启动
        action.Gameplay.Engine.performed += context =>
        {
            if(engineOn)
            {
                engineOn = false;
                stoping = true;
                speeding = false ;
            }
            else
            {
                engineOn = true;
                stoping = false;
            }
        };
    }

    private void FixedUpdate()
    {
        CarMove();
    }

    void CarMove()
    {
        Vector2 newVelocity = currentVector;

        // X轴加速或减速逻辑
        if (speeding && engineOn)
        {
            // 根据车头方向计算加速度方向
            Vector2 forwardDirection = transform.right; // 使用车头方向
            targetVector = forwardDirection * moveDirection.x * maxSpeed;
            newVelocity = Vector2.Lerp(currentVector, targetVector, acceleration * Time.fixedDeltaTime);
        }


        if (stoping)
        {
            newVelocity.x = Mathf.Lerp(newVelocity.x, 0, stopAcceleration * Time.fixedDeltaTime);
        }

        // 更新当前速度
        currentVector = newVelocity;
        rb.linearVelocity = currentVector;
    }
}
