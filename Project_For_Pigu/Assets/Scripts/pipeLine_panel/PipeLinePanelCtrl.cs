using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeLinePanelCtrl : MonoBehaviour {
    [SerializeField]
    Transform vectorFather;
    [SerializeField]
    Button addBtn;
    [SerializeField]
    InputField HorizPipeLengthInput;
    [SerializeField]
    InputField MakePipeLengthInput;
    [SerializeField]
    InputField JingXieJiaoInput;
    [SerializeField]
    InputField VerticalPipeLenghtInput;
    [SerializeField]
    InputField TotalPipeLengthInput;
    [SerializeField]
    Button pipeLengthCalButton;
    [SerializeField]
    Button drawButton;
    [SerializeField]
    Button nextButton;
    [SerializeField]
    Painter Image;
    List<VectorData> vectorDatas;
    float totalPipeLength;

    // Use this for initialization
    void Start () {
        vectorDatas = new List<VectorData>();
        addBtn.onClick.AddListener(AddBtnClick);
        pipeLengthCalButton.onClick.AddListener(PipeLengthCalButtonClick);
        nextButton.onClick.AddListener(NextButtonClick);
        drawButton.onClick.AddListener(DrawButtonClick);
    }

    void AddBtnClick()
    {
        vectorDatas.Add(Instantiate(Resources.Load<GameObject>("vector"), vectorFather).GetComponent<VectorData>());
    }

    void PipeLengthCalButtonClick()
    {
        bool parseSucces;
        float HorizPipeLength = 0;
        parseSucces = float.TryParse(HorizPipeLengthInput.text, out HorizPipeLength);
        if (!parseSucces)
        {
            Global.Instance.ShowErrorTip("水平管道长度输入错误");
            return;
        }

        float MakePipeLength = 0;
        parseSucces = float.TryParse(MakePipeLengthInput.text, out MakePipeLength);
        if (!parseSucces)
        {
            Global.Instance.ShowErrorTip("造斜管段长度输入错误");
            return;
        }

        /*float JingXieJiao = 0;
        parseSucces = float.TryParse(JingXieJiaoInput.text, out JingXieJiao);
        if (!parseSucces)
        {
            Global.Instance.ShowErrorTip("井斜角输入错误");
            return;
        }*/

        float VerticalPipeLenght = 0;
        parseSucces = float.TryParse(VerticalPipeLenghtInput.text, out VerticalPipeLenght);
        if (!parseSucces)
        {
            Global.Instance.ShowErrorTip("垂直管段长度输入错误");
            return;
        }
        totalPipeLength = HorizPipeLength + MakePipeLength + VerticalPipeLenght;
        TotalPipeLengthInput.text = totalPipeLength.ToString();
        Global.Instance.gbData.PipeLength = totalPipeLength;
        Global.Instance.gbData.HorizLength = HorizPipeLength;
        Global.Instance.gbData.MakeXieLength = MakePipeLength;
    }

    void NextButtonClick()
    {
        if (totalPipeLength <= 0)
        {
            Global.Instance.ShowErrorTip("请先计算管长");
            return;
        }
        Global.Instance.EnterDataPanel();
    }

    void DrawButtonClick()
    {
        List<PointPos> posList = new List<PointPos>();
        for (int i = 0; i < vectorDatas.Count; i++)
        {
            posList.Add(vectorDatas[i].getValue());
        }
        Image.OnDraw(posList);
    }

    public void RefreshPanel()
    {
        HorizPipeLengthInput.text = "";
        MakePipeLengthInput.text = "";
        JingXieJiaoInput.text = "";
        VerticalPipeLenghtInput.text = "";
        TotalPipeLengthInput.text = "";
        if (vectorDatas != null)
        {
            for (int i = 0; i < vectorDatas.Count; i++)
            {
                VectorData vecData = vectorDatas[i];
                DestroyImmediate(vecData.gameObject);
            }
            vectorDatas.Clear();
        }
    }

}
