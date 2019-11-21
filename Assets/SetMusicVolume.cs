using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SetMusicVolume : MonoBehaviour
{

    [SerializeField] AudioSource _audioMenu;
    [SerializeField] Slider _sliderVolume;

    public void VolumeChange()
    {
        _audioMenu.volume = _sliderVolume.value;
    }

}
