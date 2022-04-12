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
    // Start is called before the first frame update
    void Start()
    {
        Enemigos = transform.childCount;
     
    }

    // Update is called once per frame
    void Update()
    {
        
        tiempo += Time.deltaTime;
        Debug.Log(tiempo);
        if (tiempo>=timemax)
        {
            if(count<Enemigos)
            {
                transform.GetChild(count).gameObject.SetActive(true);
                timemax = Random.RandomRange(min,max);
                count++;
            }
            
            tiempo = 0;
        }
    }
}
