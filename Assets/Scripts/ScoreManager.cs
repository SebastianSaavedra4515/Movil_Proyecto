using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int ScoreReal;
    public int BestScores;
    public List<int> Scores;
    // Start is called before the first frame update
    void Start()
    {
        BestScores = PlayerPrefs.GetInt("PuntajeRecord", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MayorScore()
    {
        if (Scores.Capacity != 0)
        {
            int score = 0;
            for (int i = 0; i < Scores.Capacity; i++)
            {
                if (Scores[i] >= score)
                {
                    score = Scores[i];
                }
            }
            BestScores = score;
        }
        PlayerPrefs.SetInt("PuntajeRecord", BestScores);

    }

    public void AñadirPuntaje(int puntaje)
    {
        Scores.Add(puntaje);
    }
}
