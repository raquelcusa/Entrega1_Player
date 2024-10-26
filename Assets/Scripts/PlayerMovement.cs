using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public float maxJumpTime = 0.5f;
    public float additionalJumpForce = 2f;
    public float rotationSpeed ; // Controla la velocidad de giro del jugador
    public Transform cameraTransform; // Referencia a la c�mara del jugador

    private bool isGrounded;
    private bool isJumping;
    private float jumpTimeCounter;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (cameraTransform == null)
        {
            cameraTransform = transform.Find("Camera");
        }
    }

    void Update()
    {
        // Obt�n la entrada de movimiento
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        // Movimiento en la direcci�n de la c�mara
        Vector3 direction = (cameraTransform.forward * ver + cameraTransform.right * hor).normalized;
        direction.y = 0; // Ignora el eje Y de la direcci�n para mantener al jugador en el plano horizontal

        if (direction != Vector3.zero)
        {
            // Calcula la rotaci�n deseada hacia la direcci�n de movimiento
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Aplica una rotaci�n suave usando Slerp y el par�metro rotationSpeed
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Aplica la velocidad en la direcci�n
            Vector3 velocity = direction * movementSpeed;
            velocity.y = rigidbody.velocity.y; // Mantener la velocidad vertical del Rigidbody
            rigidbody.velocity = velocity;
        }

        // Saltar si est� en el suelo y se presiona la tecla Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            isGrounded = false;
        }

        // Prolonga el salto mientras se mantiene presionado Jump
        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rigidbody.AddForce(Vector3.up * additionalJumpForce, ForceMode.Force);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

