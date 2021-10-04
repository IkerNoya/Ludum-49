using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLimitBehaviour : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float yOffSet;
    [SerializeField] LayerMask playerMask;
    float lastMaxYPosition;

    private void FixedUpdate() 
    {
        if(target.position.y > lastMaxYPosition)
            lastMaxYPosition = target.position.y;
        //
        transform.position = new Vector3(
                            target.position.x,
                            lastMaxYPosition - yOffSet,
                            target.position.z);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(Contains(playerMask, other.gameObject.layer))
        {
            IHitabble hitabble;
            if(other.TryGetComponent<IHitabble>(out hitabble))
            {
                hitabble.Hit();
            }
        }
    }

    bool Contains(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
