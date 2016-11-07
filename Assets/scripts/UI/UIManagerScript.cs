using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("default");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void QuitMenu()
    {
        SceneManager.LoadScene("menu");
    }

}
