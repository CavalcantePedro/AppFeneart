using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductCode : MonoBehaviour
{
    [SerializeField] private Text nameTxt;
    [SerializeField] private Text priceTxt; 
    [SerializeField] private Text locationTxt;

    public string name;
    public string price;
    public string location;

    private Button selfBtn;

    void OnEnable(){
        nameTxt.text = name;
        priceTxt.text = "R$" + price;
        locationTxt.text = location;
    }
    

    void Start() {
        selfBtn = gameObject.GetComponent<Button>();
        selfBtn.onClick.AddListener(Redirect);
    }

    public void SetData(string name, string price, string location){
        this.name = name;
        this.price = price;
        this.location = location;

        OnEnable();
    }

    void Redirect(){
        Singleton.GetInstance.sceneChanger.ProductRedirect("Rabih Tabatchnik");
    }

}
