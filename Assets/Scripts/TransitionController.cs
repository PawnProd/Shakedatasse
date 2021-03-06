﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour {

    public TransitionATHManager athManager;
    public float transitionTime;

    public AudioClip clipWin;
    public AudioClip clipLose;

    private GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = GameController.Instance;
        
        if(GameController.Instance.GetNextScene() == "Bossgame")
        {
            athManager.SetBossAnnounce();
        }

        // On définit le clip à jouer en fonction de l'état du jeu
        if (gameController.gameState == "LOSE")
        {
            AudioController.Instance.ChangeClip(clipLose);
           
        }
        else
        {
            AudioController.Instance.ChangeClip(clipWin);
        }
        athManager.RemoveHeart(gameController.life);
        transitionTime = AudioController.Instance.source.clip.length;
        StartCoroutine(WaitInput());
        athManager.SetPlayerName(gameController.playerName);
        athManager.SetLevelText(gameController.level.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WaitInput()
    {
        yield return new WaitForSeconds(transitionTime / 2);
        StartCoroutine(WaitEndScene());
    }

    IEnumerator WaitEndScene()
    {
        athManager.HidePlayer();
        athManager.SetInputInfoImg(gameController.GetSpriteInputInfo());
        athManager.ShowInputInfo();
        yield return new WaitForSeconds(transitionTime / 2);
        gameController.NextScene();
    }
}
