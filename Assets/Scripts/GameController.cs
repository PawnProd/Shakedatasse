using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController Instance { get; private set; }

    public MiniGameState minigameState;

    // INFO SUR LES INPUTS A UTILISER DANS LA SCENE
    [System.Serializable]
    public struct SceneToInputInfo
    {
        public string sceneName;
        public Sprite inputInfoSprite;
    }
    public List<SceneToInputInfo> inputInfoByScene;

    // PARAMETRES DE JEU
    public string playerName = "Jacky";
    public int life = 4;
    public int level = 1;
    public float delayBeforeNextScene = 1f;
    public float speedRatio = 0;

    // ETAT DU JEU (WIN ou LOSE)
    public string gameState;
    public bool waitDelay = false;

    // GESTION DES DIFFERENTES SCENES
    private Queue sortPlayScene;
    private List<string> _allMiniGameScenes;
    private string _transitionScene;
    private string _bossScene;

    private void Awake()
    {
        // Creation d'un singleton
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        InitGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Initialise les paramètres du jeu
    /// </summary>
    public void InitGame()
    {
        gameState = "WIN";
        _allMiniGameScenes = new List<string>();
        ParseScene();
        sortPlayScene = new Queue();
        FillQueue();
    }

    /// <summary>
    /// Trie l'ensemble des scènes en fonction de leurs noms
    /// </summary>
    public void ParseScene()
    {
        string[] allScenes = SceneTools.GetAllScenes();
        foreach(string scene in allScenes)
        {

            if(scene.Contains("Minigame"))
            {
                _allMiniGameScenes.Add(scene);
            }
            else if (scene.Contains("Bossgame"))
            {
                _bossScene = scene;
            }
            else if(!scene.Contains("Menu"))
            {
                _transitionScene = scene;
            }
        }
    }

    /// <summary>
    /// Remplit la file en alternant scène de transition et minijeux et ajoute à la fin un mini jeu boss
    /// </summary>
    public void FillQueue()
    {
        int nbSceneGame = _allMiniGameScenes.Count;
        for (int i = 0; i < nbSceneGame; ++i)
        {
            int random = Random.Range(0, _allMiniGameScenes.Count);
            string sceneName = _allMiniGameScenes[random];

            sortPlayScene.Enqueue(_transitionScene);
            sortPlayScene.Enqueue(sceneName);
            
            _allMiniGameScenes.Remove(sceneName);
            
        }
        sortPlayScene.Enqueue(_transitionScene);
        sortPlayScene.Enqueue(_bossScene);
    }

    /// <summary>
    /// Déclenche la fin d'un mini jeu
    /// </summary>
    /// <param name="isWin"> Définit si le joueur à gagner ou perdu le mini jeu</param>
    public void EndMiniGame(bool isWin)
    {
        if(!waitDelay)
        {
            minigameState = MiniGameState.paused;
            waitDelay = true;
            if (isWin)
            {
                gameState = "WIN";
            }
            else
            {
                gameState = "LOSE";
                --life;
            }
            ++level;
            StartCoroutine(NextSceneDelayed());
        }
      
    }

    IEnumerator NextSceneDelayed()
    {
        yield return new WaitForSeconds(delayBeforeNextScene);
        NextScene();
        waitDelay = false;
    }

    /// <summary>
    /// Load la scène suivante tout en actualisant la file
    /// </summary>
    public void NextScene()
    {
        
        string sceneName = sortPlayScene.Dequeue().ToString();
        print(sceneName);
        if(sceneName.Contains("Minigame"))
        {
            _allMiniGameScenes.Add(sceneName);
        }
        else if(sceneName.Contains("Bossgame"))
        {
            FillQueue();
        }
        speedRatio += 0.001f;
        AudioController.Instance.ChangePitch(speedRatio);
        SceneTools.ReplaceScene(sceneName);
    }

    /// <summary>
    /// Récupère la première scène de la file
    /// </summary>
    /// <returns>La première scène dans le file</returns>
    public string GetNextScene()
    {
        return sortPlayScene.Peek().ToString();
    }

    /// <summary>
    /// Récupère le sprite de l'input en fonction de la prochaine scene
    /// </summary>
    /// <returns>Sprite de l'input</returns>
    public Sprite GetSpriteInputInfo()
    {
        int i = 0;
        bool find = false;
        string nextSceneName = GetNextScene();
        Sprite infoInput = null;
        while (i < inputInfoByScene.Count && !find)
        {
            if(inputInfoByScene[i].sceneName == nextSceneName)
            {
                find = true;
                infoInput = inputInfoByScene[i].inputInfoSprite;
            }

            ++i;
        }

        return infoInput;
    }
}

public enum MiniGameState
{
    running,
    paused
}
