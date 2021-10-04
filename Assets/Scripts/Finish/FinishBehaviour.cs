using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] UnityEvent finishGame;

    private void OnTriggerEnter(Collider other) 
    {
        if(Contains(playerMask, other.gameObject.layer))
        {
            finishGame?.Invoke();
        }
    }

    bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
