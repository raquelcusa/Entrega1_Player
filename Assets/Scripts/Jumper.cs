using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float JumpForce = 10;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldJump())
            Jump();
    }

    private bool ShouldJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
    private void Jump()
    {
        _rigidbody.AddForce(JumpForce * Vector3.up, ForceMode.Impulse);
    }
}
