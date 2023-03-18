using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private Scene _scene;
    public GameObject _bubbleobject;
    private Animator _animator;
    AudioSource _bubblesound;
    private bool Isfirstlaunch;
    // Start is called before the first frame update
    private void Awake()
    {
        _scene= SceneManager.GetActiveScene();//caching
        _animator = _bubbleobject.GetComponent<Animator>();
        _bubblesound = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _animator.SetBool("IsStarted", false);
        if (!PlayerPrefs.HasKey("firstgame"))
        {
            PlayerPrefs.SetInt("firstgame", 1);
            Load();
            //eðer bir tercih yoksa muted falsea çektik
        }
        else
        {
            Load();//eðer tercih varsa onu yüklüyor.
        }
    }

    public void StartLevel()
    {
        //_animator.setbool("IsStarted",true);
        //bir kaç saniye bekleme
        _bubblesound.Play();
        _animator.SetBool("IsStarted", true);
        StartCoroutine(WaitForStart());
    }
    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(3.4f);
        //2sn bekleyecek
        if (Isfirstlaunch)
        {
            SceneManager.LoadScene(2);//how to play ekraný
        }
        else
        {
            SceneManager.LoadScene(_scene.buildIndex + 1); //oyun baþlayacak
        }

    }
    private void Load()
    {
        Isfirstlaunch = PlayerPrefs.GetInt("firstgame") == 1;
        //muted 1e eþitse true, deðilse false döndürecek
        //playerprefs bool almýyor, o yüzden böyle kullanýyoruz
    }

}
