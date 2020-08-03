using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fllowCursor : MonoBehaviour
{
    Vector2 spacePosition;
    void Start()
    {
        Cursor.visible = false;
    }


    
    void Update()
    {
        spacePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = spacePosition;

    }
}
