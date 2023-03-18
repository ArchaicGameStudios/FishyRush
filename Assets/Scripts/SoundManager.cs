using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundonIcon;
    [SerializeField] Image soundoffIcon;
    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
            //eðer bir tercih yoksa muted false çektik
        }
        else
        {
            Load();//eðer tercih varsa onu yüklüyor.
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }
    public void SoundButtonPress()
    {
        if (!muted) 
        {
            muted= true;
            AudioListener.pause = true;
        }
        else
        {
            muted= false;
            AudioListener.pause = false;
        }
        Save();//tercihleri kaydediyor
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (!muted)
        {
            soundonIcon.enabled = true;
            soundoffIcon.enabled = false;
        }
        else
        {
            soundonIcon.enabled = false;
            soundoffIcon.enabled = true;

        }
    }



    //playerprefleri akýlda tutmak için:

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
        //muted 1e eþitse ture, deðilse false döndürecek
        //playerprefs bool almýyor, o yüzden böyle kullanýyoruz
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        //muted true ise 1, false ise 0 deðerini atar
    }
}
