using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float movementForce = 0;
    [SerializeField] float movementMultiplier = 0;
    [SerializeField] float rotationSpeed = 0;
    [Header("Jump")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] float jumpForce = 0;
    [SerializeField] float gravityScale = 0;
    [Header("Ground Check")]
    [SerializeField] float groundDistance = 0;
    [SerializeField] LayerMask groundMask = 0;

    private Rigidbody rb = null;
    private RaycastHit hit;

    Vector3 velocity;

    private float horizontalInput = 0;
    private bool grounded = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");

        Inputs();

        if (Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask))
        {
            grounded = true;
        }
        else grounded = false;

        velocity = Vector3.forward * horizontalInput * movementMultiplier * movementForce;

        if (rb.velocity.y <= -10f)
            rb.velocity = new Vector3(rb.velocity.x, -10f, rb.velocity.z);

        if (horizontalInput > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed);
        else if(horizontalInput < 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotationSpeed);
    }

    void Inputs()
    {
        if(Input.GetKeyDown(jumpKey) && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector3.down * 9.81f * gravityScale, ForceMode.Acceleration);
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * groundDistance);
    }
}
