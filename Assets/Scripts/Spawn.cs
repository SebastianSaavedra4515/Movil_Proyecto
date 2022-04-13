using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Enemigo;
    public GameObject Bonos;
    public float limit=3.2f;
    
    float tiempo = 0;
    float timemax;
    public float min = 2;
    public float max = 5;
     int opcion;
    Vector3 DarPosicion()
    {
        Vector3 pos = new Vector3(Random.RandomRange(-3.2f,3.2f),transform.position.y,transform.position.z);
        return pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= timemax)
        {
            opcion = Random.Range(1, 10);
                if(opcion%2==0)
            {
                Instantiate(Enemigo, DarPosicion(), Quaternion.identity);
            }
            else
            {
                Instantiate(Bonos, DarPosicion(), Quaternion.identity);
            }
                timemax = Random.RandomRange(min, max);
                
            

            tiempo = 0;
        }
    }
}
