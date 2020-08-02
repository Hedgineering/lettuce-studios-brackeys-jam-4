using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscSpinner : MonoBehaviour
{

    public float speed;

    public bool Reverse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Reverse)
        {

            this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                Time.deltaTime * -speed);
        }
        else
        {

            this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                Time.deltaTime * speed);
        }

    }
}
