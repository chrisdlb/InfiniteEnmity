using UnityEngine;
using System.Collections;

public class LoadSavePlayer : MonoBehaviour {

    private const string strPosX = "PositionX";
    private const string strPosY = "PositionY";

    void Start () {
        if(PlayerPrefs.GetInt("Load") > 0)
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

    void Load()
    {
        Vector3 playerPosition = transform.position;
        playerPosition.x = PlayerPrefs.GetFloat(strPosX);
        playerPosition.y = PlayerPrefs.GetFloat(strPosY);

        transform.position = playerPosition;
    }

	public void Save() {
		PlayerPrefs.SetFloat(strPosX, transform.position.x);
		PlayerPrefs.SetFloat(strPosY, transform.position.y);
	}

    public void SetLoad(int load)
    {
        PlayerPrefs.SetInt("Load", load);
    }
}
