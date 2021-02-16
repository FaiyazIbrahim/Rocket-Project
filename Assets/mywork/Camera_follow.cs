using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    

    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position


        //if()
        //{

        //}

        if(Camera.main.fieldOfView <= 100)
        {
            Camera.main.fieldOfView = Camera.main.fieldOfView + (10f * Time.deltaTime);
        }
        
        
    }
}
