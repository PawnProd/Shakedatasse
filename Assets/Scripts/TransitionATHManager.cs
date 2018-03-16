using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionATHManager : MonoBehaviour {

    public List<GameObject> heartsImages;

    public Text levelText;
    public Text playerName;

    public Image player;

    public Sprite bossAnnounce;

    public GameObject panelPlayer;
    public GameObject inputInfo;

    /// <summary>
    /// Supprime les coeurs de l'ath en fonction de <paramref name="life"/> du player
    /// </summary>
    /// <param name="life">La vie restante du player</param>
    public void RemoveHeart(int life)
    {
        for(int i = heartsImages.Count - 1; i >= life; --i)
        {
            GameObject heart = heartsImages[i];
            Destroy(heart);
        }
       
    }

    /// <summary>
    /// Change le texte lié au level
    /// </summary>
    /// <param name="level">Le nouveau level à afficher</param>
    public void SetLevelText(string level)
    {
        levelText.text = level;
    }

    /// <summary>
    /// Cache le sprite du player et le texte du level
    /// </summary>
    public void HidePlayer()
    {
        panelPlayer.SetActive(false);
    }

    /// <summary>
    /// Change le sprite de l'image de l'input
    /// </summary>
    /// <param name="newSprite"> Le nouveau sprite à mettre dans l'image</param>
    public void SetInputInfoImg(Sprite newSprite)
    {
        inputInfo.GetComponent<Image>().sprite = newSprite;
    }

    /// <summary>
    /// Montre le sprite de l'input à utiliser au prochain mini jeu
    /// </summary>
    public void ShowInputInfo()
    {
        inputInfo.SetActive(true);
    }

    /// <summary>
    /// Change le nom du player dans l'ATH
    /// </summary>
    /// <param name="name">Le nom du player</param>
    public void SetPlayerName(string name)
    {
        playerName.text = name;
    }

    public void SetBossAnnounce()
    {
        player.sprite = bossAnnounce;
    }
}
