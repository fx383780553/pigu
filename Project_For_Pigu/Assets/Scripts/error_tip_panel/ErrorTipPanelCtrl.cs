using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorTipPanelCtrl : MonoBehaviour {
    [SerializeField]
    private Text text;
    [SerializeField]
    private Button btn;
	// Use this for initialization
	void Start () {
        btn.onClick.AddListener(BtnClick);
	}

    void BtnClick()
    {
        this.gameObject.SetActive(false);
    }

    public void RefreshPanel(string msg)
    {
        this.transform.SetAsLastSibling();
        text.text = msg;
    }
	
}
