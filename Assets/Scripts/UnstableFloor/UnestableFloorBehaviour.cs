using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnestableFloorBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask playerMask;
    [SerializeField] float waitToDestroy;
    [SerializeField] UnityEvent destroyEvent;

    private void OnCollisionEnter(Collision other) 
    {
        if(Contains(playerMask, other.gameObject.layer))
        {
            StartCoroutine(InDestroy());
        }
    }

    bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }

    IEnumerator InDestroy()
    {
        yield return new WaitForSeconds(waitToDestroy);
        //

        destroyEvent?.Invoke();
    }
}
