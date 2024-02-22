using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermove : MonoBehaviour
{
    Object obj;
    Animator animator;

    private string moveX = "moveX";
    private string moveY = "moveY";

    private void Start()
    {
        obj = gameObject.GetComponent<Object>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetFloat(moveX, 1);
        animator.SetFloat(moveY, 0);
    }

    private void Update()
    {
        if(obj.isYouActive)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetFloat(moveX, -1);
                animator.SetFloat(moveY, 0);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetFloat(moveX, 1);
                animator.SetFloat(moveY, 0);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetFloat(moveX, 0);
                animator.SetFloat(moveY, 1);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                animator.SetFloat(moveX, 0);
                animator.SetFloat(moveY, -1);
            }
        }
    }




}
