using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Transform Player;

    private void LateUpdate()
    {
        
        {
            Vector3 newPosition = Player.position;

            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }
    }

}
