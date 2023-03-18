using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMovement : MonoBehaviour
{
    public float bottlespeedx = 3.0f;
    public float bottlespeedy = 1.5f;
    private float leftEdge;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        //ekranýn sol köþesi

    }
    private void Update()
    {   transform.position += new Vector3(-1 * bottlespeedx * Time.deltaTime,-1 * bottlespeedy* Time.deltaTime,0);
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }

    }
}
