using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseOverlay;
    public GameObject NavigationOverlay;
    public GameObject ControlsOverlay;
    private bool pause = false;
    private bool menu = false;
    private bool navigation = false;
    private bool controls = false;

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

    public void toggleControls()
    {
        controls = !controls;
    }

    public void openNav()
    {
        pause = true;
        toggleNav();
    }

    public void closeAll()
    {
        PauseOverlay.SetActive(false);
        NavigationOverlay.SetActive(false);
        navigation = false;
        menu = false;
        pause = false;
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

    void Update(){

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
        }

        if (Input.GetButtonUp("Pause") || Input.GetButtonUp("Navigation") ) {
            pause = true;
  
            if (Input.GetButtonUp("Pause"))
            {
                toggleMenu();
            } else if (Input.GetButtonUp("Navigation"))
            {
                toggleNav();
            }
        }

    }
}
