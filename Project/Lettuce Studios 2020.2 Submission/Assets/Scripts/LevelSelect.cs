using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public Animator anim;

    public void LevelsOpen()
    {
        anim.Play("LevelSwitchOpen", -1, 0f);
    }
    public void LevelsClose()
    {
        anim.Play("LevelSwitchClose", -1, 0f);
    }
}
