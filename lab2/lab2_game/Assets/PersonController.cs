using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public Animator animator;
    private int _state;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift) )
            {
                _state = 2;
            }
            else
            {
                _state = 1;
            }
        }
        else
        {
            _state = 0;
        }
        animator.SetInteger("state", _state);
    }
}
