﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
	}
}
