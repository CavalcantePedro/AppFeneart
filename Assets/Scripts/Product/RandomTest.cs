using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTest : MonoBehaviour
{
    [SerializeField] private Text nameTxt;
    [SerializeField] private Text price; 

    public string name;
    [SerializeField] private int id;
    
    void OnEnable(){

        switch(Random.Range(1, 4)){
            case 1:
                name = "Lasanha";
                id = 1;
            break;
            case 2:
                name = "Mamão";
                id = 2;
            break;
            case 3:
                name = "Carne Vegana";
                id = 3;
            break;
        }

        nameTxt.text = name;
        price.text = "R$" + id + ",99";

    }
}
