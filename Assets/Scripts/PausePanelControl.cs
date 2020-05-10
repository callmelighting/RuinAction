using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanelControl : MonoBehaviour
{
    private string[] tipstrArray;
    private Text tipsText;
    private int tipIndex;
    private Image test;

    private GameObject pauseInterface;
    private GameObject endInterface;
    private GameObject dieInterface;

    private Text EenemyDieText;
    private Text EdiamondoSelectText;
    private Text DenemyDieText;
    private Text DdiamondoSelectText;

    public int thisEnemyNum = 0;
    public int thisDiamondoNum = 0;

    private SenceCreator sc;
    public int DiamondoNumber;
    public int enemyNum; //
    public int diamondoNum; //

    // Start is called before the first frame update
    void Start()
    {
        tipsText = transform.Find("PauseInterface/PauseText").GetComponent<Text>();
        tipstrArray = Resources.Load<TextAsset>("Dialog/tips").text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        pauseInterface = GameObject.Find("PauseInterface");
        endInterface = GameObject.Find("EndInterface");
        dieInterface = GameObject.Find("DieInterface");

        EenemyDieText = transform.Find("EndInterface/EnemyDie").GetComponent<Text>();
        EdiamondoSelectText = transform.Find("EndInterface/DiamondoSelect").GetComponent<Text>();
        DenemyDieText = transform.Find("DieInterface/EnemyDie").GetComponent<Text>();
        DdiamondoSelectText = transform.Find("DieInterface/DiamondoSelect").GetComponent<Text>();

        test = transform.GetComponent<Image>();
        sc = GameObject.Find("/Scripts").GetComponent<SenceCreator>();
        DiamondoNumber = sc.DiamondoNumber;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //暂停界面
    public void Show()
    {
        MusicLevelControl.Btn1MusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
        tipIndex = UnityEngine.Random.Range(0, tipstrArray.Length);
        tipsText.text = tipstrArray[tipIndex];

        gameObject.SetActive(true);
        pauseInterface.SetActive(true);
        endInterface.SetActive(false);
        dieInterface.SetActive(false);

        Time.timeScale = 0;
    }

    //成功界面
    public void ShowEnd()
    {
        gameObject.SetActive(true);
        pauseInterface.SetActive(false);
        endInterface.SetActive(true);
        dieInterface.SetActive(false);

        enemyNum = UIControl.instance.countPanelControl.enemyNum;
        diamondoNum = UIControl.instance.countPanelControl.diamondoNum;
        DiamondoSelectShow();
        EnemyDieTextShow();
    }

    //死亡界面
    public void ShowDie()
    {
        gameObject.SetActive(true);
        pauseInterface.SetActive(false);
        endInterface.SetActive(false);
        dieInterface.SetActive(true);

        enemyNum = UIControl.instance.countPanelControl.enemyNum;
        diamondoNum = UIControl.instance.countPanelControl.diamondoNum;
        DiamondoSelectShow();
        EnemyDieTextShow();
    }

    //四个游戏按钮的执行方法
    public void nextGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Scence2");
        Time.timeScale = 1;
    }

    public void restartGame()
    {
        string SceneIndex = SceneManager.GetActiveScene().name;
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1;
    }

    public void continueGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void quitGame()
    {
        SceneManager.LoadScene("start");
        Time.timeScale = 1;
    }

    //
    public void EnemyDieTextShow()
    {
        thisEnemyNum = 0;
        InvokeRepeating("EnemyDieAdd", 0.0f, 0.1f);
    }

    public void DiamondoSelectShow()
    {
        thisDiamondoNum = 0;
        InvokeRepeating("DiamondoAdd", 0.0f, 0.1f);
    }

    public void EnemyDieAdd()
    {
        if (thisEnemyNum > enemyNum-1)
        {
            CancelInvoke("EnemyDieAdd");
        }
        EenemyDieText.text = ": " + thisEnemyNum;
        DenemyDieText.text = ": " + thisEnemyNum;
        thisEnemyNum++;
    }

    public void DiamondoAdd()
    {
        if (thisDiamondoNum > diamondoNum-1)
        {
            CancelInvoke("DiamondoAdd");
        }
        EdiamondoSelectText.text = ": " + thisDiamondoNum + "/" + DiamondoNumber;//.......
        DdiamondoSelectText.text = ": " + thisDiamondoNum + "/" + DiamondoNumber;//.......
        thisDiamondoNum++;
    }
}
