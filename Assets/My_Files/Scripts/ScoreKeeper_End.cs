using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreKeeper_End : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI Winner;
    public int currentScore;
    public int highScore;
    public AudioSource track;
    public AudioSource dialogue;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreText.text = "Score: " + currentScore;
    }

    private void Update()
    {
        scoreText.text = "Mice Destroyed: " + currentScore;

        if (currentScore == 8)
        {
            //Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //track.Pause();
            //dialogue.Pause();
        }

    }

    public void AddScore(int points)
    {
        currentScore = currentScore + points;
        scoreText.text = "Score:" + currentScore;
    }

}
