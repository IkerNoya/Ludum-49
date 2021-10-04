using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource aSource;
    SoundManager manager;

    private void Start() 
    {
        aSource = GetComponent<AudioSource>();
        manager = FindObjectOfType<SoundManager>();
    }

    private void FixedUpdate() 
    {
        aSource.volume = manager.volume;
    }

    public void StartSound()
    {
        aSource.Play();
    }

    public void StopSoound()
    {
        aSource.Stop();
    }
}
