using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Character : Sentence
{
    public GameObject[] Control;
    public Object[] Conbool;

    Text text;

    private void Start()
    { 
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        for (int i = 0; i < Control.Length; i++)
        {
            Conbool[i] = Control[i].GetComponent<Object>();
        }

    }
    void Update()
    {
        text = new Text();
        hit_right = Physics2D.Raycast(transform.position + Vector3.right, Vector3.left, 0.1f, LayerMask.GetMask("Is"));
        hit_down = Physics2D.Raycast(transform.position + Vector3.down, Vector3.up, 0.1f, LayerMask.GetMask("Is"));


        if (hit_down.collider != null) text = hit_down.collider.GetComponent<Text>();
        else if (hit_right.collider != null) text = hit_right.collider.GetComponent<Text>();
        if (text.isSentence_width && hit_right.collider != null) Color_Change(spriterenderer, 1);
        else if (text.isSentence_length && hit_down.collider != null) Color_Change(spriterenderer, 1);
        else {
            Color_Change(spriterenderer, 0.45f);
            for (int i = 0; i < Conbool.Length; i++)
            {
                Conbool[i].isPushActive = false;
                Conbool[i].isWinActive = false;
                Conbool[i].isStopActive = false;
                Conbool[i].isYouActive = false;
            }
        }
    }
}
