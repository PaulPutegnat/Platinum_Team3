using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerRef : MonoBehaviour
{
    private AudioManager _audioManagerInstance;

    void Start()
    {
        _audioManagerInstance = AudioManager.Instance;
    }

    void PlayWalkSoundRef()
    {
        _audioManagerInstance.PlayWalkSound();
    }
}
