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
            //e�er bir tercih yoksa muted false �ektik
        }
        else
        {
            Load();//e�er tercih varsa onu y�kl�yor.
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



    //playerprefleri ak�lda tutmak i�in:

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
        //muted 1e e�itse ture, de�ilse false d�nd�recek
        //playerprefs bool alm�yor, o y�zden b�yle kullan�yoruz
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        //muted true ise 1, false ise 0 de�erini atar
    }
}
