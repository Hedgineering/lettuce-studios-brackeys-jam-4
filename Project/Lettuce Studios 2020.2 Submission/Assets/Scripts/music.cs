using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    bool state = true;
    // Start is called before the first frame update
  

    // Update is called once per frame
    public void Musicchange()
    {
        state = !state;
        AudioListener.pause = state;
    }

   
}
