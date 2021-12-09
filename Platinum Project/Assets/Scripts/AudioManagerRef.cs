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

    public void PlayBadSliderSoundRef()
    {
        _audioManagerInstance.PlayBadSliderSound();
    }

    public void PlayMediumSliderSoundRef()
    {
        _audioManagerInstance.PlayMediumSliderSound();
    }

    public void PlayGoodSliderSoundRef()
    {
        _audioManagerInstance.PlayGoodSliderSound();
    }

    public void PlayShotSoundRef()
    {
        _audioManagerInstance.PlayShotSound();
    }

    public void PlayTargetSoundRef()
    {
        _audioManagerInstance.PlayTargetSound();
    }

    public void PlayUiSoundRef()
    {
        _audioManagerInstance.PlayUiSound();
    }
}
