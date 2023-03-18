using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Howtoplay : MonoBehaviour
{
    //public Image[] Scenes;
    public List<GameObject> Scenes = new List<GameObject>();
    private int SceneIndex;
    private AudioSource _arrowsound;
    //public List<GameObject> LifeObjects = new List<GameObject>();
    //for (int i = 0; i<TotalScores.lives; i++)
    //   {
    //       LifeObjects[i].SetActive(true); //set all active so that current lives are represented
    //   }//tüm kalpleri active yapýyorum(baþta)

    // Start is called before the first frame update
    private void Awake()
    {
        _arrowsound= GetComponent<AudioSource>();
    }
    void Start()
    {
        PlayerPrefs.SetInt("firstgame", 0);
        for (int i = 0; i < Scenes.Count ; i++) //
        {
            Scenes[i].SetActive(false); //set all deactive expect the first(0) one
        }
        Scenes[0].SetActive(true);
        SceneIndex = 0;

    }
    public void forward()
    {
        if (SceneIndex < Scenes.Count -1 && SceneIndex >= 0)
        {
            Scenes[SceneIndex + 1].SetActive(true);
            Scenes[SceneIndex].SetActive(false);
            SceneIndex++;
            _arrowsound.Play();
        }
        //bu aralýk dýþýndaysa arrowlarý gizleyebilirim?

    }
    public void backward()
    {
        if (SceneIndex < Scenes.Count && SceneIndex > 0)
        {
            Scenes[SceneIndex -1].SetActive(true);
            Scenes[SceneIndex].SetActive(false);
            SceneIndex--;
            _arrowsound.Play();
        }
    }
    public void startgame()
    {
        //oklar yapacaklarýný yapacak
        SceneManager.LoadScene(1);
    }

}
