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
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        //Debug.Log((transform.position - jugador.transform.position).magnitude);
        if ((transform.position-jugador.transform.position ).magnitude>= 2.8)
        {
            Debug.Log("morir");
            Matar();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemigoL")
        {
            collision.GetComponent<RobotLeft>().vivo = false;
            
            jugador.puntos += Random.RandomRange(10, 30);
        }

        if (collision.tag == "EnemigoR")
        {
            collision.GetComponent<Robot>().vivo = false;
            
            jugador.puntos += Random.RandomRange(10, 30);
        }

    }
    public void Matar()
    {

        jugador.disp=2;
        Destroy(gameObject);

    }
}
