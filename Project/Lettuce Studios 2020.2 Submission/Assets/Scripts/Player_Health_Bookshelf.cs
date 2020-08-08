using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player_Health_Bookshelf : MonoBehaviour
{


    public int health = 9;


    [SerializeField] GameObject[] books;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 8:
                damage(0);
                break;
            case 7:
                damage(1);
                break;
            case 6:
                damage(2);
                break;
            case 5:
                damage(3);
                break;
            case 4:
                damage(4);
                break;
            case 3:
                damage(5);
                break;
            case 2:
                damage(6);
                break;
            case 1:
                damage(7);
                break;
            case 0:
                damage(8);
                break;
            default:
                break;
        }
    }

    public void damage(int Health)
    {
        StartCoroutine(removeBook(health));
    }

    IEnumerator removeBook(int booknum)
    {
        books[booknum].transform.DOShakeRotation(1, 5, 5, 90, false);
        yield return new WaitForSeconds(1);
        books[booknum].transform.DOScale(0,0.5f);
        yield return new WaitForSeconds(0.5f);
        books[booknum].SetActive(false);
    }
}
