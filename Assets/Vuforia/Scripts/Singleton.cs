using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

     public Text placar;

    public static Singleton GetInstance{
        get{
            if(instance == null){
                instance = GameObject.FindObjectOfType<Singleton>();
            }

            return instance;
        }
    }
}
