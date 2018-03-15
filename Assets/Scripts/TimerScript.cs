using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour {

    public Transform beginPos;
    public Transform endPos;
    public Transform currentPos;

    public float timer;
    public float maxTimer;

	// Use this for initialization
	void Awake () {
        maxTimer -= GameController.Instance.speedRatio * 2 * maxTimer;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameController.Instance.minigameState == MiniGameState.running)
        {
            timer += Time.deltaTime;

            currentPos.position = Vector3.Lerp(beginPos.position, endPos.position, timer / maxTimer);

            if (timer >= maxTimer)
            {
                GameController.Instance.EndMiniGame(false);

            }
        }
        
	}
}
