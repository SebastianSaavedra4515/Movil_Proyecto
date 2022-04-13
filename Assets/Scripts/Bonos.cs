using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonos : MonoBehaviour
{
    
    Rigidbody2D rigi;
    
    [SerializeField] float velocidad = 2;
    Jugador jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        rigi = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rigi.AddForce(new Vector2(0, -velocidad) * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" )
        {
            jugador.puntos+=Random.RandomRange(10,30);
            Destroy(gameObject);
        }
        if( collision.transform.tag == "Muro")
        {
            Destroy(gameObject);
        }
    }
}
