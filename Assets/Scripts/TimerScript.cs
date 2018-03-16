using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public Transform beginPos;
    public Transform endPos;
    public Transform currentPos;

    public Image filledImg;

    public float timer;
    public float maxTimer;
    public float ratioTime;

	// Use this for initialization
	void Awake () {
        maxTimer -= GameController.Instance.gameRatio * maxTimer;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameController.Instance.minigameState == MiniGameState.running)
        {
            timer += Time.deltaTime;
            ratioTime = (maxTimer - timer) / maxTimer;
            filledImg.fillAmount = ratioTime;

            currentPos.position = Vector3.Lerp(beginPos.position, endPos.position, timer / maxTimer);

            if (timer >= maxTimer)
            {
                GameController.Instance.EndMiniGame(false);

            }
        }
        
	}
}
