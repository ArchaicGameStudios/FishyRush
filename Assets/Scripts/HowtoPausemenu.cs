using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowtoPausemenu : MonoBehaviour
{
    //pause men�s�nden how to playe eri�mek i�in
    public List<GameObject> Scenes = new List<GameObject>();
    private int SceneIndex;
    private AudioSource _arrowsound;
    //public List<GameObject> LifeObjects = new List<GameObject>();
    //for (int i = 0; i<TotalScores.lives; i++)
    //   {
    //       LifeObjects[i].SetActive(true); //set all active so that current lives are represented
    //   }//t�m kalpleri active yap�yorum(ba�ta)

    // Start is called before the first frame update
    private void Awake()
    {
        _arrowsound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        //her active edildi�inde ilk indexten ba�layacak
        for (int i = 0; i < Scenes.Count; i++) //
        {
            Scenes[i].SetActive(false); //set all deactive expect the first(0) one
        }
        Scenes[0].SetActive(true);
        SceneIndex = 0;
    }
    public void forward()
    {
        if (SceneIndex < Scenes.Count - 1 && SceneIndex >= 0)
        {
            Scenes[SceneIndex + 1].SetActive(true);
            Scenes[SceneIndex].SetActive(false);
            SceneIndex++;
            _arrowsound.Play();
        }
        //bu aral�k d���ndaysa arrowlar� gizleyebilirim?

    }
    public void backward()
    {
        if (SceneIndex < Scenes.Count && SceneIndex > 0)
        {
            Scenes[SceneIndex - 1].SetActive(true);
            Scenes[SceneIndex].SetActive(false);
            SceneIndex--;
            _arrowsound.Play();
        }
    }
    public void backtomainmenu()
    {
        //oklar yapacaklar�n� yapacak
        transform.gameObject.SetActive(false);
    }

    //private IEnumerator Bactomain()
    //{
    //    _menusound.Play();
    //    yield return new WaitForSeconds(0.1f);
    //    transform.gameObject.SetActive(false);
    //}

}
