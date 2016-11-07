using UnityEngine;
using System.Collections;

public class GPS : MonoBehaviour {

    public GameObject planet;
    public GameObject player;
	
	// Update is called once per frame
	void Update () { 
        
        Vector3 dir = planet.transform.position - player.transform.position;
        dir.Normalize();

        Debug.Log(dir);

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

	}
}
