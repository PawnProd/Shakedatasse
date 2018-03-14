using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTools : MonoBehaviour {

	public static string[] GetAllScenes()
    {
        int nbScenes = SceneManager.sceneCountInBuildSettings;
        string[] allScenes = new string[nbScenes];
        for(int i = 0; i < nbScenes; ++i)
        {
            allScenes[i] = System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i));
        }

        return allScenes;
    }

    public static void ReplaceScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
