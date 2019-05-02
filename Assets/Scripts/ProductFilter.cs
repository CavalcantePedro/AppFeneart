using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductFilter : MonoBehaviour
{

    public int countList;
    [SerializeField] private GameObject productPrefab;

    [Header("Lista de Produtos")]
    public List<GameObject> products; 
    
    void Awake()
    {
        
    }

    public void FilterByName(string pdName){

    }

    public void ClearList(){

    }
}
