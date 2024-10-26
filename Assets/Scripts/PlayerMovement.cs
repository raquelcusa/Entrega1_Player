using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float movementSpeed;

   void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        if (hor!=0 || ver != 0)
            
        {
            // forward = hacia donde va el player
            Vector3 direction = (transform.forward * ver + transform.right * hor).normalized;
            velocity = direction * movementSpeed;
        }
        
        velocity.y = rigidbody.velocity.y; 
        rigidbody.velocity = velocity;

    }
     
}

