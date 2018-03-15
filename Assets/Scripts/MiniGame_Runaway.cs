using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_Runaway : MonoBehaviour {

    public GameObject monster;

    public Transform monsterSpawn;

    public AudioClip clip;
    public AudioSource loseSource;
    public AudioSource winSource;
    public AudioSource monsterSource;

    public float playerSpeed;
    public float monsterSpeed;
    public float timeScale; // au moins 10 sinon le monstre est trop rapide
    public bool isStart = false;

    private GameObject newMonster = null;
    

	// Use this for initialization
	void Start () {
        
        StartCoroutine(WaitStart());
        AudioController.Instance.ChangeClip(clip);
        monsterSpeed += monsterSpeed * GameController.Instance.speedRatio;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(newMonster != null && isStart && GameController.Instance.minigameState == MiniGameState.running)
        {
            monsterSpeed += Time.deltaTime / timeScale;
            newMonster.transform.Translate(Vector3.left * monsterSpeed);
        }

	}

    public void EndGame(bool isWin)
    {
        if(isWin)
        {
            winSource.Play();
        }
        else
        {
            loseSource.Play();
        }
        GameController.Instance.EndMiniGame(isWin);
    }

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(1);
        newMonster = Instantiate(monster, monsterSpawn.position, Quaternion.identity);
        monsterSource.Play();
        isStart = true;
        GameController.Instance.minigameState = MiniGameState.running;
    }
}
