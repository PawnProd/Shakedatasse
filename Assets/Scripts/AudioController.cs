using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public static AudioController Instance { get; private set; }

    public AudioSource source;

    private void Awake()
    {
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
        source = GetComponent<AudioSource>();
	}

    /// <summary>
    /// Change le <paramref name="clip"/> d'une source audio
    /// </summary>
    /// <param name="clip">Le nouveau clip à mettre dans la source audio</param>
    public void ChangeClip(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void ChangePitch(float ratio)
    {
        UnityEngine.Audio.AudioMixerGroup mixer = source.outputAudioMixerGroup;
        float pitch;
        mixer.audioMixer.GetFloat("PitchVolume", out pitch);
        pitch += pitch * ratio;
        mixer.audioMixer.SetFloat("PitchVolume", pitch);
    }
	
	
}
