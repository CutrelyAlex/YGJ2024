using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInteractSystem : MonoBehaviour
{
    private InputSystem_Actions action;
    public GameObject onClickGameObject;
    public string InterableTag;
    private void Start()
    {
        action = new InputSystem_Actions();
        action.Gameplay.Mouse.performed += context =>
        {
            onClickGameObject = ClickGameObject();
        };
        action.Gameplay.Enable();  // 启用输入动作映射
    }

    private void Update()
    {
        if (onClickGameObject != null && onClickGameObject.CompareTag(InterableTag))
        {
            onClickGameObject.SendMessage("Interact");
            onClickGameObject = null;
        }
    }

    GameObject ClickGameObject()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}
