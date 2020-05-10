using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private DialogControl dialogControl;
    private DialogParser dialogParser;
    private UIControl uiControl;


    private bool canBeClick;

    void Start()
    {
        dialogControl = transform.GetComponent<DialogControl>();
        uiControl = GameObject.Find("/Canvas").GetComponent<UIControl>();
    }

    public void OnGameEnd(bool isSuccessful)
    {
        gameObject.SetActive(true);
        canBeClick = true;
        if (isSuccessful)
        {
            dialogParser = new DialogParser("Dialog/GameEnd_S");
            dialogParser.OnDialogEnd = OnDialogNext;

            DialogOnclick();
        }
        else
        {
            dialogParser = new DialogParser("Dialog/GameEnd_US");
            dialogParser.OnDialogEnd = OnDialogEnd;

            DialogOnclick();
        }
    }

    public void DialogOnclick()
    {
        if (canBeClick)
        {
            dialogParser.Exeute(dialogControl);
        }
    }

    //死亡执行
    private void OnDialogEnd()
    {
        canBeClick = false;
        //之后干嘛。。。。。。
        uiControl.pausepanelControl.ShowDie();
        gameObject.SetActive(false);
    }

    //成功执行
    private void OnDialogNext()
    {
        canBeClick = false;
        //之后干嘛。。。。。。
        uiControl.pausepanelControl.ShowEnd();
        gameObject.SetActive(false);
    }
}
