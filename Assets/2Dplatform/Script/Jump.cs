using Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Collider2D coll;
    [SerializeField]
    LayerMask Ground;
    Rigidbody2D rb;
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    Animator animators;

    // Start is called before the first frame update
    void Start()
    {
        coll= GetComponent<Collider2D>();
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Checkground())
        {
            animators.SetBool("Jump",false); 
        }
        else if (!Checkground())
        {
            animators.SetBool("Jump", true);
        }
    }

    public void Jumping()
    {
        if (Checkground())
        {
            AudioManager.Instance.PlaySFX("Jump");
            rb.velocity = Vector3.up* jumpForce ;
        }
    }

    private bool Checkground()
    {
        bool onGround = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, Ground);
        return onGround; 
    }
}
