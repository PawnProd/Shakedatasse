using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Reflection;

public class BossManager : MonoBehaviour {

    public BossPhase phase;
    public BossATHManager athManager;

    public List<Transform> trapSpawners;
    public GameObject[] allTrapsPrefab;

    public AudioClip clipPhase1;
    public AudioClip clipPhase2;
    public AudioSource loseSource;

    public List<string> allKeyInputsName = new List<string>();
    public Queue qteInput = new Queue();
    public string qte;

    public float delayBeforeNextQTE = 5f;

    private float _timer = 0;

	// Use this for initialization
	void Start () {
        phase = BossPhase.phase1;
        GenerateRandomTrap();
        GenerateQTE();
        AudioController.Instance.ChangeClip(clipPhase1);
        delayBeforeNextQTE -= Mathf.Clamp(delayBeforeNextQTE * GameController.Instance.speedRatio, 2, 5);
	}

    private void Update()
    {
        if(phase == BossPhase.phase2)
        {
            _timer += Time.deltaTime;
            if (_timer >= delayBeforeNextQTE)
            {
                EndGame(false);
            }
        }
       
    }

    public void EndGame(bool isWin)
    {
        if(!isWin)
        {
            loseSource.Play();
        }
        GameController.Instance.EndMiniGame(isWin);
    }

    public void GenerateRandomTrap()
    {
        int playerLife = GameController.Instance.life;

        int randomNbTrap = UnityEngine.Random.Range(Mathf.Clamp(playerLife, 1, 4), playerLife + 2);

        for(int i = 0; i < randomNbTrap; ++i)
        {
            int randomSpawner = UnityEngine.Random.Range(0, trapSpawners.Count);
            Transform trapSpawn = trapSpawners[randomSpawner];
            SpawnTrap(trapSpawn.position);
            trapSpawners.Remove(trapSpawn);
        }
    }

    public void GetAllsInputsName()
    {
        Type type = typeof(InputName);
        foreach(var p in type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
        {
            string value = p.GetValue(null).ToString();
            if(value.Length == 1)
            {
                allKeyInputsName.Add(value);
            }  
        }
    }

    public void GenerateQTE()
    {
        int playerLife = 4;
        GetAllsInputsName();
        int randomNbQTE = UnityEngine.Random.Range(4, playerLife + 3);
        for(int i = 0; i < randomNbQTE; ++i)
        {
            int randomQTE = UnityEngine.Random.Range(0, allKeyInputsName.Count);
            qteInput.Enqueue(allKeyInputsName[randomQTE]);
        }
    }

    public void NextQTE()
    {
        _timer = 0;
        qte = qteInput.Dequeue().ToString();
        athManager.SetQTEText(qte);
        if (qteInput.Count == 0)
        {
            EndGame(true);
        }
    }

    public void ShowQTE()
    {
        AudioController.Instance.ChangeClip(clipPhase2);
        athManager.ShowCanvas();
        qte = qteInput.Dequeue().ToString();
        athManager.SetQTEText(qte);
        
    }

    public void SpawnTrap(Vector3 position)
    {
        int randomTrap = UnityEngine.Random.Range(0, allTrapsPrefab.Length);
        Instantiate(allTrapsPrefab[randomTrap], position, Quaternion.identity);
    }
}

public enum BossPhase
{
    phase1,
    phase2
}
