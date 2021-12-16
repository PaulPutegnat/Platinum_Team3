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

    public void PlaySlideSoundRef()
    {
        _audioManagerInstance.PlaySlideSound();
    }

    public void PlayLandSoundRef()
    {
        _audioManagerInstance.PlayLandSound();
    }

    public void PlayRunnersJumpSoundRef()
    {
        _audioManagerInstance.PlayRunnersJumpSound();
    }
}
