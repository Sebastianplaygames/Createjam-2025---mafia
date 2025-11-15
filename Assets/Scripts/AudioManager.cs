using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Sources ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    
    [Header("---------- Audio Clips ----------")]
    public AudioClip backgroundMusic;
    public AudioClip death;


    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayLoop(AudioClip clip)
    {
        if (!musicSource.isPlaying)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }
}
