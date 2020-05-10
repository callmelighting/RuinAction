using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControler : MonoBehaviour
{
    public GameObject player;
    public GameObject selectCanvas;
    public GameObject aboutGameCanvas;
    public GameObject QuitGameCanvas;

    private Vector2 touchposition;
    private Vector2 touchdeltaposition;

    private bool IsTiming;  //是否开始计时
    private float CountDown; //倒计时

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {

            Touch touch = Input.touches[0];

            touchposition = touch.position;
            touchdeltaposition = touch.deltaPosition;

            if (touch.phase == TouchPhase.Moved)
            {
                if (touchposition.x < Screen.width / 2 && touchposition.y < 3 * Screen.height / 4)
                {
                    player.transform.Rotate(10 * Time.deltaTime * touchdeltaposition.x * Vector3.down, Space.World);
                }
            }

        }
        EixtDetection();
    }

    private void EixtDetection()
    {
        if (Application.platform == RuntimePlatform.Android && (Input.GetKeyDown(KeyCode.Escape)))            //如果按下退出键
        {
            if (CountDown == 0)                          //当倒计时时间等于0的时候
            {
                CountDown = Time.time;                   //把游戏开始时间，赋值给 CountDown
                IsTiming = true;                        //开始计时
            }
            else
            {
                Application.Quit();                      //退出游戏
            }
        }

        if (IsTiming) //如果 IsTiming 为 true 
        {
            if ((Time.time - CountDown) > 2.0)           //如果 两次点击时间间隔大于2秒
            {
                CountDown = 0;                           //倒计时时间归零
                IsTiming = false;                       //关闭倒计时
            }
        }
    }

    public void startGame()
    {
        selectCanvas.SetActive(true);
        MusicStartControl.ButtonMusicPlay(true);
    }

    public void quitGame()
    {
        MusicStartControl.ButtonMusicPlay(true);
        QuitGameCanvas.SetActive(true);
    }

    public void aboutGame()
    {
        MusicStartControl.ButtonMusicPlay(true);
        aboutGameCanvas.SetActive(true);
        if (PlayerPrefs.HasKey("startVolume"))
            aboutGameCanvas.transform.Find("MusicPanel/Bvolume").GetComponent<Scrollbar>().value = PlayerPrefs.GetFloat("startVolume");
        if (PlayerPrefs.HasKey("levelVolume"))
            aboutGameCanvas.transform.Find("MusicPanel/Mvolume").GetComponent<Scrollbar>().value = PlayerPrefs.GetFloat("levelVolume");
    }
}
