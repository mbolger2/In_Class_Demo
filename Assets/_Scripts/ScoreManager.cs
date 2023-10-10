using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //current score
    public int score = 0;

    //The text that will display the value of score
    public TextMeshProUGUI scoreDisplay;

    //
    public static ScoreManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        //We reste the score display to show the default value ofthe score
        scoreDisplay.text = score.ToString();

        //We set the instance to this scripet so it can be referenced from anywhere in the game without having to lok for it
        Instance = this;
    }

    //This function that tells this script when to increase the score
    public void AddScore(int value)
    {
        //Add the value to the score
        score += value;
        //Then display the new score
        scoreDisplay.text = score.ToString();
    }
}
