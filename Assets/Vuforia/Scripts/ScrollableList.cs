using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : Web
{   
    //temp:
    public Text txt;

    [SerializeField] private int itemCount;
    [SerializeField] private Text searchInput;
    [SerializeField] private GameObject notFoundTxt;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private List<GameObject> products;
    [SerializeField] private List<GameObject> userList; //List for operations
    [SerializeField] private List<Product> testList;

    private string previousSearch;
    RectTransform rowRectTransform;
    RectTransform containerRectTransform;

    void Start()
    {
        rowRectTransform = itemPrefab.GetComponent<RectTransform>();
        containerRectTransform = GetComponent<RectTransform>();
    }

    public override void OnWebLoad() {

        Itens it = JsonUtility.FromJson<Itens>(WebManager.WebLoadData());

        txt.text = it.products[0].name;

        AdjustContentView(it.products.Count);
        ResetContentView();

        products = CreateList(false, it.products.Count);
        CopyList(products, userList);
        DrawList(userList);

    }

    public void ResetContentView(){
        containerRectTransform.position = new Vector3(containerRectTransform.position.x, 0, 0);
    }

    public void AdjustContentView(int count){
        float scrollHeight = ((200 + 10) * count)/2; // (height + spacing) * itemCount;

        containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight);
        containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight + 200);
    }

    List<GameObject> CreateList(bool draw, int lenght){
        
        List<GameObject> tempList = new List<GameObject>();
        print(lenght);

        for(int i = 0; i < lenght; i++){
            GameObject newItem = Instantiate(itemPrefab, containerRectTransform.position, Quaternion.identity, transform) as GameObject;
            
            ProductCode pc = newItem.GetComponent<ProductCode>();

            if(pc == null) print("ERRO, nullComponent! in ScrollableList");

            Itens it = JsonUtility.FromJson<Itens>(WebManager.WebLoadData());
            //print(WebManager.WebLoadData());
            pc.SetData(it.products[i].name, it.products[i].price, it.products[i].location);
            testList = it.products;

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

        notFoundTxt.SetActive(false);

        List<GameObject> filterList = new List<GameObject>();

        if(searchInput.text == previousSearch){
            return;
        }

        previousSearch = searchInput.text;

        for(int i = 0; i < userList.Count; i++){

            string pdName = userList[i].GetComponent<ProductCode>().name;

            if(pdName.ToLower().Contains(searchInput.text.ToLower())){
                filterList.Add(userList[i]);
            }
        }

        for (int i = 0; i < userList.Count; i++)
        {
            string pdLocation = userList[i].GetComponent<ProductCode>().location;
            if(pdLocation.ToLower().Contains(searchInput.text.ToLower())){
                filterList.Add(userList[i]);
            }
        }

        if(filterList.Count <= 0) notFoundTxt.SetActive(true);

        HideList(userList);
        DrawList(filterList);

        AdjustContentView(filterList.Count);
        ResetContentView();
    }
}