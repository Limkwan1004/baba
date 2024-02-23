using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verb : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _rightCol;
    [SerializeField] private CircleCollider2D _leftCol;
    [SerializeField] private CircleCollider2D _upCol;
    [SerializeField] private CircleCollider2D _downCol;

    public SpriteRenderer spriterenderer;

    public void Color_Change(SpriteRenderer spr, float transparent)
    {
        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, transparent);


    }
}
