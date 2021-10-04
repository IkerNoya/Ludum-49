using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumeController : MonoBehaviour
{
    SoundManager manager;
    Slider slider;

    private void Start() 
    {
        slider = GetComponent<Slider>();
        manager = FindObjectOfType<SoundManager>();
    }

    private void FixedUpdate() 
    {
        manager.volume = slider.value;
    }
}
