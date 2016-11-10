using UnityEngine;
using System.Collections;

public class enemyControl : MonoBehaviour {

    public float health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(health <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 13)
        {
            health -= other.gameObject.GetComponent<weaponControl>().damage;
        }
    }
}
