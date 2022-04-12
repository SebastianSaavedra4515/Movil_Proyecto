using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLeft : MonoBehaviour
{
    Animator AnimRobot;
    public bool vivo = true;
    Rigidbody2D rigi;
    [SerializeField] float velocidad = 2;

    PLayer jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PLayer>();
        rigi = GetComponent<Rigidbody2D>();
        AnimRobot = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vivo==true)
        {
            rigi.velocity = Vector2.right * velocidad * Time.deltaTime;
        }
        
        if (vivo == false)
        {
            rigi.velocity = new Vector2(0,0);
            Morir();
        }
    }

    void Morir()
    {
        AnimRobot.SetBool("vida", false);
        StartCoroutine(Esperar());
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.35f);
        jugador.enemigos--;
        jugador.puntos += Random.RandomRange(10, 30);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            vivo = false;
            collision.GetComponent<PLayer>().vida -= 10;
        }
    }
}
