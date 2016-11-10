using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuControlsScript : MonoBehaviour {

    public GameObject Main;
    public GameObject Controls;
    public GameObject Load;
    private bool main = true;
    private bool controls = false;
    private bool load = false;

    // Use this for initialization
    void Start () {
        Main.SetActive(true);
        Controls.SetActive(false);
        Load.SetActive(false);
    }

    public void openLoad()
    {
        load = !load;
    }

    public void openControl()
    {
        controls = !controls;
    }

    public void closeAll()
    {
        controls = false;
        load = false;
        main = true;

    }

    // Update is called once per frame
    void Update () {
        if (load)
        {
            Load.SetActive(true);
        } else if (!load)
        {
            Load.SetActive(false);
        }

        if (controls)
        {
            Controls.SetActive(true);
        }
        else if (!controls)
        {
            Controls.SetActive(false);
        }

        if (main)
        {
            Main.SetActive(true);
        }
        else if (!load)
        {
            Main.SetActive(false);
        }
    }
}
