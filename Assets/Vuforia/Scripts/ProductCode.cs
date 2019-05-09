using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductCode : MonoBehaviour
{
    [SerializeField] private Text nameTxt;
    [SerializeField] private Text priceTxt; 

    public string name;
    public string price;

    private Button selfBtn;

    void OnEnable(){
        nameTxt.text = name;
        priceTxt.text = "R$" + price;
    }
    

    void Start() 
    {
        selfBtn = gameObject.GetComponent<Button>();
        selfBtn.onClick.AddListener(Redirect);
    }

    public void SetData(string name, string price){
        this.name = name;
        this.price = price;

        OnEnable();
    }

    void Redirect()
    {
        Singleton.GetInstance.sceneChanger.ProductRedirect("Rabih Tabatchnik");
    }

}
