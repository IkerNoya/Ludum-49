using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnestableFloorManager : MonoBehaviour
{
    Rigidbody rb = null;
    public void DestroyProcces(float time)
    {
        if (rb == null) rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;

        Destroy(gameObject, time);
    }
}
