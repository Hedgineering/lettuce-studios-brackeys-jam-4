using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health = 100f;

    public Slider slider;

    public Gradient gg;

    public Image fill;

    void Start()
    {
        healthy();
    }

    public void healthy()
    {
        slider.value = Convert.ToInt16(health);
        slider.maxValue = Convert.ToInt16(health);
        fill.color = gg.Evaluate(1f);
    }

    public void healthi()
    {
        slider.value = Convert.ToInt16(health);
        fill.color = gg.Evaluate(health / 100f);
    }

    private void Update()
    {
        CheckIfDie();
      
    }

    public void FixedUpdate()
    {
        health += 1f * Time.deltaTime;
        healthi();
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
