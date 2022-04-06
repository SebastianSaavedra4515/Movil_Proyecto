using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PLayer : MonoBehaviour
{
    Animator AnimPlayer;
    public float vida=100;
    public int puntos;
    [SerializeField] float Radio;
    [SerializeField] Transform left;
    [SerializeField] Transform rigth;
    public Image vidaImage;
    public float vidaMax = 100;
    public Text EnemigosText;
    public float enemigos;
    [SerializeField] SpawnEnemigos spawn1;
    [SerializeField] SpawnEnemigos spawn2;
    // Start is called before the first frame update
    void Start()
    {
        enemigos = spawn1.Enemigos + spawn2.Enemigos;
        vida = vidaMax;
        AnimPlayer = GetComponent<Animator>();
    }
    public void Golpeleft()
    {
        AnimPlayer.SetTrigger("Left");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(left.position,Radio);
        Debug.Log("ok");
        
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("EnemigoL"))
            {
                
                colisionador.GetComponent<RobotLeft>().vivo = false;
            }
        }
    }

    public void GolpeRigth()
    {
        AnimPlayer.SetTrigger("Rigth");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(rigth.position, Radio);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("EnemigoR"))
            {
                colisionador.GetComponent<Robot>().vivo = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        vidaImage.fillAmount = vida / vidaMax;
        EnemigosText.text = "Enemigos :" +enemigos;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(left.position, Radio);
        Gizmos.DrawWireSphere(rigth.position, Radio);
    }
}
