using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawn : MonoBehaviour
{
    public GameObject _bottle;
    //public float spawnratebottle= 1f;
    public int maxspawnBottle = 50;
    public int minspawnBottle = 100;
    public int spawnBottle;
    public float minrange = -2f;
    public float maxrange = +2f;

    private void Start()
    {
        StartCoroutine(SpawnBottles());
        //StopAllCoroutines() or ;
        //StopCoroutine(_coralcoroutine);
    }
    //private void OnEnable()
    //{
    //    InvokeRepeating(nameof(SpawnBottle), 1f, spawnratebottle);
    //}

    //private void OnDisable()
    //{
    //    CancelInvoke(nameof(SpawnBottle));
    //}

    //void SpawnBottle()
    //{ 
    //    GameObject newbottle = Instantiate(_bottle, transform.position, Quaternion.identity);
    //    Debug.Log("bottleposition1.ci=  " + newbottle.transform.position) ;
    //    newbottle.transform.position += Vector3.right * Random.Range(minrange, maxrange);
    //    Debug.Log("bottlepositionson 2.ci=  " + newbottle.transform.position);
    //}
    IEnumerator SpawnBottles()
    {
        while (true)
        {
            spawnBottle = Random.Range (maxspawnBottle, minspawnBottle);
            Debug.Log("spawnbottle  " + spawnBottle);
            yield return new WaitForSeconds(spawnBottle);
            GameObject newbottle = Instantiate(_bottle, transform.position, Quaternion.identity);
            newbottle.transform.position += Vector3.right * Random.Range(minrange, maxrange);
        }
    }
}
