using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
    private GameObject mainCanvas;
    private GameObject tipPanel;
    private GameObject dataPanel;
    private GameObject errorTipPanel;
    private GameObject pipeLinePanel;
    public GlobalData gbData;
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
        gbData = new GlobalData();
    }
	// Use this for initialization
	void Start () {
        EnterTipPanel();
    }

    public void EnterTipPanel()
    {
        CloseAllPanel();
        OpenTipPanel();

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

    public void EnterPipeLinePanel()
    {
        CloseAllPanel();
        OpenPipeLinePanel();
    }

    void OpenPipeLinePanel()
    {
        if (pipeLinePanel == null)
            pipeLinePanel = Instantiate(Resources.Load<GameObject>("pipeLine_panel"), mainCanvas.transform);
        else
            pipeLinePanel.SetActive(true);
    }

    void ClosePipeLinePanel()
    {
        if (pipeLinePanel == null)
            return;
        else
            pipeLinePanel.SetActive(false);
    }


    public void EnterDataPanel()
    {
        CloseAllPanel();
        OpenDataPanel();

        DataPanelCtrl dataCtrl = dataPanel.GetComponent<DataPanelCtrl>();
        dataCtrl.PipeWide = gbData.PipeWide;
        dataCtrl.PipeLength = gbData.PipeLength;
        dataCtrl.RefreshPanel(gbData.CalType);

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

    void CloseAllPanel()
    {
        CloseDataPanel();
        CloseTipPanel();
        CloseErrorTip();
        ClosePipeLinePanel();
    }
}
