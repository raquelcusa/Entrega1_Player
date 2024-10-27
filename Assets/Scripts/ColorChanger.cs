using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if(IsBall(collision.collider))
            ChangeColor();
    }

    private bool IsBall(Collider collider)
    {
       
       return collider.GetComponent<RoundTag>() != null;
    }

    private void ChangeColor()
    {
        _renderer.material.color = Color.green;
    }
}
