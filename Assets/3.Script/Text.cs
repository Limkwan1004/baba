using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Text : Sentence
{
    Object Control_Obj;

    Character character;
    GameObject[] Char_array_left;
    GameObject[] Char_array_up;

    public GameObject[] Test;

    public bool isSentence_width = false;
    public bool isSentence_length = false;
    private void Start()
    {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Test = GameObject.FindGameObjectsWithTag("Wall");
        hit_right = Physics2D.Raycast(transform.position + Vector3.right, Vector3.left, 0.1f, LayerMask.GetMask("Action"));
        hit_left = Physics2D.Raycast(transform.position + Vector3.left, Vector3.right, 0.1f, LayerMask.GetMask("Character"));
        hit_up = Physics2D.Raycast(transform.position + Vector3.up, Vector3.down, 0.1f, LayerMask.GetMask("Character"));
        hit_down = Physics2D.Raycast(transform.position + Vector3.down, Vector3.up, 0.1f, LayerMask.GetMask("Action"));

        if (hit_right.collider != null && hit_left.collider != null)
        {
            isSentence_width = true;
            character = hit_left.collider.GetComponent<Character>();
            Char_array_left = character.Control;
            howActObj(Char_array_left, hit_right, true);
            
        }
        else isSentence_width = false;
        if (hit_up.collider != null && hit_down.collider != null)
        {
            isSentence_length = true;
            character = hit_up.collider.GetComponent<Character>();
            Char_array_up = character.Control;
            howActObj(Char_array_up, hit_down, true);
        }
        else isSentence_length = false;
        if (isSentence_length || isSentence_width) Color_Change(spriterenderer, 1);
        else Color_Change(spriterenderer, 0.45f);
 
    }

    private void howActObj(GameObject[] Char, RaycastHit2D hit, bool onoff)
    {
        for (int i = 0; i < Char.Length; i++)
        {
            Control_Obj = Char[i].GetComponent<Object>();
            if (hit.collider.name == "You_text") Control_Obj.isYouActive = onoff;
            if (hit.collider.name == "Win_text") Control_Obj.isWinActive = onoff;
            if (hit.collider.name == "Stop_text") Control_Obj.isStopActive = onoff;
            if (hit.collider.name == "Push_text") Control_Obj.isPushActive = onoff;
            
        }
    }




}
