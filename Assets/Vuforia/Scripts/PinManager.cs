using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinManager : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text name;
    [SerializeField] private Text description;
    private string previousID;
    public string curID;
    private bool changeBox;

    [SerializeField] private GameObject navBtns;
    [SerializeField] private GameObject pinInfoBox;

    
    // Start is called before the first frame update
    void Start()
    {
        changeBox = false;
        StartCoroutine(FavoritedCheck());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInfo(Sprite pinIcon, string pinName,string pinDescription,string ID)
    {
        icon.sprite = pinIcon;
        name.text = pinName;
        description.text = pinDescription;
        curID = ID;
        

        if(Singleton.GetInstance.showAndHideBar.hidden)
        {
            Singleton.GetInstance.showAndHideBar.ToggleAnim();
        }
        
        if(previousID != ID)
        {
            previousID = ID;
            changeBox = false;
        }
        else
        {
            changeBox = true;
        }
        
    }

    public void ToggleBoxes()
    {
        //clicou num pin com a navegação aberta
        if(navBtns.activeSelf)
        {
            navBtns.SetActive(false);
            pinInfoBox.SetActive(true);
        }
        //clicou num pin , enquanto olhava outro pin
       else if (pinInfoBox.activeSelf && !changeBox)
        {
            //navBtns.SetActive(true);
           // pinInfoBox.SetActive(false);
        }
        //clicou no mesmo pin que estava antes
        else if (pinInfoBox.activeSelf && changeBox)
        {
            navBtns.SetActive(true);
            pinInfoBox.SetActive(false);
        }
    }

     public void CheckWichOneToFav()
    {         

        for(int i = 0; i < Singleton.GetInstance.pins.Length ; i++)
        {
            if(Singleton.GetInstance.pins[i].ID == curID)
            {
                Singleton.GetInstance.pins[i].Favorite();
                
                break;
            }
        }
    }

    IEnumerator FavoritedCheck()
    {
        for(;;)
        {
            if(PlayerPrefs.HasKey(curID))
            {   
               
                Singleton.GetInstance.favoriteBtnImg.sprite = Singleton.GetInstance.favoritedSprite;
            }

            else
            {
                Singleton.GetInstance.favoriteBtnImg.sprite = Singleton.GetInstance.notFavoritedSprite;
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    


}
