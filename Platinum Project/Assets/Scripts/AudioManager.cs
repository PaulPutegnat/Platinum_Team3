using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] FT_Runners_Rock_Land;
    public Sound[] FT_Runners_Rock_Run;
    public Sound[] FT_Runners_Rock_Slide;
    public Sound[] FT_Runners_Rock_Walk;
    public Sound[] SFX_MG1_Press_Bad;
    public Sound[] SFX_MG1_Press_Good;
    public Sound[] SFX_MG1_Press_Medium;
    public Sound[] SFX_MG2_Shot;
    public Sound[] SFX_MG2_Target_Appearance;
    public Sound[] UI_Button_Selection;

    public static AudioManager Instance;

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

        foreach (Sound sound in FT_Runners_Rock_Walk)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }
    public void PlayRandomSound(string name)
    {
        Sound s = Array.Find(FT_Runners_Rock_Walk, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.Source.Play();
    }

    //How to play sound in scripts:
    //FindObjectofType<AudioManager>().Play("name of the sound");
}
