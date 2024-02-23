using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCol : MonoBehaviour
{
    public bool isCheck = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            isCheck = true;
        }
    }


}
