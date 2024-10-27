using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    public float Density=1;
    private void OnTriggerEnter(Collider other)
    {
       
        var slower = other.GetComponent<Slower>();
        if(slower != null)        {
            
            slower.SlowDown(Density);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var slower = other.GetComponent<Slower>();
        if (slower != null)
        {

            slower.Reset();
        }
    }

}
