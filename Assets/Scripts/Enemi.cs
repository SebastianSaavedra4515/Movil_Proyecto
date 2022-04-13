using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemi : MonoBehaviour
{
    Animator AnimRobot;
    Rigidbody2D rigi;
    public bool vivo = true;
    [SerializeField] float velocidad = 2;
    Jugador jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        rigi = GetComponent<Rigidbody2D>();
        AnimRobot = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rigi.AddForce(new Vector2(0, -velocidad) * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("no");
        if (collision.transform.tag=="Player"|| collision.transform.tag == "Muro")
        {
            Debug.Log("si");
            jugador.vida--;
            Destroy(gameObject);
        }
    }

}
