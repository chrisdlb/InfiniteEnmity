using UnityEngine;
using System.Collections;

public class weaponMovement : MonoBehaviour {

    public float maxSpeed;
    public float damage;

    private bool isDestroyed;

    void Start()
    {
        isDestroyed = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;

        if(isDestroyed)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D()
    {
        isDestroyed = true;
    }
}
