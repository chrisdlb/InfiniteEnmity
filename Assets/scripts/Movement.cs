using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    //Movement Variables
    float maxSpeed;
    float warpTimer;

    public float rotSpeed;
    public float Xmax;
    public float Ymax;
    public float warpWaitTime;

    void Start()
    {
        warpTimer = warpWaitTime;
    }

    // Update is called once per frame
    void Update () {
        //MOVE ship forward and backward
        Vector3 pos;
        Vector3 velocity;

        float z;
        Quaternion rot = transform.rotation;

        //Countdown warp timer
        if (Input.GetButton("Warp") && Input.GetAxis("Movement") == 1)
        {
            warpTimer-= Time.deltaTime;
            if(warpTimer <= 0)
            {
                warpTimer = 0;
            }

        }
        else
        {
            warpTimer = warpWaitTime;
        }
        
        if(Input.GetButton("Warp") && warpTimer == 0)
        {
            maxSpeed = 80f;
        }
        else
        {
            maxSpeed = 4f;
            z = rot.eulerAngles.z;
            z -= Input.GetAxis("Rotation") * rotSpeed * Time.deltaTime;
            rot = Quaternion.Euler(0, 0, z);
            transform.rotation = rot;
        }
        pos = transform.position;
        velocity = new Vector3(0, Input.GetAxis("Movement") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

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
