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
    public bool invertedControls;
    public float rotationBound = 10;

    //Ground Check Stuff
    Ray ray;
    RaycastHit hit;

    //Jumping
    public bool canJump = true;
    public float jumpHeight = 5;
    public int maxJumps = 1;
    private int jumpValue = 0;

    //Damage
    public Player_Health_Bookshelf phb;
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
        transform.localRotation = Quaternion.Euler(-13.479f, -90, -90);
        DoubleJumping();
        ResetJumpValue();
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
            if (invertedControls)
            {
                targetVelocity = -targetVelocity;
            }

            //Running cat forward (counterclockwise around disk) and backward (clockwise)
            Vector3 pivotRotation = pivot.transform.rotation.eulerAngles;
            pivot.transform.eulerAngles = Mathf.Abs(pivot.transform.eulerAngles.y) < rotationBound ? pivot.transform.eulerAngles + Vector3.up * targetVelocity.z * Time.fixedDeltaTime : pivot.transform.eulerAngles;

            //Sideways force for cat
            rb.AddRelativeForce(Vector3.right * targetVelocity.x * Time.fixedDeltaTime, ForceMode.VelocityChange);

        }

      
        //Downforce
        rb.AddForce(new Vector3(0, -gravity * rb.mass * Time.fixedDeltaTime, 0));
    }

    public void InvertControls()
    {
        invertedControls = !invertedControls;
    }
    #endregion movement

    #region jumping
    void DoubleJumping()
    {
        //Initial Jump
        if (IsGrounded() && canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpForce() * Time.fixedDeltaTime, rb.velocity.z);
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

    public void damage(int type)
    {
        if (type == 1)
        {
            phb.HealthDamage();
        }
        else if (type == 2)
        {
            StartCoroutine(twice());
            IEnumerator twice()
            {
                phb.HealthDamage();
                yield return new WaitForSeconds(0.5f);
                phb.HealthDamage();
            }
            

        }
        else
        {
            Debug.Log("Type not recognized.");
        }
        
    }
    public void heal()
    {
        phb.heal();
    }
}
