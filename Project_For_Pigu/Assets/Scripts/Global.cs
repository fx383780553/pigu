using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
    private GameObject mainCanvas;
    private GameObject tipPanel;
    private GameObject dataPanel;
    private GameObject errorTipPanel;
    private static Global instance;

    public static Global Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        mainCanvas = GameObject.FindWithTag("MainCanvas");
    }
	// Use this for initialization
	void Start () {
        EnterTipPanel();
    }

    public void EnterTipPanel()
    {
        OpenTipPanel();
        CloseDataPanel();
        CloseErrorTip();

        TipPanelCtrl tipCtrl = tipPanel.GetComponent<TipPanelCtrl>();
        tipCtrl.RefreshPanel();
    }

    void OpenTipPanel()
    {
        if (tipPanel == null)
            tipPanel = Instantiate(Resources.Load<GameObject>("tip_panel"), mainCanvas.transform);
        else
            tipPanel.SetActive(true);
    }

    void CloseTipPanel()
    {
        if (tipPanel == null)
            return;
        else
            tipPanel.SetActive(false);
    }

    public void EnterDataPanel(float pipeWide, int num)
    {
        OpenDataPanel();
        CloseTipPanel();
        CloseErrorTip();

        DataPanelCtrl dataCtrl = dataPanel.GetComponent<DataPanelCtrl>();
        dataCtrl.PipeWide = pipeWide;
        //MainManager.Instance.PipeDiameter=pipeWide;
        dataCtrl.RefreshPanel(num);

    }

    void OpenDataPanel()
    {
        if (dataPanel == null)
            dataPanel = Instantiate(Resources.Load<GameObject>("data_panel"), mainCanvas.transform);
        else
            dataPanel.SetActive(true);
    }

    void CloseDataPanel()
    {
        if (dataPanel == null)
            return;
        else
            dataPanel.SetActive(false);
    }

    public void ShowErrorTip(string errorInfo)
    {
        if (errorTipPanel == null)
            errorTipPanel = Instantiate(Resources.Load<GameObject>("error_tip_panel"), mainCanvas.transform);
        else
            errorTipPanel.SetActive(true);
        errorTipPanel.GetComponent<ErrorTipPanelCtrl>().RefreshPanel(errorInfo);
    }

    void CloseErrorTip()
    {
        if (errorTipPanel == null)
            return;
        else
            errorTipPanel.SetActive(false);
    }
}
