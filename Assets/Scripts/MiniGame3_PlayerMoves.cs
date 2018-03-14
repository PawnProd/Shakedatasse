using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame3_PlayerMoves : MonoBehaviour {


    public float forwardValue;

    public MiniGame_Runaway miniGameController;

    public AudioSource inputSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (InputManager.IsDown(InputName.jump) && miniGameController.isStart && GameController.Instance.minigameState == MiniGameState.running)
        {
            inputSource.Play();
            transform.Translate(-1 + forwardValue,0,0);
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            miniGameController.EndGame(false);
        }
        if (collision.gameObject.tag == "EndZone")
        {
            miniGameController.EndGame(true);
        }
    }
}
