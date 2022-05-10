using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI youWin;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        isGameActive = true;
        Debug.Log(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // this section of code esseientally just determines if the score is above a certain level
        // and displays text "you win" depending on it
        if (score >= 100f)
        {
            youWin.gameObject.SetActive(true);
            isGameActive = false;
        }
        

    }
    public void UpdateScore(int scoreToAdd)
    {
        // this section of code just initalises a score and adds a number to it once a a condition is met
        // parameters score
        // output: score
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        Debug.Log(score);
    }
}
