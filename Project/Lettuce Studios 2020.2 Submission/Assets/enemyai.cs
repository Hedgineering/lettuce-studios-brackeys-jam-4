using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class enemyai : MonoBehaviour
{
    public Transform player;
    Vector3 direction;
    public Rigidbody rb;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movetoplayer();
    }

    void movetoplayer()
    {
        direction = player.position - transform.position;
        rb.MovePosition(transform.position + (direction * 0.2f * Time.deltaTime));
        distance = Vector3.Distance(player.position, transform.position);

        if (distance < 10f && player.position.y > transform.position.y)
        {
            rb.AddForce(0f, 20f * Time.deltaTime, 0f, ForceMode.Impulse);
        }
        
    }
}
