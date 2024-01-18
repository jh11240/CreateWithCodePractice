using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public Slider volumeSlider;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }   

    public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
}
