using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuATHManager : MonoBehaviour {

    public InputField nameField;
    public GameController gameController;

	public string GetNameFromNameField()
    {
        return nameField.text;
    }

    public void SavePlayerName()
    {
        string name = GetNameFromNameField();
        if (name != "")
        {
            gameController.playerName = name;
        }
        
    }
}
