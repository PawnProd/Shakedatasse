﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossATHManager : MonoBehaviour {

    public Text qteText;

	public void ShowCanvas()
    {
        gameObject.SetActive(true);
    }

    public void SetQTEText(string qte)
    {
        qteText.text = qte;
    }
}
