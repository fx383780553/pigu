using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DataPanelCtrl : MonoBehaviour {
   InputField diameterInput;
   InputField waterExtractionInput;
   InputField gasExtractionInput;
   InputField oilPressureInput;
   InputField casingPressureInput;
   InputField pipeLengthInput;
   Text swirlAngleText;
   Text spiralLineHeightText;
   Text spiralLineCountText;
   Text pipeLineWidthText;
   Text spiralLineWidthText;
   Text splShapeText;
   Text splDirectionText;
   Text leadCountText;

    public void RefreshPanel()
    {
        //diameterInput.text=MainManager.Instance.PipeDiameter.ToString();
        //waterExtractionInput.text="";
        //gasExtractionInput.text="";
        //oilPressureInput.text="";
        //casingPressureInput.text="";
        //pipeLengthInput.text="";

        //swirlAngleText.text="";
        //spiralLineHeightText.text="";
        //spiralLineCountText.text="";
        //pipeLineWidthText.text="";
        //spiralLineWidthText.text="";
        //splShapeText.text="";
        //splDirectionText.text="";
        //leadCountText.text="";
    }
    // Use this for initialization
    void Start () 
    {
		diameterInput=transform.Find("DiameterInput").GetComponent<InputField>();
		waterExtractionInput=transform.Find("WaterExtractionInput").GetComponent<InputField>();
		gasExtractionInput=transform.Find("GasExtractionInput").GetComponent<InputField>();
		oilPressureInput=transform.Find("OilPressureInput").GetComponent<InputField>();
		casingPressureInput=transform.Find("CasingPressureInput").GetComponent<InputField>();
		pipeLengthInput=transform.Find("PipeLengthInput").GetComponent<InputField>();

        swirlAngleText=transform.Find("SwirlAngleText").GetComponent<Text>();
        spiralLineHeightText=transform.Find("SpiralLineHeightText").GetComponent<Text>();
        spiralLineCountText=transform.Find("SpiralLineCountText").GetComponent<Text>();
        pipeLineWidthText=transform.Find("PipeLineWidthText").GetComponent<Text>();
        spiralLineWidthText=transform.Find("SpiralLineWidthText").GetComponent<Text>();
        splShapeText=transform.Find("SplShapeText").GetComponent<Text>();
        splDirectionText=transform.Find("SplDirectionText").GetComponent<Text>();
        leadCountText=transform.Find("LeadCountText").GetComponent<Text>();

        diameterInput.onValueChanged.AddListener((str)=>{
            float x=(float)(Convert.ToDouble(str));
            MainManager.Instance.PipeDiameter=x;
            });
	}
	
}
