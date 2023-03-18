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
            //e�er bir highscore yoksa 0 yaz�yor.
        }
        else
        {
            Load();//e�er highscore varsa onu y�kl�yor.
        }

    }

    // Update is called once per frame
    private void Load()
    {
        TotalScores.highScore = PlayerPrefs.GetInt("highscore");
    }

}
