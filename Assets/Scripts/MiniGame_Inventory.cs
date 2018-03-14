using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame_Inventory : MonoBehaviour {

    public Sprite[] weaponList;
    public Sprite[] foodList;
    public Sprite[] elixirList;


    public Dictionary<string, Sprite[]> masterList = new Dictionary<string, Sprite[]>();

    public Image objectToSort;
    public Image emptySlot;

    public GameObject[] inventoryPanels;

    public string goodInventory;

    private List<string> _keyNames = new List<string>();



    // Use this for initialization
    void Start () {

        CreateDictionary();
        CreateKeyList();
        InstantiateObjectToSort();
        CreateInventory();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateDictionary() // Create a dictionary with 3 tables (Food/Weapons/Elixirs)
    {
        masterList.Add("food", foodList);
        masterList.Add("weapon", weaponList);
        masterList.Add("elixir", elixirList);
    }

    void CreateKeyList() // Create a key list to store the name of the dictionary keys (allows to pick a random key)
    {
        _keyNames.Add("food");
        _keyNames.Add("weapon");
        _keyNames.Add("elixir");
    }

    void InstantiateObjectToSort() //Function to pick a random sprite in a random list in the dictionary we've created. Also defines what will be the inventory to drop the object in
    {
        string keyToUse = _keyNames[Random.Range(0, _keyNames.Count)];
        Sprite[] tabToUse = masterList[keyToUse];
        Sprite newSpriteToUse = tabToUse[Random.Range(0, tabToUse.Length)];
        objectToSort.sprite = newSpriteToUse;
        objectToSort.GetComponent<DragItem>().typeItem = keyToUse;
    }

    void CreateInventory() //Displays the Inventories on the scree
    {
        foreach (GameObject panel in inventoryPanels) // We have a table of 3 panels we want to fill
        {
            Image[] inventorySlots = new Image[12]; //Those are images created to store the different sprites to display. There are 12 slots in our inventory
            int randomNumber = Random.Range(3, 8); // we want to generate between 3 and 8 objects in the inventory panel out of 12 slots
            int randomKey = Random.Range(0, _keyNames.Count); //In order to randomize the panel completion order, we generate another random number
            string keyToUse = _keyNames[randomKey]; // And then we chose in our list of key names

            /* Here we want to fill our panel with empty slots */

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                GameObject newEmptySlot = new GameObject("emptyslot" + i, typeof(Image), typeof(DropZone)); // We instantiate the images by creating gameobjects
                newEmptySlot.GetComponent<Image>().sprite = emptySlot.sprite; //We change the sprite of all slots by "emptySlot" sprites
                newEmptySlot.GetComponent<DropZone>().zoneType = keyToUse;
                newEmptySlot.GetComponent<DropZone>().levelManager = this;
                inventorySlots[i] = newEmptySlot.GetComponent<Image>();
                inventorySlots[i].rectTransform.SetParent(panel.transform, false); //Parent them to the panel to sort them well on screen
            }

            /* Then we want to replace the sprites with object sprites */

            for (int i = 0; i < randomNumber; i++)
            {
                inventorySlots[i].sprite = RandomSpriteInDictionaryTab(keyToUse); // We chose a sprite in a single array and display as much sprite as the randomNumber tells us
            }

            /* Finally we remove the values both in the keyname list and in the dictionary so that we don't instantiate the same inventory twice */

            _keyNames.Remove(keyToUse);
            masterList.Remove(keyToUse);
        }
    }


    Sprite RandomSpriteInDictionaryTab(string key) // Function to pick a random sprite in a chosen part of the dictionary
    {
        Sprite[] tabSprite = masterList[key];
        Sprite inventoryItem = tabSprite[Random.Range(0, tabSprite.Length)];

        return inventoryItem;
    }

    public void EndGame (bool endCondition)
    {
        if (endCondition)
        {
            print("You Win!");
        }
        else
        {
            print("You Lose!");
        }
    }

}
