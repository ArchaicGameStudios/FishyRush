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
            //e�er bir tercih yoksa muted falsea �ektik
        }
        else
        {
            Load();//e�er tercih varsa onu y�kl�yor.
        }
    }

    public void StartLevel()
    {
        //_animator.setbool("IsStarted",true);
        //bir ka� saniye bekleme
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
            SceneManager.LoadScene(2);//how to play ekran�
        }
        else
        {
            SceneManager.LoadScene(_scene.buildIndex + 1); //oyun ba�layacak
        }

    }
    private void Load()
    {
        Isfirstlaunch = PlayerPrefs.GetInt("firstgame") == 1;
        //muted 1e e�itse true, de�ilse false d�nd�recek
        //playerprefs bool alm�yor, o y�zden b�yle kullan�yoruz
    }

}
