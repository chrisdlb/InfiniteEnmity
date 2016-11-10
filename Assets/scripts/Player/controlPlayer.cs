using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controlPlayer : MonoBehaviour {

    //movement variables
    float maxSpeed;
    public float rotSpeed;
    
    //map dimmensions    
    public float Xmax;
    public float Ymax;

    //hyperspace variables
    float warpTimer;
    public float warpWaitTime;
    public float maxNormalSpeed;
    public float maxWarpSpeed;
    public AudioSource hyperspace1;

    // weapon prefabs
    public GameObject fire1;
    public GameObject fire2;

    //weapon sound effects
    public AudioSource sound1;
    public AudioSource sound2;

    // time between being allowed to fire
    public float shootingInterval = 0.5f;
    float delayTimer = 0;

    //health controls
    public float currentHealth;
    public float maxHealth;
    public Image healthBar;

    //MOVE ship forward and backward
    Vector3 pos;
    Vector3 velocity;
    float z;
    Quaternion rot;

    // Start called on scene begin
    void Start()
    {
        warpTimer = warpWaitTime;
    }

    

    // Update is called once per frame
    void Update () {

        Quaternion rot = transform.rotation;

        //Countdown warp timer
        if (Input.GetButton("Warp") && Input.GetAxis("Movement") == 1)
        {
            warpTimer-= Time.deltaTime;
            if (warpTimer <= 0)
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
            maxSpeed = maxWarpSpeed;
            if (!hyperspace1.isPlaying)
            {
                hyperspace1.Play();
            }             
        }
        else
        {
            maxSpeed = maxNormalSpeed;
            z = rot.eulerAngles.z;
            z -= Input.GetAxis("Rotation") * rotSpeed * Time.deltaTime;
            rot = Quaternion.Euler(0, 0, z);
            transform.rotation = rot;

            if (warpTimer != 0 && hyperspace1.isPlaying)
            {
                hyperspace1.Pause();
            }
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

        // countdown delay fire timer to zero
        delayTimer -= Time.deltaTime;

        //shoot primary
        if (Input.GetButton("Fire1") && delayTimer <= 0)
        {
            delayTimer = shootingInterval;
            Instantiate(fire1, transform.position, transform.rotation);
            sound1.Play();
        }
        //shoot secondary
        if (Input.GetButton("Fire2") && delayTimer <= 0)
        {
            delayTimer = shootingInterval;
            Instantiate(fire2, transform.position, transform.rotation);
            sound2.Play();
        }

        //healthbar
        healthBar.fillAmount = (float)currentHealth / maxHealth;

    }
}
