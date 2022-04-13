using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashUP : MonoBehaviour
{
    Rigidbody2D rigi;
    Jugador jugador;
    [SerializeField] float velocidad = 2;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
    }

    // Update is called once per frame
    void Update()
    {
        rigi.AddForce(new Vector2(0, velocidad) * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "EnemigoL")
        {
            Debug.Log("ok");
            jugador.puntos += Random.RandomRange(10, 30);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Bono")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "EnemigoL")
        {
            Debug.Log("ok");
            jugador.puntos += Random.RandomRange(10, 30);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Bono")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
       
    }
}
