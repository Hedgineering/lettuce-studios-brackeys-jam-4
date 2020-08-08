using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Books : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }




    public void damage()
    {
        StartCoroutine(Despawn());
    }


    public IEnumerator Despawn()
    {
        transform.DOShakeRotation(0.5f, 5, 5, 90, false);
        yield return new WaitForSeconds(1);
        transform.DOScale(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    public IEnumerator Spawn()
    {
        transform.DOScale(1, 0.5f);
        yield return new WaitForSeconds(0);
        transform.DOShakeRotation(0.5f, 5, 5, 90, false);
        
    }
}
