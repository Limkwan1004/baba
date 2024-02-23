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

public class SubjectMachine : MonoBehaviour
{
    private SubjectActive _subjectact;
    public Subject_Type subject_Type;

    private void Awake()
    {
        OnEnter();
    }

    private void Update()
    {
        _subjectact.OnUpdate();
    }

    public void Change_Subject_Type(Subject_Type start_type)
    {
        if (subject_Type.Equals(start_type)) return;

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
                _subjectact = GetComponent<SubjectYou>();
                break;
            case Subject_Type.Move:
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
