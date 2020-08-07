using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            int playerHealth = Convert.ToInt16(collision.transform.GetComponent<PlayerStats>().health -= 1);
            Debug.Log(playerHealth);
            Destroy(gameObject);
        }
    }

}
