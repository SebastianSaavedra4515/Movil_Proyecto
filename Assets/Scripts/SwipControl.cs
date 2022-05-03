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
            time += Time.deltaTime;
        }
        if(Input.touchCount>0&& Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if(time>TiempoCarga)
            {
                Cargado = true;
                control.AnimPlayer.SetBool("Cargado", true);
            }
            else
            {
                Cargado = false;

                control.AnimPlayer.SetBool("Cargado", false);
            }
            touchFinal = Input.GetTouch(0).position;
            if(touchFinal.x<touchIncial.x)
            {
                Debug.Log("rigth");
                control.Golpeleft();
            }
            if (touchFinal.x >touchIncial.x)
            {
                Debug.Log("left");
                control.GolpeRigth();
            }
            if (touchFinal.x < touchIncial.x&&Cargado==true)
            {
                Debug.Log("rigth");
                time = 0;
                Cargado = false;
                control.AnimPlayer.SetBool("Cargado", false);
                control.GolpeleftCargado();
                
            }
            if (touchFinal.x > touchIncial.x && Cargado == true)
            {
                Debug.Log("left");
                time = 0;
                Cargado = false;
                control.AnimPlayer.SetBool("Cargado", false);
                control.GolpeRigthCargado();
            }
        }
    }
}
