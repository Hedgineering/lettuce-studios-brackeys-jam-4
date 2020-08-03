using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            int playerHealth = collision.transform.GetComponent<PlayerStats>().health -= 1;
            Debug.Log(playerHealth);
            Destroy(gameObject);
        }
    }

}
