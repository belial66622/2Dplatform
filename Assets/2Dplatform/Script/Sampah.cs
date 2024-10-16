using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sampah : MonoBehaviour
{

    public UnityEvent picked;


    public void Picked()
    { 
        picked?.Invoke();
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Detectdamage>(out Detectdamage detect))
        {
            AudioManager.Instance.PlaySFX("Picked");
            Picked();
        }
    }
}
