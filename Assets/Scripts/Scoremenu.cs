using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoremenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoretext;
    [SerializeField] private TextMeshProUGUI _highscoretext;
    public GameObject _newhightext;
    private void OnEnable()
    {
        _newhightext.SetActive(false);
        if (TotalScores.totalScore > TotalScores.highScore)
        {
            _newhightext.SetActive(true);
            TotalScores.highScore = TotalScores.totalScore;
            PlayerPrefs.SetInt("highscore", TotalScores.highScore);
        }
        //her active edildiðinde yeniden yazacak.
        _scoretext.text = "your score is " + TotalScores.totalScore.ToString();
        _highscoretext.text = "high score is" + TotalScores.highScore.ToString();
    }
}
