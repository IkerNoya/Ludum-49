using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartTriggerBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] UnityEvent startTrigger;

    private void OnTriggerEnter(Collider other) 
    {
        if(Contains(playerMask, other.gameObject.layer))
        {
            startTrigger?.Invoke();
            Destroy(gameObject);
        }
    }

    bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
