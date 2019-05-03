using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pin : MonoBehaviour
{
   public string name;
   public string description;
   public Sprite icon;
   public string ID;
   public PinManager test;
   private Image mapSymbolImg;
   [SerializeField] private Sprite mapSymbol;

void Start()
{
    mapSymbolImg = gameObject.GetComponent<Image>();

    if(PlayerPrefs.HasKey(ID))
    {
     mapSymbolImg.sprite = Singleton.GetInstance.favoritedMapSymbol;
    }

    else
    {
     mapSymbolImg.sprite = mapSymbol;
    }
}
public void SendInformation()
{
    test.ShowInfo(icon, name , description,ID);
    //Singleton.GetInstance.pinManager.ShowInfo(this.Pin);
}

public void Favorite()
{
  mapSymbolImg.sprite = Singleton.GetInstance.favoritedMapSymbol;
}


}