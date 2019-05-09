using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    public SceneChanger sceneChanger;

     public Text placar;

     public ShowAndHideBar showAndHideBar;

     public PinManager pinManager;

     public Sprite normalMapSymbol;

    public Sprite favoritedMapSymbol;

    public Image favoriteBtnImg;

    public Sprite favoritedSprite;

    public Sprite infoSprite;

    public Sprite notFavoritedSprite;

    public Pin[] pins;

    public static Singleton GetInstance{
        get{
            if(instance == null){
                instance = GameObject.FindObjectOfType<Singleton>();
            }

            return instance;
        }
    }
}
