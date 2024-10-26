using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;
    private PlayerInputHandler inputHandler;

    public float speed = 5.0f;
    public float runMultiplier = 2.0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(inputHandler.moveInput.x, 0, inputHandler.moveInput.y);
        controller.Move(move * Time.deltaTime * speed * (inputHandler.isRunning ? runMultiplier : 1));

        if (inputHandler.jump && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            inputHandler.jump = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}

