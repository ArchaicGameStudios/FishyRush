using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject prefab;
    public float spawnRate = 1f;

    //crating a list of object for corals
    public GameObject[] gameObjects;
    private int objectIndex;

    //public float minHeight = -1f;
    //public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        
        objectIndex = Random.Range(0, gameObjects.Length);
        GameObject coral = Instantiate(gameObjects[objectIndex], transform.position, Quaternion.identity);
        //if (coral.CompareTag("Zorengel"))
        //{
        //    new WaitForSeconds(5);
        //    Debug.Log("5sn bekledi");
        //}

        //coral.transform.position += Vector3.up * Random.Range(minHeight,maxHeight);
        //rastgele bir obje seçmesi için rastgele index no atayacak (min inclusive, max exclusive)

    }
}
