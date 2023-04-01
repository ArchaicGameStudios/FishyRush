using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicy : MonoBehaviour
{
    public GameObject privacyMenuUI;
    private bool Isfirstgame;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("privacy"))
        {
            PlayerPrefs.SetInt("privacy", 1);
            Load();
            //e�er bir tercih yoksa muted falsea �ektik
        }
        if(PlayerPrefs.HasKey("privacy"))
        {
            Load();//e�er tercih varsa onu y�kl�yor.
        }
        if (Isfirstgame)
        {
            privacyMenuUI.SetActive(true);
            PlayerPrefs.SetInt("privacy", 0);
            Load();
        }
        else
        {
            privacyMenuUI.SetActive(false);
        }
    }
    public void Openprivacy()
    {
        privacyMenuUI.SetActive(true);

    }
    public void Closeprivacy()
    {
        Debug.Log("privacykapand�");
        privacyMenuUI.SetActive(false);
    }
    private void Load()
    {
        Isfirstgame = PlayerPrefs.GetInt("privacy") == 1;
        //muted 1e e�itse true, de�ilse false d�nd�recek
        //playerprefs bool alm�yor, o y�zden b�yle kullan�yoruz
    }
}
