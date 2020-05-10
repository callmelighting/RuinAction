using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private DialogControl dialogControl;
    private DialogParser dialogParser;

    private EnemyMessageControl enemyMessageControl;
    private UIControl uiControl;

    private bool canBeClick;

    void Start()
    {
        enemyMessageControl = GameObject.Find("Enemy").transform.GetComponent<EnemyMessageControl>();

        dialogControl = transform.GetComponent<DialogControl>();
        uiControl = GameObject.Find("/Canvas").GetComponent<UIControl>();

        int SceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (SceneIndex == 1)
            dialogParser = new DialogParser("Dialog/GameStart");
        else if(SceneIndex == 2)
            dialogParser = new DialogParser("Dialog/GameStart2");

        dialogParser.OnDialogEnd = OnDialogEnd;

        OnGameStart();
    }

    public void OnGameStart()
    {
        canBeClick = true;
        DialogOnclick();
    }

    public void DialogOnclick()
    {
        if (canBeClick)
            dialogParser.Exeute(dialogControl);
    }

    private void OnDialogEnd()
    {
        uiControl.startShowTextControl.Countdown();
        enemyMessageControl.EnemySendMessage(5.0f);
        canBeClick = false;
        gameObject.SetActive(false);
    }
}
