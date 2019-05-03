using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DataPanelCtrl : MonoBehaviour {
    [SerializeField]
    InputField diameterInput;
    [SerializeField]
    InputField waterExtractionInput;
    [SerializeField]
    InputField gasExtractionInput;
    [SerializeField]
    InputField oilPressureInput;
    [SerializeField]
    InputField casingPressureInput;
    [SerializeField]
    InputField pipeLengthInput;
    [SerializeField]
    Text swirlAngleText;
    [SerializeField]
    Text spiralLineHeightText;
    [SerializeField]
    Text spiralLineCountText;
    [SerializeField]
    Text pipeLineWidthText;
    [SerializeField]
    Text spiralLineWidthText;
    [SerializeField]
    Text splShapeText;
    [SerializeField]
    Text splDirectionText;
    [SerializeField]
    Text leadCountText;
    [SerializeField]
    Button sureButton;
    [SerializeField]
    Button backButton;

    [SerializeField]
    RawImage imageLine;
    [SerializeField]
    Text maxX;
    [SerializeField]
    Text maxY;
    [SerializeField]
    Text setLevel;

    private float pipeWide;

    public float PipeWide
    {
        get
        {
            return pipeWide;
        }

        set
        {
            pipeWide = value;
        }
    }

    public void RefreshPanel(int chooseCal)
    {
        MainManager.Instance.TableSelect = chooseCal;
        diameterInput.text = PipeWide.ToString();
        waterExtractionInput.text="";
        gasExtractionInput.text="";
        oilPressureInput.text="";
        casingPressureInput.text="";
        pipeLengthInput.text="";

        swirlAngleText.text = "";
        spiralLineHeightText.text = "";
        spiralLineCountText.text = "";
        pipeLineWidthText.text = "";
        spiralLineWidthText.text = "";
        splShapeText.text = "";
        splDirectionText.text = "";
        leadCountText.text = "";
        maxX.text = "有效作用长度：";
        maxY.text = "切向速度：";
        setLevel.text = "安装级数：";
    }
    // Use this for initialization
    void Start () 
    {
        sureButton.onClick.AddListener(SureBtnClick);
        backButton.onClick.AddListener(BackBtnClick);
    }

    void SureBtnClick()
    {
        bool parseSucces;
        MainManager.Instance.PipeDiameter = pipeWide;
        float waterExtraction = 0;
        parseSucces = float.TryParse(waterExtractionInput.text,out waterExtraction);
        if (parseSucces)
            MainManager.Instance.WaterExtraction = waterExtraction;
        else
        {
            Global.Instance.ShowErrorTip("产水量输入错误");
            return;
        }
        float gasExtraction = 0;
        parseSucces = float.TryParse(gasExtractionInput.text, out gasExtraction);
        if (parseSucces)
            MainManager.Instance.GasExtraction = gasExtraction;
        else
        {
            Global.Instance.ShowErrorTip("产气量输入错误");
            return;
        }
        float oilPressure = 0;
        parseSucces = float.TryParse(oilPressureInput.text, out oilPressure);
        if (parseSucces)
            MainManager.Instance.OilPressure = oilPressure;
        else
        {
            Global.Instance.ShowErrorTip("油压输入错误");
            return;
        }
        float casingPressure = 0;
        parseSucces = float.TryParse(casingPressureInput.text, out casingPressure);
        if (parseSucces)
            MainManager.Instance.CasingPressure = casingPressure;
        else
        {
            Global.Instance.ShowErrorTip("套压输入错误");
            return;
        }
        float pipeLength = 0;
        parseSucces = float.TryParse(pipeLengthInput.text, out pipeLength);
        if (parseSucces)
            MainManager.Instance.PipeLength = pipeLength;
        else
        {
            Global.Instance.ShowErrorTip("管长输入错误");
            return;
        }
        MainManager.Instance.ComputingAHL();
        RefreshResult(pipeLength);
    }

    void RefreshResult(float pipeLength)
    {
        swirlAngleText.text = MainManager.Instance.SwirlAngle.ToString();
        spiralLineHeightText.text = MainManager.Instance.SpiralLineHeight.ToString();
        spiralLineCountText.text = MainManager.Instance.SpiralLineCount.ToString();
        pipeLineWidthText.text = pipeWide.ToString();
        spiralLineWidthText.text = MainManager.Instance.SpiralLineWidth.ToString()+"mm";
        splShapeText.text = MainManager.Instance.SplShape.ToString();
        splDirectionText.text = MainManager.Instance.SplDirection.ToString();
        leadCountText.text = MainManager.Instance.LeadCount.ToString() + "个";
        //绘图
        imageLine.GetComponent<Painter>().OnDraw();
        maxX.text = "有效作用长度：" + MainManager.Instance.MaxXValue.ToString() + "m";
        maxY.text = "最大切向速度：" + MainManager.Instance.MaxYValue.ToString() + "m/s";
        if (MainManager.Instance.MaxXValue > 0f)
            setLevel.text = "安装级数：" + Mathf.Ceil(pipeLength / MainManager.Instance.MaxXValue);
        else
            setLevel.text = "安装级数：0";
    }

    void BackBtnClick()
    {
        Global.Instance.EnterTipPanel();
    }

}
