using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider _volumeSlider;

    public Sound[] Sounds;

    public static AudioManager Instance;

    private AudioSource _audioSource;

    private AudioClip[] _walkSounds;
    private AudioClip[] _slideSounds;
    private AudioClip[] _landSounds;
    private AudioClip[] _mgBadSliderSounds;
    private AudioClip[] _mgMediumSliderSounds;
    private AudioClip[] _mgGoodSliderSounds;
    private AudioClip[] _mgShotSounds;
    private AudioClip[] _mgTargetSounds;
    private AudioClip[] _mgUiSounds;

    private int _randomSoundNum;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
            Load();
        }
        else
        {
            Load();
        }

        _audioSource = GetComponent<AudioSource>();
        _walkSounds = Resources.LoadAll<AudioClip>("FT_Runners_Rock_Walk");
        _slideSounds = Resources.LoadAll<AudioClip>("FT_Runners_Rock_Slide");
        _landSounds = Resources.LoadAll<AudioClip>("FT_Runners_Rock_Land");
        _mgBadSliderSounds = Resources.LoadAll<AudioClip>("SFX_MG1_Press_Bad");
        _mgMediumSliderSounds = Resources.LoadAll<AudioClip>("SFX_MG1_Press_Medium");
        _mgGoodSliderSounds = Resources.LoadAll<AudioClip>("SFX_MG1_Press_Good");
        _mgShotSounds = Resources.LoadAll<AudioClip>("SFX_MG2_Shot");
        _mgTargetSounds = Resources.LoadAll<AudioClip>("SFX_MG2_Target_Appearance");
        _mgUiSounds = Resources.LoadAll<AudioClip>("UI_Button_Selection");

        PlaySingleSound("Music");
        PlaySingleSound("Particules_Sound");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayUiSound();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = _volumeSlider.value;
        Save();
    }

    private void Load()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("volume", _volumeSlider.value);
    }

    public void PlaySingleSound(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.Source.Play();
        //How to play sound in scripts:
        //FindObjectOfType<AudioManager>().PlaySingleSound("name of the sound");
    }

    public void PlayWalkSound()
    {
        _randomSoundNum = Random.Range(0, 11);
        _audioSource.PlayOneShot(_walkSounds[_randomSoundNum]);
    }

    public void PlaySlideSound()
    {
        _randomSoundNum = Random.Range(0,3);
        _audioSource.PlayOneShot(_slideSounds[_randomSoundNum]);
    }

    public void PlayLandSound()
    {
        _randomSoundNum = Random.Range(0, 4);
        _audioSource.PlayOneShot(_landSounds[_randomSoundNum]);
    }

    public void PlayBadSliderSound()
    {
        Debug.Log("Bad Slider!");
        _randomSoundNum = Random.Range(0, 4);
        _audioSource.PlayOneShot(_mgBadSliderSounds[_randomSoundNum]);
    }

    public void PlayGoodSliderSound()
    {
        Debug.Log("Good Slider!");
        _randomSoundNum = Random.Range(0, 4);
        _audioSource.PlayOneShot(_mgGoodSliderSounds[_randomSoundNum]);
    }

    public void PlayShotSound()
    {
        _randomSoundNum = Random.Range(0, 5);
        _audioSource.PlayOneShot(_mgShotSounds[_randomSoundNum]);
    }

    public void PlayTargetSound()
    {
        _randomSoundNum = Random.Range(0, 5);
        _audioSource.PlayOneShot(_mgTargetSounds[_randomSoundNum]);
    }

    public void PlayUiSound()
    {
        _randomSoundNum = Random.Range(0, 3);
        _audioSource.PlayOneShot(_mgUiSounds[_randomSoundNum]);
    }

    //How to play sound in scripts:
    //FindObjectofType<AudioManager>().Play("name of the sound");
}
