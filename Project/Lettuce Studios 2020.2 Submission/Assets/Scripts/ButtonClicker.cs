using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonClicker : MonoBehaviour
{

    public float rayLength;
    public LayerMask layermask;
    

    GameObject knob;
    
    

    public Player_Health_Bookshelf ph;

    [SerializeField]int damageint = 0;
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
            //if (Physics.Raycast(ray,out hit, rayLength, layermask))
            //{
            //    if(hit.collider.tag == "Knob")
            //    {
            //        knob = hit.collider.gameObject;
            //    }
            //}
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(damageint == 0)
            {
                ph.damage(0);
                damageint += 1;
            }
            else
            {
                ph.damage(damageint);
                damageint += 1;
            }
        }
    }


    
}
