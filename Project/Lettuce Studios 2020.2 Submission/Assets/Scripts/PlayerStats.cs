using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health;

    private void Update()
    {
        CheckIfDie();
    }

    void CheckIfDie()
    {
        if (health <= 0)
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

}
