using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipControl : MonoBehaviour
{
    Vector2 touchIncial;
    Vector2 touchFinal;
   public PLayer control;
    float time=0;
    public float TiempoCarga=5;
    bool Cargado = false;
    bool Cargando = false;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<PLayer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchIncial = Input.GetTouch(0).position;
            if(control.disp>=2)
            {
                Cargando = true;

            }

        }
        if(Input.touchCount>0&& Input.GetTouch(0).phase == TouchPhase.Ended)
        {
           
            touchFinal = Input.GetTouch(0).position;
            if(Cargado==false)
            {
                if (touchFinal.x < touchIncial.x && Cargado == false)
                {
                    Debug.Log("rigth");
                    control.Golpeleft();
                    Cargando = false;
                }
                if (touchFinal.x > touchIncial.x && Cargado == false)
                {
                    Debug.Log("left");
                    control.GolpeRigth();
                    Cargando = false;
                }
            }
            else
            {
                if (touchFinal.x < touchIncial.x && Cargado == true)
                {
                    Debug.Log("left");
                    
                    Cargando = false;
                    control.AnimPlayer.SetBool("Cargado", false);
                    control.GolpeleftCargado();

                }
                if (touchFinal.x > touchIncial.x && Cargado == true)
                {
                    Debug.Log("rigth");
                    
                    Cargando = false;
                    control.AnimPlayer.SetBool("Cargado", false);
                    control.GolpeRigthCargado();
                }
            }
          
        }
        if(Cargando == true)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
        }
        if (time >= TiempoCarga)
        {
            Cargado = true;
            control.AnimPlayer.SetBool("Cargado", true);
        }
        else
        {
            Cargado = false;

           
        }
    }
}
