using LastPlayer.LagosMetro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AlertBox : MonoBehaviour
{
    public Text Title;
    public Button YesBtn;
    public Button NoBtn;

    public void SetTitle(string s, UnityAction yesAction = null, UnityAction NoAction = null)
    {
        YesBtn.onClick.RemoveAllListeners();
        NoBtn.onClick.RemoveAllListeners();
        Title.text = s;
        if (yesAction != null && NoAction != null)
        {
            YesBtn.onClick.AddListener(yesAction);
            NoBtn.onClick.AddListener(NoAction);
        }
        else
        {
            YesBtn.onClick.AddListener(GameManager.NewGame);
            NoBtn.onClick.AddListener(GameManager.Quit);
        }
    }
}
