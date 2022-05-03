using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashCargado : MonoBehaviour
{
    Rigidbody2D rigi;
    [SerializeField] float velocidad = 2;
    PLayer jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PLayer>();
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0)
        {
            rigi.velocity = Vector2.left * velocidad * Time.deltaTime;
        }
        else
        {
            rigi.velocity = Vector2.right * velocidad * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemigoL")
        {
            collision.GetComponent<RobotLeft>().vivo = false;
            Matar();
            jugador.puntos += Random.RandomRange(10, 30);
        }

        if (collision.tag == "EnemigoR")
        {
            collision.GetComponent<Robot>().vivo = false;
            Matar();
            jugador.puntos += Random.RandomRange(10, 30);
        }
        if (collision.tag == "Muro")
        {
            Destroy(gameObject);
        }
    }
    public void Matar()
    {

        jugador.disp=2;
        

    }
}
