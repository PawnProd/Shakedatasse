using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_GoldDream : MonoBehaviour {

    public List<Transform> dreamSpawns;
    public List<GameObject> dreams;

    public GameObject lastDream = null;
    public GameObject treasure;

    public AudioClip clip;
    public AudioSource lostSource;
    public AudioSource winSource;

    public TimerScript timerScript;

    public GameObject rule;

    public bool hasSpawned;

  

    public float delay;
    public float timer;
    public float dreamFrequency;
    public float treasurePopTime; //dreamFrequency != treasurePopTime
	// Use this for initialization
	void Start () {
        GameController.Instance.minigameState = MiniGameState.running;
        AudioController.Instance.ChangeClip(clip);
        CreateNewDream();
        dreamFrequency -= dreamFrequency * GameController.Instance.speedRatio;
        treasurePopTime = timerScript.maxTimer * 0.4f;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameController.Instance.minigameState == MiniGameState.running)
        {
            if (timerScript.timer >= timerScript.maxTimer * 0.2f)
            {
                rule.SetActive(false);
            }
            if (!hasSpawned)
            {
                timer += Time.deltaTime;
            }
            else timer = 0;


            if (lastDream != null)
            {
                if (delay < dreamFrequency)
                {
                    delay += Time.deltaTime;
                }
                else
                {
                    print("pop");
                    CreateNewDream();
                    delay = 0;
                }

            }
        }
    }

    public void EndGame(bool isWin)
    {
        if (isWin)
        {
            winSource.Play();

        }
        else
        {
            lostSource.Play();
        }

        GameController.Instance.EndMiniGame(isWin);
    }

    public void CreateNewDream()
    {
        GameObject randomDream = dreams[Random.Range(0, dreams.Count)];
        Transform randomSpawnPos = dreamSpawns[Random.Range(0, dreamSpawns.Count)];

        randomDream.GetComponent<Rigidbody2D>().gravityScale += randomDream.GetComponent<Rigidbody2D>().gravityScale * GameController.Instance.speedRatio;


        if (timer < treasurePopTime)
        {
            lastDream = Instantiate(randomDream, randomSpawnPos.position, Quaternion.identity);
        }

        if (timer > treasurePopTime)
        {
            
            Instantiate(treasure, randomSpawnPos.position, Quaternion.identity);
            hasSpawned = true;
           
        }
    }
}
