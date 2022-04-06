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
    [SerializeField] Text Score;
    public float enemigos;
    [SerializeField] GameObject Slash;
    [SerializeField] SpawnEnemigos spawn1;
    [SerializeField] SpawnEnemigos spawn2;
    public int shot=0;
    // Start is called before the first frame update
    void Start()
    {
        enemigos = spawn1.Enemigos + spawn2.Enemigos;
        vida = vidaMax;
        AnimPlayer = GetComponent<Animator>();
    }
    public void Golpeleft()
    {
        if(shot< 2)
        {
            AnimPlayer.SetTrigger("Left");
            Slash.transform.localScale = new Vector3(1, 1, 1);
            shot++;
            StartCoroutine(esperarleft());
        }

    }

    public void GolpeRigth()
    {
        if (shot < 2)
        {
            AnimPlayer.SetTrigger("Rigth");
            Slash.transform.localScale = new Vector3(-1, 1, 1);
            shot++;
            StartCoroutine(esperarRigth());
        }

    }
    IEnumerator esperarRigth()
    {
        yield return new WaitForSeconds(0.2f);

        Instantiate(Slash, rigth.position, rigth.rotation);
    }
    IEnumerator esperarleft()
    {
        yield return new WaitForSeconds(0.2f);
        
        Instantiate(Slash, left.position, left.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        vidaImage.fillAmount = vida / vidaMax;
        EnemigosText.text = "Enemigos :" +enemigos;
        Score.text = "Score:" + puntos;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(left.position, Radio);
        Gizmos.DrawWireSphere(rigth.position, Radio);
    }
}
