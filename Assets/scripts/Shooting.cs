using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public GameObject torpedoPrefab;
    public GameObject phaserPrefab;

    public float shootingInterval = 0.3f;
    float pauseTimer = 0;

	// Update is called once per frame
	void Update () {
        pauseTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && pauseTimer <= 0)
        {

            pauseTimer = shootingInterval;

            Instantiate(torpedoPrefab, transform.position, transform.rotation);
        }
        if (Input.GetButton("Fire2") && pauseTimer <= 0)
        {

            pauseTimer = shootingInterval;

            Instantiate(phaserPrefab, transform.position, transform.rotation);
        }
    }
}
