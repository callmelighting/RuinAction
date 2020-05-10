using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameControl : MonoBehaviour
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

    public void OKButton()
    {
        MusicStartControl.ButtonMusicPlay(true);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void CancelButton()
    {
        gameObject.SetActive(false);
        MusicStartControl.ButtonMusicPlay(true);
    }
}
