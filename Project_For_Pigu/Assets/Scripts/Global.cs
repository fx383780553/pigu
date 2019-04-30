using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
    private GameObject mainCanvas;
    private GameObject tipPanel;
    void Awake()
    {
        mainCanvas = GameObject.FindWithTag("MainCanvas");
    }
	// Use this for initialization
	void Start () {
        OpenTipPanel();
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

    public void EnterDataPanel(int num)
    {
        Debug.LogError(num);
        CloseTipPanel();
    }
}
