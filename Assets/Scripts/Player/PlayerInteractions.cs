using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] UnityEvent pauseGame;

    private void Update() 
    {
        if(Input.GetKeyDown(pauseKey))
            pauseGame?.Invoke();
    }
}
