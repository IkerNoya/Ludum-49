using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float followSpeed = 0;
    [SerializeField] private float xOffset = 0;
    [SerializeField] private float yOffset = 0;

    Vector3 newPos = Vector3.zero;

    private void Start()
    {
        newPos = new Vector3(target.position.x - xOffset, target.position.y + yOffset, target.position.z);
        transform.position = newPos;
    }
    private void LateUpdate()
    {
        newPos = new Vector3(target.position.x - xOffset, target.position.y + yOffset, target.position.z);
        transform.position = newPos;
        transform.LookAt(target.position);
    }
}
