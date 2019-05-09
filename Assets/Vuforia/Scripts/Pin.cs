using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pin : MonoBehaviour
{
   public string name;
   [TextArea(1,3)]
   public string description;
   public Sprite icon;
   public string ID;
   public PinManager test;
   private Image mapSymbolImg;
   private Sprite mapSymbol;
   private bool isFavorite;

void Start()
{
    mapSymbolImg = gameObject.GetComponent<Image>();

    mapSymbol = Singleton.GetInstance.normalMapSymbol;
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
  if(!isFavorite)
  {  
  mapSymbolImg.sprite = Singleton.GetInstance.favoritedMapSymbol;
  isFavorite = true;
  PlayerPrefs.SetInt(ID , 1);
  
  }
  else
  {
    mapSymbolImg.sprite = mapSymbol;  
    isFavorite = false;
    PlayerPrefs.DeleteKey(ID);
  }

}


}