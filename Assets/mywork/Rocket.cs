using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    Rigidbody2D rocket;
    [SerializeField]
    float thrust;
    [SerializeField]
    float turn_thrust;
    public static float Rocket_altitude = 0;


    //rocket rotation
    float smooth = 2.0f;
    float tiltAngle = 20.0f;
    [SerializeField]float speed = 0.1f;


    //engines
    bool left_engine;
    bool right_engine;


    void Start()
    {
        rocket = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        //rocket altitude
        Rocket_altitude = Rocket_altitude + transform.position.y * Time.deltaTime;
        test_altitude.text = Rocket_altitude.ToString();
        //Debug.Log("<color=green>altitude: </color>" + Rocket_altitude);

        Debug.Log("left" + left_engine);
        Debug.Log("right" + right_engine);

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(-tiltAroundX, 0, -tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);

        //if (Input.GetKey(KeyCode.Space))
        //{

        //}

        if (left_engine) //left
        {

            AddForceAt_left(thrust, turn_thrust);

        }


        if (right_engine) //right
        {
            AddForceAt_right(thrust, turn_thrust);
        }







        #region engine test lights and keyboard

        //engine testing**********************************

        if (left_engine)
        {
            left_test_engine.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        else
        {
            left_test_engine.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        if(right_engine)
        {
            right_test_engine.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        else
        {
            right_test_engine.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        //buttons..................................

        if(Input.GetKey(KeyCode.A))
        {
            left_engine = true;
        }else
        {
            left_engine = false;
        }

        if(Input.GetKey(KeyCode.D))
        {
            right_engine = true;
        }
        else
        {
            right_engine = false;
        }

        #endregion


    }

    public void AddForceAt_right(float force, float angle)
    {
        if(right_engine)
        {
            float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
            float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;
            Vector3 right_force = new Vector3(ycomponent, xcomponent, 0);
            rocket.AddForce(right_force);
        }    
        
    }

    public void AddForceAt_left(float force, float angle)
    {
        if(left_engine)
        {
            float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
            float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;
            Vector3 left_force = new Vector3(-ycomponent, xcomponent, 0);
            rocket.AddForce(left_force);
        }
        
    }



    public void leftButton()
    {
        Debug.Log("left");
        left_engine = true;
        
    }
    public void release_left()
    {
        Debug.Log("right");
        left_engine = false;
    }


    public void rightButton()
    {
        right_engine = true;
    }
    public void release_right()
    {
        right_engine = false;
    }


    #region engine_testing
    [Header("testing items")]
    [SerializeField]Image left_test_engine;
    [SerializeField]Image right_test_engine;
    [SerializeField]Text test_altitude;
    


    #endregion


}
