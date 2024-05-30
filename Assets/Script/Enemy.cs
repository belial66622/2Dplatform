using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Collider2D colliders;

    [SerializeField]
    LayerMask ground;

    bool alive = true;
    int faceright = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
    }

    public void Death()
    {

        colliders.enabled= false;
        alive = !alive;
        StartCoroutine(death(2));

    }

    IEnumerator death(float t)
    { 
        float time = 0;
        while (t>time)
        {
            transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(0,180,time/(t*.1f)));
            if (transform.eulerAngles.z >= 170)
            {
                transform.position += Vector3.down * Time.deltaTime * 5;
            }
            else
            {
                transform.position -= Vector3.down * Time.deltaTime * 5;
            }
            time += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }

    private void Move()
    {
        if (!alive) return;
        transform.position += transform.right*Time.deltaTime*5;

        bool turn = Physics2D.Raycast(transform.position, transform.right, .5f,ground);
        
        if(turn)
        {
            transform.right = Vector3.right * faceright;

            faceright *= -1;
        }
    }
}
