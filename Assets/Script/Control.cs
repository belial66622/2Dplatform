using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Jump),typeof(Movement))]
public class Control : MonoBehaviour
{

    private Movement move;
    private Jump jump;
    bool blockcontrol;
    [SerializeField]
    bool OnAndroid;

    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement>();
        jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!OnAndroid)
        {
            if (!blockcontrol)
            {
                direction = 0;
                if (Input.GetKey(KeyCode.A))
                {
                    direction = -1;
                }

                else if (Input.GetKey(KeyCode.D))
                {
                    direction = 1;
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    jump.Jumping();
                }
                move.HeadTo(direction);
            }
        }
        else
        {
            if (!blockcontrol)
            {
                move.HeadTo(direction);
            }
            else 
            {
                move.HeadTo(0);
            }
        }
    }

    public void ControlBlock(bool condition)
    {
        blockcontrol = condition;
    }

    public void Direction(float dir)
    { 
        direction= dir;
    }

    public void Jump()
    {
        if (!blockcontrol)
        {
            jump.Jumping(); 
        }
    }

}
