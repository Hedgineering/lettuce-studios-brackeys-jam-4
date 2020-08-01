using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float gravity;
    public float maxVelocityChange;
    public bool canJump = true;
    public float jumpHeight;
    private bool grounded = false;



    void Awake()
    {
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);

            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;

            rb.AddForce(velocityChange, ForceMode.VelocityChange);

            if (canJump && Input.GetButton("Jump"))
            {
                rb.velocity = new Vector3(velocity.x, JumpForce(), velocity.z);
            }
        }

        rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));
        grounded = false;
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
