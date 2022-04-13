using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliminador : MonoBehaviour
{
    Jugador jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag=="Bono")
    //    {
    //        jugador.puntos += Random.RandomRange(10, 30);
    //        Destroy(collision);
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bono")
        {
            Debug.Log("ok");
            jugador.puntos += Random.RandomRange(10, 30);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bono")
        {
            Debug.Log("ok");
            jugador.puntos += Random.RandomRange(10, 30);
            Destroy(collision.gameObject);
        }
    }
}
