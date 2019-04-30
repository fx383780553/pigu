using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
    private GameObject mainCanvas;
    private GameObject tipPanel;
    private GameObject dataPanel;
    void Awake()
    {
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

        TipPanelCtrl tipCtrl = tipPanel.GetComponent<TipPanelCtrl>();
        tipCtrl.RefreshPanel();
    }

    void OpenTipPanel()
    {
        if (tipPanel == null)
        {
            tipPanel = Instantiate(Resources.Load<GameObject>("tip_panel"), mainCanvas.transform);
            tipPanel.GetComponent<TipPanelCtrl>().Global = this;
        }
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

        DataPanelCtrl dataCtrl = dataPanel.GetComponent<DataPanelCtrl>();
        dataCtrl.PipeWide = pipeWide;
        dataCtrl.RefreshPanel();

    }

    void OpenDataPanel()
    {
        if (dataPanel == null)
            dataPanel = Instantiate(Resources.Load<GameObject>("dataPanel"), mainCanvas.transform);
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
}
