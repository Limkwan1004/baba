using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectMove : MonoBehaviour
{
    private Animator _animator;

    private float _moveSpeed = 7f;
    private bool isMove = false;

    private IEnumerator _moveTemp;

    private void Awake()
    {
        TryGetComponent(out _animator);
    }

    public void MoveTile()
    {
        if (!isMove)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AniBlend(-1f, 0f);
                MoveT(transform.position + Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AniBlend(1f, 0f);
                MoveT(transform.position + Vector3.right);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                AniBlend(0f, 1f);
                MoveT(transform.position + Vector3.up);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                AniBlend(0f, -1f);
                MoveT(transform.position + Vector3.down);
            }
        }
    }

    private void AniBlend(float x, float y)
    {
        _animator.SetFloat("moveX", x);
        _animator.SetFloat("moveY", y);
    }

    private void MoveT(Vector3 arrow)
    {
        _moveTemp = Move_co(arrow);
        StartCoroutine(_moveTemp);
    }

    private IEnumerator Move_co(Vector3 direction)
    {
        isMove = true;
        float distance = 0;
        Vector3 current_Pos = transform.position;

        while (distance <= 1f)
        {
            distance += _moveSpeed * Time.fixedDeltaTime;

            transform.position = Vector3.Lerp(current_Pos, direction, distance);
            yield return new WaitForFixedUpdate();
        }
        isMove = false;
    }
}
