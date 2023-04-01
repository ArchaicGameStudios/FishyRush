using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoroutine : MonoBehaviour
{

    //crating a list of object for corals
    public GameObject[] gameObjects;
    //rastgele bir say� �retip bunu objeckindex olarak kullanacak
    private int objectIndex;
    //couritinede ne kadar bekleyece�i
    public float spawnInternal = 0.3f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
        //StopAllCoroutines() or ;
        //StopCoroutine(_coralcoroutine);
    }

    //private void OnEnable()
    //{
    //    _coralcoroutine = StartCoroutine(SpawnObjects());
    //}

    //private void OnDisable()
    //{
    //    StopCoroutine(_coralcoroutine);
    //}
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            objectIndex = Random.Range(0, gameObjects.Length);
            Debug.Log(objectIndex);
            GameObject Objecttospawn = gameObjects[objectIndex];
            if (Objecttospawn.CompareTag("Mercan"))
            {
                yield return new WaitForSeconds(1f);
                //�ncesinde de 1sn bekleyecek
                spawnInternal = (2f );
                //sonras�nda 2sn bekleyecek
            }
            else
            {

                spawnInternal = 1f;
            }
            GameObject spawnedobject = Instantiate(Objecttospawn, transform.position, Quaternion.identity);
            //objenin kopyas�n� olu�turuyor
            Debug.Log("spawn internal is: "+ spawnInternal);
            yield return new WaitForSeconds(spawnInternal);
            //spawninternal kadar bekleyip loopun ba��na d�n�yor
        }

    }
}
