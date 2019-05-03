using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductCode : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] private Text price; 

    public string Name;
    //{ get; set;}
    public int Id;
    //{ get; set;}
    
    void OnEnable(){
        name.text = Name;
        price.text = "R$" + Id + ",99";
    }

    public void SetData(string name, int id){
        print(name + id);
        Name = name;
        Id = id;

        OnEnable();
    }
}
