using UnityEngine;
using System.Collections;

public class GarbageDisposal : MonoBehaviour {

    public float timer = 2f;
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {

            Destroy(gameObject);

        }

	}
}
