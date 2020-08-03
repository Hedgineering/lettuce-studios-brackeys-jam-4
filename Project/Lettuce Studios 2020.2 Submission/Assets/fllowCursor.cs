using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fllowCursor : MonoBehaviour
{
    Vector3 spacePosition;
    void Start()
    {
        Cursor.visible = false;
    }


    
    void Update()
    {
        spacePosition = Input.mousePosition;
        transform.position = spacePosition;

    }
}
