using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corals : MonoBehaviour
{
    public float coralSpeed = 10.0f;
    private float leftEdge;
    //Random.Range(0.0F, 1.0F) < 0.5F ? 90.0F : -90.0F;
    private float rotationAngle;
    private float heartOlasýlýk;
    //this.gameObject.transform.GetChild(0);(0. çocuga ulaþmak için)

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        rotationAngle = Random.Range(0.0F, 1.0F) < 0.5F ? 0.0f : 180.0f;
        //0 ile 1 arasý sayý seç, 0.5den küçük ise rotation angle= 0; büyük ise rotation angle= 180.0f. yani ya ayný kalacak(0) ya da 180 derece döndürülecek (180)
        transform.Rotate(0.0f, 0.0f, rotationAngle);
        if ( gameObject.tag == "Mercan")
        {
            heartOlasýlýk = Random.Range(0.0F, 1.0F) < 0.3f ? 0.0f : 1.0f;
            if (heartOlasýlýk == 0.0f)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                //Debug.Log("aktivedildi");
            }

        }
    }
    private void Update()
    {
        transform.position += Vector3.left * coralSpeed * Time.deltaTime;
        if (transform.position.x <leftEdge)
        {
            Destroy(gameObject);
        }

    }

}
