using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKill : MonoBehaviour
{
    [SerializeField] float expireTime;
    public Transform defaultParent;

    // Start is called before the first frame update

    private void OnEnable()
    {
        if (defaultParent != null)
        {
            transform.SetParent(defaultParent);
        }
        StartCoroutine(expire());
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag =="Player")
        {
            gameObject.SetActive(false);
            transform.SetParent(null);
        }
        
    }


    IEnumerator expire()
    {
        yield return new WaitForSeconds(expireTime);

        this.gameObject.SetActive(false);
        transform.SetParent(null);
    }
    
}
