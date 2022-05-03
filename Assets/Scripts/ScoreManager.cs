using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int ScoreReal;
    public int BestScores;
    public List<int> Scores;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MayorScore();
    }
    public void MayorScore()
    {
        if(Scores.Capacity!=0)
        {
            int score = 0;
            for (int i = 0; i < Scores.Capacity; i++)
            {
                if (Scores[i] > score)
                {
                    score = Scores[i];
                }
            }
            BestScores = score;
        }
        
    }
}
