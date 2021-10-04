using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLose : MonoBehaviour, IHitabble
{
    [SerializeField] UnityEvent loseEvent;

    public void Hit()
    {
        loseEvent?.Invoke();
    }
}
