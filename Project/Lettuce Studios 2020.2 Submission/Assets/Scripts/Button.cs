using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
    bool clicked;


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
        transform.DOMove(transform.position + Vector3.down * 0.2f, 0.3f, false);
        yield return new WaitForSeconds(0.5f);
        transform.DOMove(transform.position + Vector3.up * 0.2f, 0.3f, false);
        yield return new WaitForSeconds(0.5f);
        clicked = false;
    }
}
