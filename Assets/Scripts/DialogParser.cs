using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDialogEnd();

public class DialogParser
{
    private OnDialogEnd onDialogEnd;
    public OnDialogEnd OnDialogEnd { set => onDialogEnd = value; }

    private string[] plotstrArray;
    private int plotIndex;
    private string[] dialog;

    public DialogParser(string plotPath)
    {
        plotstrArray = Resources.Load<TextAsset>(plotPath).text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }

    public void Exeute(DialogControl dialogControl)
    {
        if (plotIndex != plotstrArray.Length + 1)
        {
            if (dialogControl.TextIndex == 0 && plotIndex < plotstrArray.Length)
                dialog = plotstrArray[plotIndex++].Split('|');
            dialogControl.ShowDialog(dialog[0], dialog[1]);
            if (plotIndex == plotstrArray.Length)
                onDialogEnd?.Invoke();
        }
    }
}
