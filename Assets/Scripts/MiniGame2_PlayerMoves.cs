using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2_PlayerMoves : MonoBehaviour {

    public float playerSpeed;

    public RandomSound moveSource;

    public MiniGame_GoldDream miniGameController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.Instance.minigameState == MiniGameState.running)
        {
            if (InputManager.IsHeld(InputName.leftDirection))
            {
                moveSource.PlayClip();
                transform.Translate(Vector3.left * playerSpeed);
            }

            if (InputManager.IsHeld(InputName.rightDirection))
            {
                moveSource.PlayClip();
                transform.Translate(Vector3.right * playerSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameController.Instance.minigameState == MiniGameState.running)
        {
            if (collision.gameObject.tag == "Bad Dream")
            {
                miniGameController.EndGame(false);
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Treasure")
            {
                miniGameController.EndGame(true);
                Destroy(collision.gameObject);
            }
        }
    }
}
