using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private float animationSpeed = 0.1f;

    private void Awake()
    {
        meshRenderer= GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2 (animationSpeed * Time.deltaTime, 0);
        //Debug.Log( "offsetlendi" );
    }
}
