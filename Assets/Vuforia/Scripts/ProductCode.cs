using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductCode : MonoBehaviour
{
    [SerializeField] private Text nameTxt;
    [SerializeField] private Text priceTxt; 

    public string name;
    public int price;
    
    void OnEnable(){
        nameTxt.text = name;
        priceTxt.text = "R$" + price + ",99";
    }

    public void SetData(string name, int price){
        this.name = name;
        this.price = price;

        OnEnable();
    }
}
