using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager Instance;
    public float volume;

    private void Awake() 
    {
        if(Instance != null)
            Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeVolume(float value)
    {
        volume = value;
    }
}
