using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Product
{
    public int id;
    public string name;
    public string location;
    public string price;

    public Product (int id, string name, string location, string price){
        this.id = id;
        this.name = name;
        this.location = location;
        this.price = price;
    }
}
