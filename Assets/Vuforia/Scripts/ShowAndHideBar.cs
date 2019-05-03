using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHideBar : MonoBehaviour
{
    [SerializeField]private Animator anim;
    public bool hidden;
    void Start()
    {
        hidden = false;
    }

     public void ToggleAnim()
    {
        if(hidden)
        {
            anim.SetTrigger("show");
            hidden = false;
        }

        else 
        {
            anim.SetTrigger("hide");
            hidden = true;
        }
    }
}
