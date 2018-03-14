using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler {

    public string zoneType;

    public MiniGame_Inventory levelManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop(PointerEventData pointer)
    {

        if (zoneType == pointer.pointerDrag.GetComponent<DragItem>().typeItem)
        {
            GetComponent<Image>().sprite = pointer.pointerDrag.GetComponent<Image>().sprite;
            Destroy(pointer.pointerDrag.gameObject);
            levelManager.EndGame(true);
        }

        else
        {
            levelManager.EndGame(false);
        }
    }
}
