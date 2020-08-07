using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KazeCharController : MonoBehaviour
{
    [SerializeField] GameObject playerObject;



    [SerializeField] float speed;
    [SerializeField] float jumpHeight;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = playerObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0,v,0));

    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //playerObject.transform.position -=new Vector3( h * speed,0,0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}
