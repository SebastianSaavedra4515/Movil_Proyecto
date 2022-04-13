using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Jugador : MonoBehaviour
{
    Animator AnimPlayer;
    public float vida = 5;
    public int puntos;
    [SerializeField] float velocidad = 2;
    [SerializeField] Transform PointShot;
    [SerializeField] Text Score;
    [SerializeField] Text Vida;
    [SerializeField] GameObject Slash;
    [SerializeField] GameObject Eliminar;
    Rigidbody2D rigi;
    float limit = 3.46f;
    bool isleft=false;
    bool isrigth = false;
    private Touch touch;
    private Vector2 posTouch;
    // Start is called before the first frame update
    void Start()
    {
        AnimPlayer = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
    }
    public void MoveRigth()
    {
        isrigth = true;
    }
    public void MoveLeft()
    {
        isleft = true;
    }
    public void dontMoveRigth()
    {
        isrigth = false;
    }
    public void dontMoveLeft()
    {
        isleft = false;
    }
    // Update is called once per frame
    void Update()
    {

        
        Score.text = "Score:" + puntos;
        Vida.text = "Vida:" + vida;
        if(isleft==true)
        {
            if (transform.position.x > -1 * limit)
            {
                rigi.AddForce(new Vector2(-velocidad, 0) * Time.deltaTime);
            }
        }
        if (isrigth== true)
        {
            if (transform.position.x < limit)
            {
                rigi.AddForce(new Vector2(velocidad, 0) * Time.deltaTime);
            }
        }
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            posTouch = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase==TouchPhase.Began)
            {
                Instantiate(Eliminar, posTouch, Quaternion.identity);
            }
        }
    }
    public void shot()
    {
        Instantiate(Slash, PointShot.position, new Quaternion(0,0,-90,0));
    }
    IEnumerator esperarleft()
    {
        yield return new WaitForSeconds(0.2f);

        Instantiate(Slash, PointShot.position, PointShot.rotation);
    }
}
