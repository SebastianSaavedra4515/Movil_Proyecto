using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Intro : MonoBehaviour
{
    public float tiempoEspera;
    float tiempo=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if(tiempo>=tiempoEspera)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
