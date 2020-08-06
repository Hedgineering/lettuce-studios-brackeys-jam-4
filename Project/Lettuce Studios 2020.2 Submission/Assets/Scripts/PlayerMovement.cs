using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region fields
    //Moving
    public Rigidbody rb;
    public GameObject pivot;
    public Vector3 speed = new Vector3(300, 0, -1);
    public float gravity = 200;
    public float maxVelocityChange = 8;
    public float groundRaySize = 1;
    private Vector3 originalPosition;

    //Ground Check Stuff
    Ray ray;
    RaycastHit hit;

    //Jumping
    public bool canJump = true;
    public float jumpHeight = 5;
    public int maxJumps = 1;
    private int jumpValue = 0;
    #endregion fields

    #region monoBehaviorLoops
    void Awake()
    {
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    private void Start()
    {
        
        rb.inertiaTensor = rb.inertiaTensor + new Vector3(2, 2, rb.inertiaTensor.z * 100);
        originalPosition = transform.position;
        
    }

    private void Update()
    {
        
        DoubleJumping();
        ResetJumpValue();
        Debug.DrawRay(transform.position, Vector3.down * groundRaySize);
    }

    void FixedUpdate()
    {
        Movement();
    }
    #endregion monoBehaviorLoops

    #region movement
    void Movement()
    {
        if (IsGrounded())
        {
            Vector3 targetVelocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed.x, 0, Input.GetAxisRaw("Vertical") * speed.z);

            Vector3 pivotRotation = pivot.transform.rotation.eulerAngles;
            pivot.transform.eulerAngles += Vector3.up * targetVelocity.z;
            rb.AddRelativeForce(Vector3.right * targetVelocity.x * Time.deltaTime, ForceMode.VelocityChange);

        }

      

        rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
    }
    #endregion movement

    #region jumping
    void DoubleJumping()
    {
        //Initial Jump
        if (IsGrounded() && canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce(), rb.velocity.z);
        }

        //Further Jumps off the ground --Not Currently Functional
        //else if (!IsGrounded() && Input.GetKeyDown(KeyCode.Space) && jumpValue <= maxJumps)
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, JumpForce(), rb.velocity.z);
        //}

        jumpValue++;
    }
    void ResetJumpValue()
    {
        if (IsGrounded())
        {
            jumpValue = 0;
        }
    }

    bool IsGrounded()
    {
        ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray, out hit, groundRaySize);
    }

    float JumpForce()
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
    #endregion jumping

    void ResetPosition()
    {
        transform.position = originalPosition;
    }    
}
