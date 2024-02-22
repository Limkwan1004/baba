using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence : MonoBehaviour
{
    public RaycastHit2D hit_right;
    public RaycastHit2D hit_left;
    public RaycastHit2D hit_up;
    public RaycastHit2D hit_down;

    public SpriteRenderer spriterenderer;
    public void Color_Change(SpriteRenderer spr, float transparent)
    {
        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, transparent);
    }
}
