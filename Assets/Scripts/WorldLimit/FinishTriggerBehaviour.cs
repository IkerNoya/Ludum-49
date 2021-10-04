using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishTriggerBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] UnityEvent finishTrigger;

    private void OnTriggerEnter(Collider other) 
    {
        if(Contains(playerMask, other.gameObject.layer))
        {
            finishTrigger?.Invoke();
            Destroy(gameObject);
        }
    }

    bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
