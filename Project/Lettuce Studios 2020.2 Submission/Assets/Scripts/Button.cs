using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    bool clicked;
    

    [SerializeField] float speed;

    public bool knob;
    
    float Amount;

    [SerializeField] bool plauqe;

    AudioSource source;

    private void Start()
    {
        if (knob)
        {

            source = GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        

        Amount = Mathf.Clamp01(Amount);
        if (knob)
        {
            source.volume = Amount;
        }
    }

    public void click()
    {

        if (!clicked)
        {
            StartCoroutine(Click());
        }
    }

    IEnumerator Click()
    {
        clicked = true;
        transform.DOMove(transform.position + Vector3.down * 0.02f, 0.3f, false);
        yield return new WaitForSeconds(0.5f);
        transform.DOMove(transform.position + Vector3.up * 0.02f, 0.3f, false);
        yield return new WaitForSeconds(0.5f);
        clicked = false;
    }

    private void OnMouseDrag()
    {
        if (knob)
        {
            float rotY = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, -rotY);

            Amount += rotY;
        }
        
    }
    
}
