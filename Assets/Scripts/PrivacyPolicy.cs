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
            //eðer bir tercih yoksa muted falsea çektik
        }
        if(PlayerPrefs.HasKey("privacy"))
        {
            Load();//eðer tercih varsa onu yüklüyor.
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
        Debug.Log("privacykapandý");
        privacyMenuUI.SetActive(false);
    }
    private void Load()
    {
        Isfirstgame = PlayerPrefs.GetInt("privacy") == 1;
        //muted 1e eþitse true, deðilse false döndürecek
        //playerprefs bool almýyor, o yüzden böyle kullanýyoruz
    }
}
