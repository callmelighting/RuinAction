using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStartControl : MonoBehaviour
{
    public AudioSource BackGroundMusice;
    public AudioSource ButtonMusic;
    public AudioSource LevelMusic;

    public static MusicStartControl instead;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("startVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("startVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("startVolume", 1);
        }
        instead = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ButtonMusicPlay(bool isPlay)
    {
        if (isPlay)
            instead.ButtonMusic.Play();
        else
            instead.ButtonMusic.Pause();
    }

    public static void LevelMusicPlay(bool isPlay)
    {
        if (isPlay)
            instead.LevelMusic.Play();
        else
            instead.LevelMusic.Pause();
    }

    public static void BackGroundMusicePlay(bool isPlay)
    {
        if (isPlay)
            instead.BackGroundMusice.Play();
        else
            instead.BackGroundMusice.Pause();
    }
}
