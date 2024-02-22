using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;


public class Object : MonoBehaviour
{
    public Tilemap tilemap;
    private float distance = 0.3f;
    private float Speed = 7f;

    SpriteRenderer spriterenderer;

    public bool isYouActive = false;
    public bool isDefeatActive = false;
    public bool isStopActive = false;
    public bool isPushActive = false;
    public bool isNoActive = false;
    public bool isWinActive = false;

    private Vector3Int Left;  // ¿ÞÂÊ
    private Vector3Int Right;
    private Vector3Int Up;
    private Vector3Int Down;

    Vector2 relativePosition;
    Vector2 col_Position;
    Vector2 this_Positionl;

    Vector3Int currentPosition;

    private Object coltrigger;

    RaycastHit2D hit_right;
    RaycastHit2D hit_left;
    RaycastHit2D hit_up;
    RaycastHit2D hit_down;

    Animator animator;
    private string moveX = "moveX";
    private string moveY = "moveY";

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetFloat(moveX, 1);
        animator.SetFloat(moveY, 0);
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {        
        currentPosition = tilemap.WorldToCell(transform.position);
        Left = currentPosition + new Vector3Int(-1, 0, 0);
        Right = currentPosition + new Vector3Int(1, 0, 0);
        Up = currentPosition + new Vector3Int(0, 1, 0);
        Down = currentPosition + new Vector3Int(0, -1, 0);

    }
    private void Update()
    {
        Object col_obj1 = new Object();
        Object col_obj2 = new Object();
        Object col_obj3 = new Object();
        Object col_obj4 = new Object();
        hit_right = Physics2D.Raycast(transform.position + Vector3.right, Vector3.left, 0.1f);
        hit_left = Physics2D.Raycast(transform.position + Vector3.left, Vector3.right, 0.1f);
        hit_up = Physics2D.Raycast(transform.position + Vector3.up, Vector3.down, 0.1f);
        hit_down = Physics2D.Raycast(transform.position + Vector3.down, Vector3.up, 0.1f);

        if (hit_right.collider != null) col_obj1 = hit_right.collider.GetComponent<Object>();
        if (hit_left.collider != null) col_obj2 = hit_left.collider.GetComponent<Object>();
        if (hit_up.collider != null) col_obj3 = hit_up.collider.GetComponent<Object>();
        if (hit_down.collider != null) col_obj4 = hit_down.collider.GetComponent<Object>();
        if (isYouActive)
        {
            spriterenderer.sortingOrder = 3;
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !col_obj2.isStopActive)
            {
                if (gameObject.name == "BABA")
                {
                    animator.SetFloat(moveX, -1);
                    animator.SetFloat(moveY, 0);
                }
                StartCoroutine(Move(transform.position, Left));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && !col_obj1.isStopActive)
            {
                if (gameObject.name == "BABA")
                {
                    animator.SetFloat(moveX, 1);
                    animator.SetFloat(moveY, 0);
                }
                StartCoroutine(Move(transform.position, Right));
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && !col_obj3.isStopActive)
            {
                if (gameObject.name == "BABA")
                {
                    animator.SetFloat(moveX, 0);
                    animator.SetFloat(moveY, 1);
                }
                StartCoroutine(Move(transform.position, Up));
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && !col_obj4.isStopActive)
            {
                if (gameObject.name == "BABA")
                {
                    animator.SetFloat(moveX, 0);
                    animator.SetFloat(moveY, -1);
                }
                StartCoroutine(Move(transform.position, Down));
            }
        }
        else spriterenderer.sortingOrder = 0;
    }
    
    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        this_Positionl = transform.position;
        col_Position = otherCollider.transform.position;
        relativePosition = col_Position - this_Positionl;
        coltrigger = otherCollider.GetComponent<Object>();
        if (isYouActive && coltrigger.isWinActive) SceneManager.LoadScene("Map");
        if (isDefeatActive) Destroy(otherCollider.gameObject);        
        if (isNoActive)
        {
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }
        if (isPushActive)
        {
            if (Mathf.Abs(relativePosition.x) > Mathf.Abs(relativePosition.y))
            {
                if (relativePosition.x > 0) StartCoroutine(Push(transform.position, Left));
                else StartCoroutine(Push(transform.position, Right));
            }
            else
            {
                if (relativePosition.y > 0) StartCoroutine(Push(transform.position, Down));
                else StartCoroutine(Push(transform.position, Up));
            }
        }
    }

    public IEnumerator Push(Vector3 Current, Vector3Int Arrow)
    {
        isPushActive = false;
        while (distance <= 1f)
        {
            distance += Speed * Time.deltaTime;
            Vector3 target = tilemap.GetCellCenterWorld(Arrow);

            transform.position = Vector3.Lerp(Current, target, distance);
            yield return null;
        }
        distance = 0.3f;
        isPushActive = true;
    }

    public IEnumerator Move(Vector3 Current, Vector3Int Arrow)
    {
        isYouActive = false;
        while (distance <= 1f)
        {
            distance += Speed * Time.deltaTime;
            Vector3 target = tilemap.GetCellCenterWorld(Arrow);

            transform.position = Vector3.Lerp(Current, target, distance);
            yield return null;
        }
        distance = 0.3f;
        isYouActive = true;
    }
}
