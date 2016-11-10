using UnityEngine;
using System.Collections;

public class weaponControl : MonoBehaviour {

    public float maxSpeed;
    public float damage;

    private bool isDestroyed;

    //time delay before object destroyed
    public float delayDestruction = 2f;

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
            DestroyObject();
        }

        //countdown destruction delay timer to zero
        delayDestruction -= Time.deltaTime;

        if (delayDestruction <= 0)
        {
            DestroyObject();
        }
    }

    void OnTriggerEnter2D()
    {
        isDestroyed = true;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
