using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClip countdownAudioClip;
    [SerializeField] private AudioClip coinAudioClip;
    [SerializeField] private AudioClip deathAudioClip;
    private AudioSource audioSource;

    private float volume = 1.0f;

    private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    private void Awake()
    {
        Instance = this;
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 1f);
    }
    private void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }



    public void PlayCountdownSound()
    {
        audioSource.clip= countdownAudioClip;
        audioSource.Play();
        
    } 
    public void PlayCoinSound()
    {
        audioSource.clip= coinAudioClip;
        audioSource.Play();
        
    } 
    public void PlayDeathSound()
    {
        audioSource.clip= deathAudioClip;
        audioSource.Play();
        
    }
 
    public void ChangeVolume()
    {
        volume += .1f;
        if (volume > 1f)
        {
            volume = 0f;
        }
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }
    public float GetVolume()
    {
        return volume;

    }
}
