using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
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
            Winner.text = "You have destroyed all the mice!";
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
