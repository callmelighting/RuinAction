using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AboutGameControl : MonoBehaviour
{
    private Scrollbar bVolume;
    private Scrollbar mVolume;
    private AudioListener startAudioListener;
    // Start is called before the first frame update
    void Start()
    {
        bVolume = transform.Find("MusicPanel/Bvolume").GetComponent<Scrollbar>();
        mVolume = transform.Find("MusicPanel/Mvolume").GetComponent<Scrollbar>();
        startAudioListener = GameObject.FindWithTag("MainCamera").GetComponent<AudioListener>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void QuitAboutGame()
    {
        gameObject.SetActive(false);
        MusicStartControl.ButtonMusicPlay(true);
    }

    public void startMusicVolume()
    {
        AudioListener.volume = bVolume.value;
        PlayerPrefs.SetFloat("startVolume", bVolume.value);
    }
    public void levelMusicVolume()
    {
        MusicLevelControl.mVolume = mVolume.value;
        PlayerPrefs.SetFloat("levelVolume", mVolume.value);
    }
}
