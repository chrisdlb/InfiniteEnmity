using UnityEngine;
using System.Collections;

public class NavigationMenu : MonoBehaviour {

    public GameObject NavigationOverlay;
    private bool state = false;

    // Use this for initialization
    void Start () {

        NavigationOverlay.SetActive(false);

    }

    public void Toggle()
    {
        state = !state;

        if (state)
        {
            NavigationOverlay.SetActive(true);
            Time.timeScale = 0;
        }

        if (!state)
        {
            NavigationOverlay.SetActive(false);
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
