using UnityEngine;
using UnityEngine.UI;

public class GameOverATH : MonoBehaviour {

    public Text levelText;

    private void Start()
    {
       levelText.text = "Level : " + GameController.Instance.level.ToString();
    }

    public void Rejouer()
    {
        SceneTools.ReplaceScene("Menu");
        Destroy(GameController.Instance.gameObject);
        AudioController.Instance.ResetPitch();
        Destroy(AudioController.Instance.gameObject);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
