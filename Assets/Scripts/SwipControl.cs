using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipControl : MonoBehaviour
{
    Vector2 touchIncial;
    Vector2 touchFinal;
   public PLayer control;
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

        }
        if(Input.touchCount>0&& Input.GetTouch(0).phase == TouchPhase.Ended)
        {
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
        }
    }
}
