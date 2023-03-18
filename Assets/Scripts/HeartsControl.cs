using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        //gameObject.transform.GetChild();
        //reach to the child
        switch (TotalScores.lives)
        {
            case 3:
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                Debug.Log("can sayýsý" + TotalScores.lives);
                break;
            case 2:
                Debug.Log("can sayýsý" + TotalScores.lives);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 1:
                Debug.Log("can sayýsý" + TotalScores.lives);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 0:
                Debug.Log("can sayýsý" + TotalScores.lives);
                //gameover
                break;
            default:
                Debug.Log("can sayýsý" + TotalScores.lives);
                break;
        }

    }
}
