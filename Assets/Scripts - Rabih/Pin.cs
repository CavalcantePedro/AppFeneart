using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pin : MonoBehaviour
{
   public string name;
   public string description;
   public Sprite icon;
   public string ID;
   public PinManager test;

public void SendInformation()
{
    test.ShowInfo(icon, name , description,ID);
    //Singleton.GetInstance.pinManager.ShowInfo(this.Pin);
}

}