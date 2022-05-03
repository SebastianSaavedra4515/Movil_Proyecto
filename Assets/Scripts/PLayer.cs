using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PLayer : MonoBehaviour
{
    public Animator AnimPlayer;
    public float vida=100;
    public int puntos;
    [SerializeField] float Radio;
    [SerializeField] Transform left;
    [SerializeField] Transform rigth;
    public Image vidaImage;
    public float vidaMax = 100;
    public Text EnemigosText;
    [SerializeField] Text Score;
    [SerializeField] Text Slashs;
    public float enemigos;
    [SerializeField] GameObject Slash;
    [SerializeField] GameObject SlashCargado;
    [SerializeField] SpawnEnemigos spawn1;
    [SerializeField] SpawnEnemigos spawn2;
    GameObject ScoreMana;
    public int disp=2;
    // Start is called before the first frame update
    void Start()
    {
        ScoreMana = GameObject.FindGameObjectWithTag("ManageScore");
        enemigos = spawn1.Enemigos + spawn2.Enemigos;
        vida = vidaMax;
        AnimPlayer = GetComponent<Animator>();
    }
    public void Golpeleft()
    {
        if(disp > 0)
        {
            AnimPlayer.SetTrigger("Left");
            Slash.transform.localScale = new Vector3(1, 1, 1);
            disp--;
            StartCoroutine(esperarleft());
        }
    }
    public void GolpeleftCargado()
    {

        if (disp == 2)
        {
            AnimPlayer.SetTrigger("Left");
            Slash.transform.localScale = new Vector3(1, 1, 1);
            disp = disp - 2;
            StartCoroutine(esperarleftCargado());
        }
    }
    public void GolpeRigth()
    {
        if (disp > 0)
        {
            AnimPlayer.SetTrigger("Rigth");
            Slash.transform.localScale = new Vector3(-1, 1, 1);
            disp--;
            StartCoroutine(esperarRigth());
        }

    }
    public void GolpeRigthCargado()
    {

        if (disp == 2)
        {
            AnimPlayer.SetTrigger("Rigth");
            Slash.transform.localScale = new Vector3(-1, 1, 1);
            disp = disp - 2;
            StartCoroutine(esperarRigthCargado());
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
    IEnumerator esperarRigthCargado()
    {
        yield return new WaitForSeconds(0.2f);

        Instantiate(SlashCargado, rigth.position, rigth.rotation);
    }
    IEnumerator esperarleftCargado()
    {
        yield return new WaitForSeconds(0.2f);

        Instantiate(SlashCargado, left.position, left.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        vidaImage.fillAmount = vida / vidaMax;
        EnemigosText.text = "Enemigos :" +enemigos;
        Score.text = "Score:" + puntos;
        
        Slashs.text="="+ disp;
        ScoreMana.GetComponent<ScoreManager>().ScoreReal = puntos;
        ScoreMana.GetComponent<ScoreManager>().Scores.Add(puntos);

        if (vida <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(left.position, Radio);
        Gizmos.DrawWireSphere(rigth.position, Radio);
    }
}
