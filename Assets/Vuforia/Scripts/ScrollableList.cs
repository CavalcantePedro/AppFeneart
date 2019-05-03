using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{   
    [SerializeField] private int itemCount;
    [SerializeField] private Text searchInput;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private List<GameObject> products;
    [SerializeField] private List<GameObject> userList; //List for operations

    private string previousSearch;
    RectTransform rowRectTransform;
    RectTransform containerRectTransform;

    void Start()
    {
        rowRectTransform = itemPrefab.GetComponent<RectTransform>();
        containerRectTransform = GetComponent<RectTransform>();

        float scrollHeight = ((200 + 10) * itemCount)/2; // (height + spacing) * itemCount;

        containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight);
        containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight + 200);

        ResetContentView();

        products = CreateList(false, itemCount);
        CopyList(products, userList);
        DrawList(userList);
    }

    void ResetContentView(){
        containerRectTransform.position = new Vector3(containerRectTransform.position.x, 0, 0);
    }

    List<GameObject> CreateList(bool draw, int lenght){
        
        List<GameObject> tempList = new List<GameObject>();
        
        for(int i = 0; i < lenght; i++){
            GameObject newItem = Instantiate(itemPrefab, containerRectTransform.position, Quaternion.identity, transform) as GameObject;
            
            ProductCode pc = newItem.GetComponent<ProductCode>();

            if(pc == null) print("ERRO, nullComponent! in ScrollableList");

            //Temp code (Random Test)
            switch(Random.Range(1, 4)){
                case 1:
                    pc.SetData("Lasanha", 1);
                break;
                case 2:
                    pc.SetData("Mamão", 2);
                break;
                case 3:
                    pc.SetData("Carne Vegana", 3);
                break; 
            }

            tempList.Add(newItem);
            
            if(!draw)
                newItem.SetActive(false);

        }

        return tempList;
    }

    void CopyList(List<GameObject> send, List<GameObject> recp){
        for(int i = 0; i < send.Count; i++){
            GameObject newItem = Instantiate(send[i], containerRectTransform.position, Quaternion.identity, transform) as GameObject;

            recp.Add(newItem);
        }
    }

    void DrawList(List<GameObject> list){
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(true);
            list[i].name = gameObject.name + " Product (" + i + ")";
        }

        print("Drawed List");
    }

    void HideList(List<GameObject> list){
        for(int i = 0; i < list.Count; i++){
            list[i].SetActive(false);
        }
    }

    void ClearList(List<GameObject> list){
        for(int i = 0; i < list.Count; i++){
            Destroy(list[i].gameObject);
        }
        list.Clear();
    }

    public void Filter(){

        List<GameObject> filterList = new List<GameObject>();

        if(searchInput.text == previousSearch)
            return;

        previousSearch = searchInput.text;

        for(int i = 0; i < userList.Count; i++){

            string pdName = userList[i].GetComponent<ProductCode>().Name;

            if(pdName.ToLower().Contains(searchInput.text.ToLower())){
                filterList.Add(userList[i]);
            }
        }
        HideList(userList);
        DrawList(filterList);

        ResetContentView();
    }
}