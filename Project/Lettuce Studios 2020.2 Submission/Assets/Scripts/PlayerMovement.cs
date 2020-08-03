using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Moving
    public Rigidbody rb;
    public float speed;
    public float gravity;
    public float maxVelocityChange;
    private bool grounded = false;

    //Jumping
    public bool canJump = true;
    public float jumpHeight;
    public int maxJumps;
    private int jumpValue = 0;

    void Awake()
    {
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    private void Update()
    {
        DoubleJumping();
        ResetJumpValue();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (grounded)
        {
            Vector3 targetVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);

            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);

        }

        else if (!grounded)
        {

            Vector3 targetVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);

            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }

        rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
    }

    void DoubleJumping()
    {
        if (grounded && canJump && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce(), rb.velocity.z);
            grounded = false;
        }

        else if (!grounded && Input.GetKeyDown(KeyCode.Space) && jumpValue < maxJumps)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce(), rb.velocity.z);
            jumpValue++;
        }
    }

    void ResetJumpValue()
    {
        if (grounded)
        {
            jumpValue = 0;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    float JumpForce()
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

}
