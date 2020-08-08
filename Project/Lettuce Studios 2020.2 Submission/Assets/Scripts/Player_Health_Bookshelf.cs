using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Player_Health_Bookshelf : MonoBehaviour
{


    public int health = 9;

    public GameObject GameOver;

    [SerializeField] bool[] activeBooks;

    [SerializeField] GameObject[] books;

    // Start is called before the first frame update
    void Start()
    {
        activeBooks = new bool[books.Length];

        for (int i = 0; i < books.Length; i++)
        {
            activeBooks[i] = books[i].activeSelf;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
    }


    
    public void HealthDamage()
    {
        health -= 1;
        for (int i = 0; i < activeBooks.Length; i++)
        {
            if (activeBooks[i])
            {
                activeBooks[i] = false;
                StartCoroutine(removeBook(i));
                break;
            }
        }
    }

    public void heal()
    {
        health += 1;
        for (int i = 0; i < activeBooks.Length; i++)
        {
            if (!activeBooks[i])
            {
                activeBooks[i] = true;

                StartCoroutine(addbook(i));
                break;
            }
        }
    }

    IEnumerator removeBook(int booknum)
    {
        books[booknum].transform.DOShakeRotation(1, 5, 5, 90, false);
        yield return new WaitForSeconds(1);
        books[booknum].transform.DOScale(0,0.5f);
        yield return new WaitForSeconds(0.5f);
        books[booknum].SetActive(false);
    }
    IEnumerator addbook(int booknum)
    {
        books[booknum].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        books[booknum].transform.DOScale(1, 0.5f);
        books[booknum].transform.DOShakeRotation(1, 5, 5, 90, false);
    }
}
