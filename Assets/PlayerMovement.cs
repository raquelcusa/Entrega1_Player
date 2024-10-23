using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private GameObject nearByItem;
    private bool hasItem;
    public GameObject handSocket; //Empty gameobject attached to the player in the scene, position near a hand?
    void OnCollisionEnter(Collider other)
    {
        if (other.tag == "item") //Item is a custom tag, I assume you know how to do that. You can use gameobject names if you like
            nearByItem = other.gameObject;
    }
    void OnCollisionExit(Collider other)
    {
        if (other.gameObject == nearByItem)
            nearByItem = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (nearByItem != null)
        {
            if (Input.GetKeyDown(Keycode.E))
            {

                nearByItem.transform.parent = hasItem ? null : handSocket.transform;

                if (hasItem == false)
                {
                    hasItem = true;
                }
                else
                {
                    hasItem = false;
                }
            }
        }
    }
}



