﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TipPanelCtrl : MonoBehaviour {
    [SerializeField]
    private InputField input;
    [SerializeField]
    private Text tipsText;
    [SerializeField]
    private Button enterBtn;

    private Global global;
    public Global Global
    {
        get
        {
            return global;
        }

        set
        {
            global = value;
        }
    }

    // Use this for initialization
    void Start () {
        InitPanel();
    }
	
    void InitPanel()
    {
        HideTips();
        enterBtn.onClick.AddListener(EnterBtnClick);
    }

    void ShowTips(string message)
    {
        tipsText.gameObject.SetActive(true);
        tipsText.text = message;
        //Invoke("HideTips", 3f);
    }

    void HideTips()
    {
        tipsText.gameObject.SetActive(false);
    }

    float GetInputMsg()
    {
        float result = 0;
        bool canParse = float.TryParse(input.text, out result);
        if (canParse)
            return result;
        else
            return -1;
    }

    void EnterBtnClick()
    {
        float inputFloat = GetInputMsg();
        if (inputFloat < 0.04f || inputFloat >= 0.15f)
            ShowTips("不适用");
        else if(inputFloat >= 0.04f & inputFloat < 0.08f)
            Global.EnterDataPanel(1);
        else
            Global.EnterDataPanel(2);
    }
}
