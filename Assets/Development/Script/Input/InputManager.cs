using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public bool JumpPressed { get; private set; }
    public bool Attack1Pressed { get; private set; }
    public bool Attack2Pressed { get; private set; }
    public bool InteractPressed { get; private set; }
    public bool PausePressed { get; private set; }


    public static InputManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        MovementInput();
        JumpInput();
        AttackInput();
        InteractInput(); 
        PauseInput();

    }

    private void MovementInput()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void JumpInput()
    {
        JumpPressed = Input.GetKeyDown(KeyCode.Space);
    }

    private void AttackInput()
    {
        if (IsClickingOnUI())
        {
            Attack1Pressed = false;
            Attack2Pressed = false;
            return;
        }

        Attack1Pressed = Input.GetMouseButtonDown(0);
        Attack2Pressed = Input.GetMouseButtonDown(1);
    }
    private void InteractInput()
    {
        InteractPressed = Input.GetKeyDown(KeyCode.E);
    }
    private void PauseInput()
    {
        PausePressed = Input.GetKeyDown(KeyCode.P);
    }
    private bool IsClickingOnUI()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }
}
