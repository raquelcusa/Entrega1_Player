using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    private new Transform camera;
    public Vector2 sensibility;

    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Camera");
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Mouse X") * sensibility.x * Time.deltaTime; 
        float ver = Input.GetAxis("Mouse Y") * sensibility.y * Time.deltaTime;

        if (hor != 0)
        {
            transform.Rotate(Vector3.up * hor);

        }
        if (ver!=0)
        {
            // camera.Rotate(Vector3.left * ver * sensibility.y);
            float angle = (camera.localEulerAngles.x - ver  + 360) % 360;
            
            if(angle >180) 
            {
                angle -= 360;
                
            }
             angle = Mathf.Clamp(angle,-50, 50);
            camera.localEulerAngles = Vector3.right * angle;
        }
    }
}
