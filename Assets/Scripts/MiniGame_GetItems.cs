using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame_GetItems : MonoBehaviour {

    public GameObject flower;

    public GameObject player;

    public Transform spawnPlayer;

    public List<Transform> spawnPositions;

    public AudioClip clipAudio;
    public AudioSource flowerSource;
    public AudioSource groundSource;

    public int pickedFlowers = 0;
    public int maxFlowers;

	void Start () {
        GameController.Instance.minigameState = MiniGameState.running;
        GameObject newPlayer = Instantiate(player, spawnPlayer.position, Quaternion.identity) as GameObject;
        maxFlowers = Mathf.Clamp((int)(GameController.Instance.speedRatio * 100), 1, spawnPositions.Count);
        player = newPlayer;
        CreateItems();
        AudioController.Instance.ChangeClip(clipAudio);
	}
	

	void Update () {
        if(GameController.Instance.minigameState == MiniGameState.running)
        {
            if (InputManager.MouseButtonDown())
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10f;
                Vector3 screentoWorld = Camera.main.ScreenToWorldPoint(mousePos);

                RaycastHit2D hit = Physics2D.Raycast(screentoWorld, Vector2.zero);

                if (hit.collider != null)
                {
                    print(hit.collider.gameObject);

                    if (hit.collider.tag == "Flower")
                    {
                        flowerSource.GetComponent<RandomSound>().PlayClip();
                        Destroy(hit.collider.gameObject);
                        pickedFlowers++;
                        player.transform.position = hit.collider.transform.position;
                    }
                    else
                    {
                        groundSource.Play();
                    }
                }
                else
                {
                    groundSource.Play();
                }
            }



            if (pickedFlowers == maxFlowers)
            {
                GameController.Instance.EndMiniGame(true);
            }
        }  
    }



    public void CreateItems ()
    {
        for (int i = 0; i < maxFlowers; i++)
        {
            int randomNumber = Random.Range(0, spawnPositions.Count);
            Transform currentSpawnPos = spawnPositions[randomNumber];
            Instantiate(flower, currentSpawnPos.position, Quaternion.identity);
            spawnPositions.Remove(currentSpawnPos);
        }
    }
}
