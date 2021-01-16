using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody2D rocket;
    [SerializeField]
    float thrust;
    [SerializeField]
    float turn_thrust;
    void Start()
    {
        rocket = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space))
        {

        }

        if (Input.GetKey(KeyCode.A)) //left
        {
            AddForceAt_left(thrust, turn_thrust);
        } 
        
        
        if (Input.GetKey(KeyCode.D)) //right
        {
            AddForceAt_right(thrust,turn_thrust);
        }


    }

    public void AddForceAt_right(float force, float angle)
    {
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;
        Vector3 right_force = new Vector3(ycomponent, xcomponent, 0);
        rocket.AddForce(right_force);
    }

    public void AddForceAt_left(float force, float angle)
    {
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;
        Vector3 left_force = new Vector3(-ycomponent, xcomponent, 0);
        rocket.AddForce(left_force);
    }

}
