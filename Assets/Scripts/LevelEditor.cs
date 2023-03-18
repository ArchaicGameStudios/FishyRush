using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEditor : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject scoreMenuUI;
    public GameObject howtoMenuUI;
    public bool IsGameoverscreen= false;
    public AudioSource _audiobutton;
    public AudioSource gameoversound;

    //ses gelecek
    private Scene _scene;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();//caching
        //audiolarý cashlemedim çünkü sürükle býrak ile eþleþtirdim. cachleyince hangi elemeaný alacaðýný kontrol edemiyorsun

    }
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        scoreMenuUI.SetActive(false);
        howtoMenuUI.SetActive(false);

    }
    public void GameIsOver()
    {
        gameoversound.Play();
        IsGameoverscreen = true;
        GameIsPaused= true;
        Time.timeScale = 0f;
        scoreMenuUI.SetActive(true);
        Debug.Log("gameoverfunctionnçalýþtý");
        //highscore yaz


    }

    public void Pause()
    {
        if (!GameIsPaused)
        {   //oyunun durmasý, pause menünün gelmesi, ve Pauseun true olmasý
            _audiobutton.Play();
            //veya playoneshot
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

    }
    public void Resume()
    {
        if (GameIsPaused)
        {
            
            if (IsGameoverscreen)
            {
                GameIsPaused = false;
                IsGameoverscreen = false;
                Debug.Log("gameover-resume");
                StartCoroutine(Replaywait());
            } //oyunun deveam etmesi, pause menünün gitmesi, ve Pauseun false olmasý
            else
            {
                _audiobutton.Play();
                Time.timeScale = 1f;
                GameIsPaused = false;
                pauseMenuUI.SetActive(false);
            }
        }

    }
    public void Replay()
    {
        GameIsPaused = false;
        IsGameoverscreen = false;
        StartCoroutine(Replaywait());
        Debug.Log("replay");
    }
    public void Scores()
    {
        _audiobutton.Play();
        pauseMenuUI.SetActive(false);
        scoreMenuUI.SetActive(true);

        Debug.Log("scores");
    }
    public void Howtoplay()
    {
        Debug.Log("howto");
        _audiobutton.Play();
        howtoMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        _audiobutton.Play();
        Debug.Log("quitgame");
        Application.Quit();

    }
    public void GoHomePage()
    {
        _audiobutton.Play();
        pauseMenuUI.SetActive(true);
        scoreMenuUI.SetActive(false);
        Debug.Log("gohomepage");

    }
    public void DelPlayerPref()
    {
        PlayerPrefs.DeleteAll();
    }
    private IEnumerator Replaywait()
    {
        _audiobutton.Play();
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.1f);
        Debug.Log("01sn beklendi");
        SceneManager.LoadScene(_scene.buildIndex);
    }
    //private IEnumerator Howtowait()
    //{
    //    _audiobutton.Play();
    //    yield return new WaitForSeconds(0.1f);
    //    howtoMenuUI.SetActive(true);
    //}

}
