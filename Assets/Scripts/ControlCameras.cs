using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public Transform firstPersonCamera;  // Cámara en primera persona
    public Transform thirdPersonCamera;  // Cámara en tercera persona
    public Vector2 sensibility = new Vector2(250, 250);
    public float thirdPersonDistance = 5f; // Distancia de la cámara en tercera persona
    public float thirdPersonHeight = 2f; // Altura de la cámara en tercera persona
    private bool isFirstPerson = true;  // Estado de la vista de la cámara

    void Start()
    {
        // Asegúrate de tener referencias a ambas cámaras en el Inspector o asignarlas aquí
        firstPersonCamera = transform.Find("FirstPersonCamera");
        thirdPersonCamera = transform.Find("ThirdPersonCamera");

        // Bloquea el cursor
        Cursor.lockState = CursorLockMode.Locked;
        UpdateCameraState();
    }

    void Update()
    {
        // Alterna entre las cámaras al presionar la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
            UpdateCameraState();
        }

        // Controla la rotación de la cámara
        float hor = Input.GetAxis("Mouse X") * sensibility.x * Time.deltaTime;
        float ver = Input.GetAxis("Mouse Y") * sensibility.y * Time.deltaTime;

        if (hor != 0)
        {
            transform.Rotate(Vector3.up * hor);
        }

        if (isFirstPerson)
        {
            // Cámara en primera persona: rotación en eje X
            float angle = (firstPersonCamera.localEulerAngles.x - ver + 360) % 360;
            if (angle > 180) angle -= 360;
            angle = Mathf.Clamp(angle, -40, 40);
            firstPersonCamera.localEulerAngles = Vector3.right * angle;
        }
        else
        {
            // Cámara en tercera persona: ajusta la posición y altura
            Vector3 thirdPersonPosition = transform.position
                                          - transform.forward * thirdPersonDistance
                                          + Vector3.up * thirdPersonHeight;

            thirdPersonCamera.position = thirdPersonPosition;
            thirdPersonCamera.LookAt(transform.position + Vector3.up * 1.5f);  // Ajusta el "look at" al centro del jugador
        }
    }

    // Activa o desactiva las cámaras según la vista seleccionada
    void UpdateCameraState()
    {
        firstPersonCamera.gameObject.SetActive(isFirstPerson);
        thirdPersonCamera.gameObject.SetActive(!isFirstPerson);
    }
}

