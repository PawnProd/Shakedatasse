using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {

    public AudioClip[] randomClips;

	public void PlayClip()
    {
        int random = Random.Range(0, randomClips.Length);
        GetComponent<AudioSource>().clip = randomClips[random];
        GetComponent<AudioSource>().Play();
    }
}
