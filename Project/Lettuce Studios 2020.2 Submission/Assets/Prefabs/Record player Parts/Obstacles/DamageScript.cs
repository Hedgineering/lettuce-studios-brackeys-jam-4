using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] bool Normaldmg;
    [SerializeField] bool heal;
    [SerializeField] bool Bigdmg;

    private void OnEnable()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            if (Normaldmg)
            {
                other.gameObject.GetComponent<PlayerMovement>().damage(1);

                gameObject.SetActive(false);
            }
            else if (heal)
            {
                other.gameObject.GetComponent<PlayerMovement>().heal();
                gameObject.SetActive(false);
            }
            else if (Bigdmg)
            {
                other.gameObject.GetComponent<PlayerMovement>().damage(2);
                gameObject.SetActive(false);
            }
            
        }
    }
}
