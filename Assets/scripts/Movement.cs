using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    //Movement Variables
    float maxSpeed = 4f;
    public float rotSpeed = 180f;
    public float Xmax = 18f;
    public float Ymax = 10f;

    // Update is called once per frame
    void Update () {

        //ROTATE ship left and right
        /*
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
        */

        //MOVE ship forward and backward

        Vector3 pos;
        Vector3 velocity;

        float z;
        Quaternion rot;

        rot = transform.rotation;
        z = rot.eulerAngles.z;
        z -= Input.GetAxis("Rotation") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;
        pos = transform.position;
        velocity = new Vector3(0, Input.GetAxis("Movement") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        /*
        if (Input.GetKey(KeyCode.Tab))
        {

            maxSpeed = 80f;
            rot = transform.rotation;
            pos = transform.position;
            velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
            pos += rot * velocity;
        }
        else
        {
            

        }

        */



        //MAP boundries
        if (pos.y > Ymax){
            pos.y = Ymax;
        } else if (pos.y < -Ymax)
        {
            pos.y = -Ymax;
        }

        if (pos.x > Xmax)
        {
            pos.x = Xmax;
        }
        else if (pos.x < -Xmax)
        {
            pos.x = -Xmax;
        }

        transform.position = pos;

    }
}
