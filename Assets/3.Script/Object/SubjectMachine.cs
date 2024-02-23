using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Subject_Type
{
    Win = 0,
    Defeat,
    You,
    Move,
    Push,
    Stop,

}

public class SubjectMachine : MonoBehaviour, Istate
{
    private SubjectMove _subjectMove;
    public Subject_Type subject_Type;

    private void Awake()
    {
        TryGetComponent(out _subjectMove);
    }

    private void Update()
    {
        OnUpdate();
    }

    public void Change_Subject_Type(Subject_Type start_type)
    {
        if (subject_Type.Equals(start_type)) return;

        OnExit();
        subject_Type = start_type;
        OnEnter();
    }

    public void OnEnter()
    {
        switch (subject_Type)
        {
            case Subject_Type.Win:
                break;
            case Subject_Type.Defeat:
                break;
            case Subject_Type.You:
                break;
            case Subject_Type.Move:
                _subjectMove.MoveTile();
                break;
            case Subject_Type.Push:
                break;
            case Subject_Type.Stop:
                break;
            default:
                break;
        }
    }

    public void OnExit()
    {
        switch (subject_Type)
        {
            case Subject_Type.Win:
                break;
            case Subject_Type.Defeat:
                break;
            case Subject_Type.You:
                break;
            case Subject_Type.Move:
                _subjectMove.MoveTile();
                break;
            case Subject_Type.Push:
                break;
            case Subject_Type.Stop:
                break;
            default:
                break;
        }
    }

    public void OnUpdate()
    {
        switch (subject_Type)
        {
            case Subject_Type.Win:
                break;
            case Subject_Type.Defeat:
                break;
            case Subject_Type.You:
                break;
            case Subject_Type.Move:
                _subjectMove.MoveTile();
                break;
            case Subject_Type.Push:
                break;
            case Subject_Type.Stop:
                break;
            default:
                break;
        }
    }




}
