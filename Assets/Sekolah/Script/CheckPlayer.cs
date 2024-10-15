using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer SpriteRenderer;

    [SerializeField]
    Sprite[] image;

    private void Start()
    {
        SpriteRenderer.sprite = image[0];
    }

    public void BukaPintu()
    { 
        SpriteRenderer.sprite = image[1];
    }

}
