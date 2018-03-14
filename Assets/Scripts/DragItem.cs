using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public string typeItem;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBeginDrag(PointerEventData pointer)
    {
        print("begin to drag");
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData pointer)
    {
        GetComponent<RectTransform>().position = pointer.position;
        print("dragging");
    }

    public void OnEndDrag (PointerEventData pointer)
    {
        GetComponent<Image>().raycastTarget = true;
    }
}
