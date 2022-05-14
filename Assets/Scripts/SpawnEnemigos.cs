using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public int Enemigos;
    List<GameObject> Enemis;
    int count = 0;
    float tiempo = 0;
     float timemax;
    public float min=5;
    public float max = 10;
    [SerializeField] GameObject Enemi;
    [SerializeField] PLayer jugador;

    float _min = 0;
     float _max = 0;
    // Start is called before the first frame update
    void Start()
    {
        _min = min;

        _max = max;
    }

    // Update is called once per frame
    void Update()
    {
        
        tiempo += Time.deltaTime;
        //Debug.Log(tiempo);
        if (tiempo>=timemax)
        {

            Instantiate(Enemi, transform);
                timemax = Random.RandomRange(_min, _max);
                count++;
            
            
            tiempo = 0;
        }
        if(jugador.puntos>250)
        {
            _min = min + 1;
            
        }
        if (jugador.puntos > 500)
        {
            _min = min + 2;
            
        }
        if (jugador.puntos > 750)
        {
            _min = min + 3;

        }


    }
}
