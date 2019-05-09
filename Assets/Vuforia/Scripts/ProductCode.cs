using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductCode : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] private Text price; 

    private Button selfBtn;

    public string Name;
    //{ get; set;}
    public int Id;
    //{ get; set;}
    
    void OnEnable(){
        name.text = Name;
        price.text = "R$" + Id + ",99";       
    }

    void Start() 
    {
         selfBtn = gameObject.GetComponent<Button>();
         selfBtn.onClick.AddListener(test);
    }

    public void SetData(string name, int id){
        print(name + id);
        Name = name;
        Id = id;

        OnEnable();
    }

    void test()
    {
        Singleton.GetInstance.sceneChanger.ProductRedirect("<location>");
    }

}
