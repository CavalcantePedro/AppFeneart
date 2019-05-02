using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHideBar : MonoBehaviour
{
    [SerializeField]private Animator anim;
    private bool hide;
    void Start()
    {
        hide = true;
    }

     public void ToggleAnim()
    {
        if(hide)
        {
            anim.SetTrigger("hide");
            hide = false;
        }

        else 
        {
            anim.SetTrigger("show");
            hide = true;
        }
    }
}
