using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 
    public void PlayGame()
    {
        SceneManager.LoadScene("Cheeze");
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Debug.Log("You quit. What a short attention span");
        Application.Quit();
    }

}
