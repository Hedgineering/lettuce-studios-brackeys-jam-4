using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health;

    private void Update()
    {
        CheckIfDie();
    }

    void CheckIfDie()
    {
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //death ui
        //idk what you want to add
        Destroy(gameObject);
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            health -= (30f * Time.deltaTime);
        }
    }

}
