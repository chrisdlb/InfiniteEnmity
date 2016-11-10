using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameplayUIControl : MonoBehaviour {

    //overlay canvases
    public GameObject PauseOverlay;
    public GameObject NavigationOverlay;
    public GameObject ControlsOverlay;

    //control variables
    private bool pause = false;
    private bool menu = false;
    private bool navigation = false;
    private bool controls = false;
    public Text statusBox;    

    // Use this for initialization
    void Start () {
        PauseOverlay.SetActive(false);
        NavigationOverlay.SetActive(false);
    }

    public void openMenu()
    {
        pause = true;
        toggleMenu();
    }

    public void openNav()
    {
        pause = true;
        toggleNav();
    }

    public void toggleControls()
    {
        controls = !controls;
    }
    
    void toggleMenu()
    {
        menu = !menu;
        if (menu && !navigation)
        {
            PauseOverlay.SetActive(true);
        }
        else if (!menu)
        {
            PauseOverlay.SetActive(false);
            pause = !pause;

        }
        else if (navigation)
        {
            toggleNav();
            menu = !menu;
        }
    }

    void toggleNav()
    {
        navigation = !navigation;
        if (navigation && !menu)
        {
            NavigationOverlay.SetActive(true);
        }
        else if (!navigation)
        {
            NavigationOverlay.SetActive(false);
            pause = !pause;
        }
    }

    public void closeAll()
    {
        PauseOverlay.SetActive(false);
        NavigationOverlay.SetActive(false);
        navigation = false;
        menu = false;
        pause = false;
    }

    void Update()
    {

        if (pause)
        {
            Time.timeScale = 0;
            if (controls)
            {
                ControlsOverlay.SetActive(true);
            }
            else if (!controls)
            {
                ControlsOverlay.SetActive(false);
            }
        }
        else if (!pause)
        {
            Time.timeScale = 1;
            if (!GameObject.Find("UI").GetComponent<AudioSource>().isPlaying)
            {
                GameObject.Find("UI").GetComponent<AudioSource>().Play();
            }
            
        }

        if (Input.GetButtonUp("Pause") || Input.GetButtonUp("Navigation"))
        {
            pause = true;
            GameObject.Find("UI").GetComponent<AudioSource>().Pause();
            if (statusBox.name == "Status")
            {
                statusBox.text = "Game Paused";
            }

            if (Input.GetButtonUp("Pause"))
            {
                toggleMenu();
            }
            else if (Input.GetButtonUp("Navigation"))
            {
                toggleNav();
            }
        }
    }
}
