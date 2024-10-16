using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private float _speed;

    private float move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        Vector2 inputVector = Vector2.right * move;

        if (inputVector == Vector2.zero) return;


        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float movedistance;

        movedistance = Time.deltaTime * _speed;

        transform.position += moveDir * movedistance;


        transform.right = moveDir;
    }

    public void HeadTo(float dir)
    {
        move = dir;
        animator.SetInteger("Move", (int)move);
    }
}
