using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;
using System.Threading;

public class Scoring : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textscore;
    //public GameObject[] LifeObjects;
    public List<GameObject> LifeObjects = new List<GameObject>();
    private bool coroutineRunning = false;
    public static bool Isgameover;
    public GameObject _scriptObject;
    LevelEditor editorScript;
    //audiosoruce eklenir:
    public AudioSource _bottlesound;
    public AudioSource _addlifesound;
    public AudioSource _subslifesound;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        TotalScores.totalScore = 0;
        TotalScores.lives = 3;
        Isgameover = false;
        editorScript = _scriptObject.GetComponent<LevelEditor>();
        //_bottlesound = gameObject.GetComponent<AudioSource>();
        //_addlifesound = gameObject.GetComponent<AudioSource>();
        //_subslifesound = gameObject.GetComponent<AudioSource>();
        for (int i = 0; i < TotalScores.lives; i++)
        {
            LifeObjects[i].SetActive(true); //set all active so that current lives are represented
        }//tüm kalpleri active yapýyorum(baþta)


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Obstacle")) && (!coroutineRunning)) //corutinede deðilse ve engele çarparsa
        {
            if (TotalScores.lives <= 3 & TotalScores.lives > 0)
            {
                substractLife();
                StartCoroutine(WaitDamage());
            }

        }
        else if (other.gameObject.CompareTag("Scoring"))
        {
            //FindObjectOfType<Scoring>().IncreaseScore();
            TotalScores.totalScore++;
            _textscore.text = "Score " + TotalScores.totalScore.ToString();
            Debug.Log("start:" + Time.time);
        }
        else if (other.gameObject.CompareTag("Artican"))
        {
            if (TotalScores.lives <= 2 & TotalScores.lives >= 0)
            {
                addLife();
            }
            Destroy(other.gameObject);
            //FindObjectOfType<Scoring>().Healthgain();
        }
        //else if (other.gameObject.CompareTag("Zemin"))
        //{
        //    substractLife();
        //    transform.position = Vector3.zero;
        //    //FindObjectOfType<Scoring>().Zemintouch();
        //    StartCoroutine(WaitDamage());
        //}
        else if (other.gameObject.CompareTag("Sise"))
        {
            _bottlesound.Play();
            TotalScores.totalScore += 100;
            Destroy(other.gameObject);
            
        }

    }
    public bool substractLife()
    {
        _subslifesound.Play();
        TotalScores.lives--;
        LifeObjects[TotalScores.lives].SetActive(false);
        if (TotalScores.lives == 0)
        {
            editorScript.GameIsOver();
        }
        return Isgameover = TotalScores.lives == 0; //directly return if we are dead or not.
    }
    public void addLife()
    {
        _addlifesound.Play();
        LifeObjects[TotalScores.lives].SetActive(true);
        //0,1,2 indexinden dolayý: 3 can varsa 2. elemanýn açýk olmasý gerekir.
        TotalScores.lives++;

    }


    //if(!player.substractLife()) {
    //   //gameOver 
    //   }
    IEnumerator WaitDamage()
    {
        coroutineRunning = true;
        _animator.SetBool("Isdead", true);
        yield return new WaitForSeconds(2);
        _animator.SetBool("Isdead", false);
        //spawninternal kadar bekleyip loopun baþýna dönüyor
        coroutineRunning = false;
        //2saniye boyunca corutine true oluyor dolaysýsyýla 2saniye boyunca yanamýyor.
    }


}
