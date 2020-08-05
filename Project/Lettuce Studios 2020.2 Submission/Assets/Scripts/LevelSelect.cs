using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public Animator anim;
    private void Start()
    {
        anim.speed = 0f;
    }
    public void LevelsOpen()
    {
        anim.Play("LevelSwitchOpen", -1, 0f);
        anim.speed = 1f;
    }
    public void LevelsClose()
    {
        anim.Play("LevelSwitchClose", -1, 0f);
        anim.speed = 1f;
    }
}
