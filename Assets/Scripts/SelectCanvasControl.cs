using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCanvasControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFirstLevel1()
    {
        MusicStartControl.LevelMusicPlay(true);
        SceneManager.LoadScene("Scence1");
    }

    public void startFirstLevel2()
    {
        MusicStartControl.LevelMusicPlay(true);
        SceneManager.LoadScene("Scence2");
    }

    public void quitSlectCanvas()
    {
        MusicStartControl.ButtonMusicPlay(true);
        gameObject.SetActive(false);
    }
}
