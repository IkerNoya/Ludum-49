using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] UnityEvent jumpSound;
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
    [SerializeField] Transform groundCheck = null;
    [Header("Wall Jump")]
    [SerializeField] float wallJumpForce = 0;
    [SerializeField] float wallDistance = 0;
    [SerializeField] float wallGravityScale = 0;

    private Rigidbody rb = null;

    private Vector3 velocity;

    private RaycastHit wallHit;

    private float horizontalInput = 0;
    private bool grounded = false;
    private bool rotateLeft = false;
    private bool isInWall = false;
    private bool hasSetWallVelocity = false;
    private bool jumpedOffWall = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!isInWall)
            horizontalInput = Input.GetAxisRaw("Horizontal");

        Inputs();

        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(!jumpedOffWall)
            isInWall = Physics.Raycast(transform.position, transform.forward, out wallHit, wallDistance);

        if (grounded)
        {
            velocity = Vector3.forward * horizontalInput * movementMultiplier * movementForce;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            hasSetWallVelocity = false;
            isInWall = false;
            jumpedOffWall = false;
        }
        else
        {
            if (horizontalInput > 0 || horizontalInput < 0)
                velocity = Vector3.forward * horizontalInput * movementMultiplier * movementForce;
            else
                velocity = rb.velocity;
        }

        if (rb.velocity.y <= -20f && !isInWall)
            rb.velocity = new Vector3(rb.velocity.x, -20f, rb.velocity.z);
        else if(rb.velocity.y <= -10f && isInWall)
            rb.velocity = new Vector3(rb.velocity.x, -10f, rb.velocity.z);

        if (!isInWall)
        {
            if (!rotateLeft)
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotationSpeed);
            else 
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotationSpeed);
        }
    }

    void Inputs()
    {
        if(Input.GetKeyDown(jumpKey) && grounded)
        {
            jumpSound?.Invoke();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }
        if (Input.GetKeyDown(jumpKey) && isInWall && !jumpedOffWall)
        {
            jumpSound?.Invoke();
            jumpedOffWall = true;
            isInWall = false;
            rb.AddForce((wallHit.normal + Vector3.up) * wallJumpForce, ForceMode.Impulse);
            if (wallHit.normal.z < 0) rotateLeft = true;
            else rotateLeft = false;
            grounded = false;
        }

        if (horizontalInput > 0)
            rotateLeft = false;
        else if (horizontalInput < 0)
            rotateLeft = true;
    }
    private void FixedUpdate()
    {
        if (!isInWall)
        {
            rb.AddForce(Vector3.down * 9.81f * gravityScale, ForceMode.Acceleration);
        }
        else if(isInWall && !grounded)
        {
            if(!hasSetWallVelocity)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                hasSetWallVelocity = true;
            }    
            rb.AddForce(Vector3.down * 9.81f * wallGravityScale, ForceMode.Acceleration);
        }

        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        Gizmos.DrawRay(transform.position, transform.forward * wallDistance);
    }
}
