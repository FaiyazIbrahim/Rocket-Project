using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Debug.Log("<color=green>altitude: </color>" + Rocket_altitude);

        Debug.Log("left" + left_engine);
        Debug.Log("right" + right_engine);

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(-tiltAroundX, 0, -tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        //if (Input.GetKey(KeyCode.Space))
        //{

        //}

        if (Input.GetKey(KeyCode.A)) //left
        {
            left_engine = true;

            AddForceAt_left(thrust, turn_thrust);

        }
        else
        {
            left_engine = false;
        }


        if (Input.GetKey(KeyCode.D)) //right
        {
            right_engine = true;
            AddForceAt_right(thrust, turn_thrust);
        }
        else
        {
            right_engine = false;
        }





        #region engine test lights

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

        #endregion


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



    public void leftButton()
    {
        left_engine = true;
        
    }


    public void rightButton()
    {
        right_engine = true;
    }


    #region engine_testing
    [Header("testing items")]
    [SerializeField]Image left_test_engine;
    [SerializeField]Image right_test_engine;
    [SerializeField]Text test_altitude;
    


    #endregion


}
