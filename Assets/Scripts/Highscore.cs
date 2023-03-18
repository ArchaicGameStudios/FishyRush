using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", 0);
            Load();
            //eðer bir highscore yoksa 0 yazýyor.
        }
        else
        {
            Load();//eðer highscore varsa onu yüklüyor.
        }

    }

    // Update is called once per frame
    private void Load()
    {
        TotalScores.highScore = PlayerPrefs.GetInt("highscore");
    }

}
