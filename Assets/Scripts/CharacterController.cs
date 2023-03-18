using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CharacterController : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = 5f;
    public float strength = 3.0f;


    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            direction = Vector3.down * strength;
            Debug.Log("spacee basýldý");
        }
        // mobil:
        if (Input.touchCount > 0)
        {
            Touch touch= Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.down * strength;
                Debug.Log("mobilde dokundu");
            } 
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

    }


}

