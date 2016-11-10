using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class prefsPlayer : MonoBehaviour {

    //player position & rotation field names
    private const string strPosX = "PositionX";
    private const string strPosY = "PositionY";
    private const string strRotZ = "RotationZ";

    //save & load text box
    public Text statusBox;

    //player health
    public float playerHealth;

    void Start () {
        if(PlayerPrefs.GetInt("Load on Start") > 0)
        {
            Load();
        }
    }

	void Update () {
        if(Input.GetButtonDown("Save"))
        {
            Save();
        }
        else if(Input.GetButtonDown("Load"))
        {
            Load();
        }

	}

    public void Load()
    {
        if (statusBox.name == "Status")
        {
            statusBox.text = "Loaded!";            
        }

        //load player position and rotation
        Vector3 playerPosition = transform.position;
        Quaternion playerRotation = transform.rotation;
        playerPosition.x = PlayerPrefs.GetFloat(strPosX);
        playerPosition.y = PlayerPrefs.GetFloat(strPosY);
        playerRotation.z = PlayerPrefs.GetFloat(strRotZ);
        transform.position = playerPosition;
        transform.rotation = playerRotation;

        //loads player health
        GameObject.Find("Player").GetComponent<controlPlayer>().currentHealth = PlayerPrefs.GetFloat("PlayerHealth");

        //loads music previous play time
        GameObject.Find("UI").GetComponent<AudioSource>().time = PlayerPrefs.GetFloat("MusicPosition");

    }

	public void Save() {
        if(statusBox.name == "Status")
        {
            statusBox.text = "Saved!";
        }       

        //saving player position & rotation
        PlayerPrefs.SetFloat(strPosX, transform.position.x);
		PlayerPrefs.SetFloat(strPosY, transform.position.y);
        PlayerPrefs.SetFloat(strRotZ, transform.rotation.z);

        //saving player health
        PlayerPrefs.SetFloat("PlayerHealth", GameObject.Find("Player").GetComponent<controlPlayer>().currentHealth);

        //saves music current play time
        PlayerPrefs.SetFloat("MusicPosition", GameObject.Find("UI").GetComponent<AudioSource>().time);

        
    }

    public void SetLoad(int load)
    {
        PlayerPrefs.SetInt("Load on Start", load);
    }
}
