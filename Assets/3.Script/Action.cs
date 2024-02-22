using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : Sentence
{
    Text text;

    private void Start()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        text = new Text();
        hit_left = Physics2D.Raycast(transform.position + Vector3.left, Vector3.right, 0.1f, LayerMask.GetMask("Is"));
        hit_up = Physics2D.Raycast(transform.position + Vector3.up, Vector3.down, 0.1f, LayerMask.GetMask("Is"));


        if (hit_up.collider != null) text = hit_up.collider.GetComponent<Text>();
        else if (hit_left.collider != null) text = hit_left.collider.GetComponent<Text>();
        if (text.isSentence_width && hit_left.collider !=null) Color_Change(spriterenderer, 1);
        else if (text.isSentence_length && hit_up.collider !=null) Color_Change(spriterenderer, 1);
        else Color_Change(spriterenderer, 0.45f);
    }
}
