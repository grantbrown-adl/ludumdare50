using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnScript : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private static int intScore;

    public static int IntScore { get => intScore; set => intScore = value; }

    private void Update()
    {
        score = intScore;

        if(intScore >= GameManagerScript.ScoreNeeded)
        {
            intScore = 0;
            GameManagerScript.Happiness++;
        }
    }
}
