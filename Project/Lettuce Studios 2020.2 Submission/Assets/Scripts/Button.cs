using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    private bool clicked;


    [SerializeField] float buttonClickDepth;

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
        transform.DOMove(transform.position + Vector3.down * buttonClickDepth, 0.3f, false);
        yield return new WaitForSeconds(0.5f);
        transform.DOMove(transform.position + Vector3.up * buttonClickDepth, 0.3f, false);
        yield return new WaitForSeconds(0.3f);
        clicked = false;
    }

    private void OnMouseDown()
    {
        click();
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
