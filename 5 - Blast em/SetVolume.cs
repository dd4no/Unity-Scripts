using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    // Audio mixer
    public AudioMixer mixer;

    // Volume control
    public void SetLevel(float sliderValue)
    {
        // Set volume level based on input
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}
