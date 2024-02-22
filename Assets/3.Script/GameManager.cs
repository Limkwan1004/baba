using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private AudioSource MainBGM;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            return;
        }

        MainBGM.clip = AudioManager.instance.BGMClip[(int)BGMClip.Stage1];
        MainBGM.Play();
    }
}
