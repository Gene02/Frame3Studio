using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text t;
    public int score;

    public static int actualScore;
    public static Score scoreScript;


    private void Start()
    {
        actualScore = 0;
        scoreScript = this;
    }

    public void ScoreUpdate()
    {

        score++;
        actualScore = score;
        t.text = "Combustible : " + score.ToString();
    }

}
