using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] MusicPlayer myMusicPlayer;
    AudioSource myAudioSource;
    Slider volumeSlider;

    void Start()
    {
        myMusicPlayer = FindObjectOfType<MusicPlayer>();
        myAudioSource = myMusicPlayer.GetComponent<AudioSource>();
        volumeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
         myAudioSource.volume = volumeSlider.value;
    }
}
