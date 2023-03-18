using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectheight;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log(screenBounds.y);//ekran y�ksekli�i 10 ise 5 getiriyor, orta 0 noktas� -5/5 aras� ekran
        objectheight = transform.GetComponent<SpriteRenderer>().bounds.size.y /2;
        //objenin y�ksekli�ini ald�k
    }

    private void LateUpdate()
    {
        Vector3 viewpos = transform.position;
        viewpos.y = Mathf.Clamp(viewpos.y, screenBounds.y * -1 +objectheight, screenBounds.y - objectheight);
        transform.position = viewpos;
    }
}
