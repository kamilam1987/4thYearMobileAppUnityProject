using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	// Audio players components.
	public AudioSource PlayerBullet;
    public AudioSource BackgroundMusicSource;
    public AudioSource ExposiondMusicSource;
    public AudioSource EnemyMusicSource;

    private AudioSource audioSrc;//Reference to Audio Source component
    private float musicVolume = 1f;//Music volume

    // Random pitch adjustment range.
    public float LowPitchRange = .95f;
    public float HighPitchRange = 1.05f;

    // Singleton instance.
    public static SoundManager Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //Assign Audo Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Setting volume option of Audio Source to equal to music volume
        audioSrc.volume = musicVolume;
    }
    //SetVolume method takes vol value passed by slider and sets it to musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    // Play a single clip through the sound effects source.
    public void Play(AudioClip clip)
    {
        PlayerBullet.clip = clip;
        PlayerBullet.Play();
    }

    // Play a single clip through the sound effects source.
    public void PlayExplosion(AudioClip clip)
    {
        ExposiondMusicSource.clip = clip;
        ExposiondMusicSource.Play();
    }

    // Play a single clip through the sound effects source.
    public void PlayEnemy(AudioClip clip)
    {
        EnemyMusicSource.clip = clip;
        EnemyMusicSource.Play();
    }
    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        BackgroundMusicSource.clip = clip;
        BackgroundMusicSource.Play();
    }

}
