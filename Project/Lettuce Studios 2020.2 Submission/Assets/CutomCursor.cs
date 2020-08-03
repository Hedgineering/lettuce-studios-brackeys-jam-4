using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutomCursor : MonoBehaviour
{
    Vector2 targetPos;


    void Start()
    {
        
    }

    
    void Update()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = targetPos;
    }
}
