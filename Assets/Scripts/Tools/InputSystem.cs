using UnityEngine;

public class InputSystem : Singleton<InputSystem>
{
    public InputSystem_Actions action;
    protected override void Awake()
    {
        base.Awake();
        action = new InputSystem_Actions();
        action.Enable();
    }

    void Update()
    {
        
    }
}
