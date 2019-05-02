using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{   
    [SerializeField] private int itemCount = 10;
    [SerializeField] private Text searchInput;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private List<GameObject> products;
    public List<GameObject> tempList;

    RectTransform rowRectTransform;
    RectTransform containerRectTransform;

    void Start()
    {
        rowRectTransform = itemPrefab.GetComponent<RectTransform>();
        containerRectTransform = GetComponent<RectTransform>();

        float scrollHeight = ((200 + 10) * itemCount)/2; // (height + spacing) * itemCount;

        containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight);
        containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight + 200);

        containerRectTransform.position = new Vector3(containerRectTransform.position.x, 0, 0);

        DrawList(products);
    }

    void CreateList(){

    }

    void DrawList(List<GameObject> list){
        for (int i = 0; i < list.Count; i++)
        {
            //create a new item, name it, and set the parent
            GameObject newItem = Instantiate(itemPrefab, containerRectTransform.position, Quaternion.identity, transform) as GameObject;
            
            newItem.name = gameObject.name + " Product (" + i + ")";
            newItem.transform.parent = gameObject.transform;

            //Adding to list
            list.Add(newItem);
        }

        print("Drawed List");
    }

    void ClearList(List<GameObject> list){
        for(int i = 0; i < list.Count; i++){
            Destroy(list[i].gameObject);
            print(list[i]);
        }
        list.Clear();

        print("List Clear");
    }

    public void Filter(){

        tempList = new List<GameObject>();

        for(int i = 0; i < products.Count; i++){

            string pdName = products[i].GetComponent<RandomTest>().name;

            print(searchInput.text.ToLower());
            if(pdName.ToLower().Contains(searchInput.text.ToLower())){
                print(pdName.ToLower() + " & " + searchInput.text.ToLower());
                tempList.Add(products[i]);
            }
        }

        for(int i = 0; i < products.Count; i++){
            Destroy(products[i]);
        }
    }
}