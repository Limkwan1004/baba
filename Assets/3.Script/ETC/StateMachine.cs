using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface Istate
{
    public void OnEnter();
    public void OnUpdate();
    public void OnExit();
}

public class StateMachine : MonoBehaviour
{
}
