using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputActions inputActions;
    public Vector2 moveInput;
    public bool isRunning;
    public bool jump;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Run.performed += context => isRunning = true;
        inputActions.Player.Run.canceled += context => isRunning = false;
        inputActions.Player.Jump.performed += context => jump = true;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


