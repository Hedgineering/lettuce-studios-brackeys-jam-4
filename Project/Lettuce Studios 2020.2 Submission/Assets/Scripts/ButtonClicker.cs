using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonClicker : MonoBehaviour
{

    public float rayLength;
    public LayerMask layermask;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, rayLength, layermask))
            {
                if(hit.collider.tag == "Button")
                {
                    hit.transform.gameObject.SendMessage("click");
                }
            }

            
        }
      
    }
    
}
