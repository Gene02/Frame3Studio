using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text t;
    public int Combustible;

    public static int actualScore;
    public static Score scoreScript;


    private void Start()
    {
        actualScore = 0;
        scoreScript = this;
    }

    public void ScoreUpdate()
    {

        Combustible++;
        actualScore = Combustible;
        t.text = "Combustible : " + Combustible.ToString();
    }

}
