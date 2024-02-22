using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGMClip
{
    Stage1 = 0,
    Stage2,
    Stage3,
    Stage4,
    Stage5,
    Stage6
}

public enum SFXClip
{
    
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioClip[] _bgmClips;

    public AudioClip[] _sfxClips;

    public AudioSource[] _sfxPanel;
    public AudioSource[] _bgmPanel;

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
    }
}
