using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanelCtrl : MonoBehaviour {
    [Header("Left")]
    [SerializeField]
    Painter ImageLeft;
    [SerializeField]
    InputField lengthLeft;
    [SerializeField]
    InputField speedLeft;
    [SerializeField]
    InputField levelLeft;
    [Header("Right")]
    [SerializeField]
    Painter ImageRight;
    [SerializeField]
    InputField lengthRight;
    [SerializeField]
    InputField speedRight;
    [SerializeField]
    InputField levelRight;
    [Header("Button Area")]
    [SerializeField]
    Button calBtn;
    [SerializeField]
    Button backBtn;
    [SerializeField]
    Button closeBtn;

    // Use this for initialization
    void Start () {
        calBtn.onClick.AddListener(calBtnClick);
        backBtn.onClick.AddListener(backBtnClick);
        closeBtn.onClick.AddListener(closeBtnClick);
	}

    public void RefreshPanel()
    {
        //to do  清空图片
        lengthLeft.text = "";
        speedLeft.text = "";
        levelLeft.text = "";
        lengthRight.text = "";
        speedRight.text = "";
        levelRight.text = "";
    }

    void calBtnClick() {
        RefreshResult();
    }
    void RefreshResult()
    {
        //to do 刷新图片
        lengthLeft.text = MainManager.Instance.MaxXValue.ToString();
        speedLeft.text = MainManager.Instance.MaxYValue.ToString();
        levelLeft.text = Mathf.Ceil(Global.Instance.gbData.HorizLength / MainManager.Instance.MaxXValue).ToString();

        float offset = 22.5f * Mathf.Deg2Rad;
        lengthRight.text = (MainManager.Instance.MaxXValue * Mathf.Cos(offset)).ToString();
        speedRight.text = (MainManager.Instance.MaxYValue * Mathf.Cos(offset)).ToString();
        levelRight.text = Mathf.Ceil(Global.Instance.gbData.MakeXieLength * 0.64f / (MainManager.Instance.MaxXValue * Mathf.Cos(offset))).ToString();
    }
    void backBtnClick()
    {
        Global.Instance.EnterTipPanel();
    }
    void closeBtnClick()
    {
        Application.Quit();
    }
}
