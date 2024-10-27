using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : MonoBehaviour
{
    Rigidbody _rigidbody;

    private float _orgDrag;
    private float _orgAngularDrag;

    public float AngularDragEffect = 10;
    public float DragEffect = 5;
    public float VelocityEffect = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SlowDown(float density)
    {
        //Save current values of drags
        _orgDrag = _rigidbody.drag;
        _orgAngularDrag = _rigidbody.angularDrag;

        //set temp drag
        _rigidbody.velocity *= Mathf.Min(1,(VelocityEffect / density));
        _rigidbody.angularDrag = (AngularDragEffect * density);
        _rigidbody.drag = DragEffect * density;
    }

    internal void Reset()
    {
        _rigidbody.angularDrag = _orgAngularDrag;
        _rigidbody.drag = _orgDrag;
    }
}
