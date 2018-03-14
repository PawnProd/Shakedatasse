using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {

    public BossPhase phase;

	// Use this for initialization
	void Start () {
        phase = BossPhase.phase1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum BossPhase
{
    phase1,
    phase2
}
