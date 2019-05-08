using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField] private Vector2 minPos;
    [SerializeField] private Vector2 maxPos;
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;

    //pan
    private Vector3 touchStart;
    private Vector3 direction;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        ClampingPos();
        Pan();
        GetZoomRate();

    }

    public void ClampingPos()
    {
        transform.position = new Vector2 (Mathf.Clamp(transform.position.x,minPos.x,maxPos.x),Mathf.Clamp(transform.position.y,minPos.y,maxPos.y));
       
    }

     public void GetZoomRate()
    {
       if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            //magnitude == fingers distance
            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }
    }
    
    void Zoom(float increment)
    {
        
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, minZoom , maxZoom);
    }

    void Pan() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart =  Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        if(Input.GetMouseButton(0))
        {
            direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }

    }
}
