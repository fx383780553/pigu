using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager
{
    private static MainManager instance;
    private MainManager() { }
    public static MainManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new MainManager();
            }
            return instance;
        }
    }

    private float _pipeDiameter;
    private float _waterExtraction;
    private float _gasExtraction;
    private float _oilPressure;
    private float _casingPressure;
    private float _pipeLength;
    private float _swirlAngle;
    private float _spiralLineHeight;
    private float _spiralLineCount;
    private float _spiralLineWidth;
    private string _splShape = "长方形";
    private string _splDirection = "正向";
    private int _leadCount = 4;
    private float _GasWaterProp ;
    private float _Speed;

    /// <summary>
    /// 管径
    /// </summary>
    public float PipeDiameter
    {
        get
        {
            return _pipeDiameter;
        }
        set
        {
            _pipeDiameter = value;
        }
    }
    /// <summary>
    /// 产水量
    /// </summary>
    public float WaterExtraction
    {
        get
        {
            return _waterExtraction;
        }
        set
        {
            _waterExtraction = value;
        }
    }
    /// <summary>
    /// 产气量
    /// </summary>
    public float GasExtraction
    {
        get
        {
            return _gasExtraction;
        }
        set
        {
            _gasExtraction = value;
        }
    }
    /// <summary>
    /// 油压
    /// </summary>
    public float OilPressure
    {
        get
        {
            return _oilPressure;
        }
        set
        {
            _oilPressure = value;
        }
    }
    /// <summary>
    /// 套压  
    /// </summary>
    public float CasingPressure
    {
        get
        {
            return _casingPressure;
        }
        set
        {
            _casingPressure = value;
        }
    }
    /// <summary>
    /// 管长
    /// </summary>
    public float PipeLength
    {
        get
        {
            return _pipeLength;
        }
        set
        {
            _pipeLength = value;
        }
    }
    /// <summary>
    /// 旋流角 °
    /// </summary>
    public float SwirlAngle
    {
        get
        {
            return _swirlAngle;
        }
        set
        {
            _swirlAngle = value;
        }
    }
    /// <summary>
    /// 旋线高度 mm
    /// </summary
    public float SpiralLineHeight
    {
        get
        {
            return _spiralLineHeight;
        }
        set
        {
            _spiralLineHeight = value;
        }
    }
    /// <summary>
    /// 旋线条数
    /// </summary>
    public float SpiralLineCount
    {
        get
        {
            return _spiralLineCount;
        }
        set
        {
            _spiralLineCount = value;
        }
    }
    /// <summary>
    /// 旋线宽度
    /// </summary>
    public float SpiralLineWidth
    {
        get
        {
            return _spiralLineWidth;
        }
        set
        {
            _spiralLineWidth = value;
        }
    }
    /// <summary>
    /// 旋线截面形状
    /// </summary>
    public string SplShape
    {
        get
        {
            return _splShape;
        }
        set
        {
            _splShape = value;
        }
    }
    /// <summary>
    /// 旋向
    /// </summary>
    public string SplDirection
    {
        get
        {
            return _splDirection;
        }
        set
        {
            _splDirection = value;
        }
    }
    /// <summary>
    /// 导程个数
    /// </summary>
    public int LeadCount
    {
        get
        {
            return _leadCount;
        }
        set
        {
            _leadCount = value;
        }
    }
    /// <summary>
    /// 汽水比
    /// </summary>
    public float GasWaterProp 
    {
        get
        {
            return _GasWaterProp ;
        }
        set
        {
            _GasWaterProp  = value;
        }
    }
    /// <summary>
    /// 流速
    /// </summary>
    public float Speed
    {
        get
        {
            return _Speed;
        }
        set
        {
            _Speed = value;
        }
    }

    //打开哪个参数表
    public int TableSelect=1;
    //所有的位置
    public List<PointPos> posList;

    /// <summary>
    /// 计算旋转角，旋线高度 旋线条数 汽水比 速度
    /// </summary>
    public void ComputingAHL()
    {
        //汽水比
        GasWaterProp  = WaterExtraction / GasExtraction;
        //速度
        Speed = GasExtraction / (Mathf.PI * PipeDiameter * PipeDiameter / 4);
        //选用哪张表
        if (TableSelect == 1)
        {
            if (GasWaterProp  <= 0.1)
            {
                Debug.Log("不适用");
            }
            else if (GasWaterProp  <= 0.5)
            {
                if (Speed <= 8)
                {
                    Debug.Log("不适用");
                }
                else if (Speed <= 12)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 1;
                }
                else if (Speed <= 16)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 15;
                    SpiralLineCount = 1;
                }
                else if (Speed <= 20)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 10;
                    SpiralLineCount = 1;
                }
                else if (Speed < 24)
                {
                    SwirlAngle = 42.5f;
                    SpiralLineHeight = 15;
                    SpiralLineCount = 1;
                }
                else
                {
                    SwirlAngle = 45;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 1;
                }
            }
            else if (GasWaterProp  <= 1)
            {
                if (Speed <= 8)
                {
                    Debug.Log("不适用");
                }
                else if (Speed <= 12)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 1;
                }
                else if (Speed <= 16)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 15;
                    SpiralLineCount = 1;
                }
                else if (Speed <= 20)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 10;
                    SpiralLineCount = 1;
                }
                else if (Speed < 24)
                {
                    SwirlAngle = 42.5f;
                    SpiralLineHeight = 15;
                    SpiralLineCount = 1;
                }
                else
                {
                    SwirlAngle = 50;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 1;
                }
            }
            else if (GasWaterProp  <= 2)
            {
                if (Speed <= 8)
                {
                    Debug.Log("不适用");
                }
                else if (Speed <= 12)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 1;
                }
                else if (Speed <= 16)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 15;
                    SpiralLineCount = 1;
                }
                else if (Speed <= 20)
                {
                    SwirlAngle = 42.5f;
                    SpiralLineHeight = 10;
                    SpiralLineCount = 2;
                }
                else if (Speed < 24)
                {
                    SwirlAngle = 42.5f;
                    SpiralLineHeight = 15;
                    SpiralLineCount = 1;
                }
                else
                {
                    SwirlAngle = 57.5f;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 2;
                }
            }
            else
            {
                if (Speed <= 8)
                {
                    Debug.Log("不适用");
                }
                else if (Speed <= 12)
                {
                    SwirlAngle = 42.5f;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 2;
                }
                else if (Speed <= 16)
                {
                    SwirlAngle = 47.5f;
                    SpiralLineHeight = 17.5f;
                    SpiralLineCount = 2;
                }
                else if (Speed <= 20)
                {
                    SwirlAngle = 42.5f;
                    SpiralLineHeight = 15;
                    SpiralLineCount = 3;
                }
                else if (Speed < 24)
                {
                    SwirlAngle = 52.5f;
                    SpiralLineHeight = 17.5f;
                    SpiralLineCount = 2;
                }
                else
                {
                    SwirlAngle = 57.5f;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 2;
                }
            }
        }
        else if (TableSelect == 2)
        {
            if (GasWaterProp  <= 0.1)
            {
                Debug.Log("不适用");
            }
            else if (GasWaterProp  <= 0.5)
            {
                if (Speed <= 8)
                {
                    Debug.Log("不适用");
                }
                else if (Speed <= 12)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 2;
                }
                else if (Speed <= 16)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 2;
                }
                else if (Speed <= 20)
                {
                    SwirlAngle = 40;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 1;
                }
                else if (Speed < 24)
                {
                    SwirlAngle = 45f;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 1;
                }
                else
                {
                    SwirlAngle = 55;
                    SpiralLineHeight = 40;
                    SpiralLineCount = 1;
                }
            }
            else if (GasWaterProp  <= 1)
            {
                if (Speed <= 8)
                {
                    Debug.Log("不适用");
                }
                else if (Speed <= 12)
                {
                    SwirlAngle = 42.5f;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 3;
                }
                else if (Speed <= 16)
                {
                    SwirlAngle = 50;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 3;
                }
                else if (Speed <= 20)
                {
                    SwirlAngle = 52.5f;
                    SpiralLineHeight = 20;
                    SpiralLineCount = 2;
                }
                else if (Speed < 24)
                {
                    SwirlAngle = 57.5f;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 2;
                }
                else
                {
                    SwirlAngle = 60;
                    SpiralLineHeight = 40;
                    SpiralLineCount = 1;
                }
            }
            else if (GasWaterProp  <= 2)
            {
                if (Speed <= 8)
                {
                    Debug.Log("不适用");
                }
                else if (Speed <= 12)
                {
                    SwirlAngle = 45;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 3;
                }
                else if (Speed <= 16)
                {
                    SwirlAngle = 50;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 3;
                }
                else if (Speed <= 20)
                {
                    SwirlAngle = 52.5f;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 3;
                }
                else if (Speed < 24)
                {
                    SwirlAngle = 57.5f;
                    SpiralLineHeight = 30;
                    SpiralLineCount = 2;
                }
                else
                {
                    SwirlAngle = 60f;
                    SpiralLineHeight = 40;
                    SpiralLineCount = 1;
                }
            }
            else
            {
                if (Speed <= 8)
                {
                    Debug.Log("不适用");
                }
                else if (Speed <= 12)
                {
                    SwirlAngle = 50f;
                    SpiralLineHeight = 40;
                    SpiralLineCount = 3;
                }
                else if (Speed <= 16)
                {
                    SwirlAngle = 55f;
                    SpiralLineHeight = 40f;
                    SpiralLineCount = 3;
                }
                else if (Speed <= 20)
                {
                    SwirlAngle = 60f;
                    SpiralLineHeight = 40;
                    SpiralLineCount = 3;
                }
                else if (Speed < 24)
                {
                    SwirlAngle = 60f;
                    SpiralLineHeight = 40f;
                    SpiralLineCount = 3;
                }
                else
                {
                    SwirlAngle = 60f;
                    SpiralLineHeight = 40;
                    SpiralLineCount = 1;
                }
            }
        }
    }
    /// <summary>
    /// 计算并存储所有的点
    /// </summary>
    public List<PointPos> ComputingAllPos()
    {
        posList = new List<PointPos>();
        ComputingAHL();
        float x,v, d,r, md,nd,re,k, w, w1, w2, w3, w4, jiao, a1, a2, a3, a4;
        w = 1;
        jiao = SwirlAngle * Mathf.PI / 180;
        v = Speed;
        d = PipeDiameter;
        k = GasWaterProp ;
        r = d / 2;
        md = 998.2f * k + (1 - k) * 0.6679f;
        nd = 0.001003f * k + (1 - k) * 1.1087f * Mathf.Pow(10,-5);
        re = md * v * d / nd;
        a1 = 3.8317f * r / 2 - 0.25f * Mathf.Pow((3.8317f * r / 2), 3) + Mathf.Pow((3.8317f * r / 2), 5) / 12 - Mathf.Pow((3.8317f * r / 2), 7) / 288;
        a2 = 7.0156f * r / 2 - 0.25f * Mathf.Pow((7.0156f * r / 2), 3) + Mathf.Pow((7.0156f * r / 2), 5) / 12 - Mathf.Pow((7.0156f * r / 2), 7) / 288;
        a3 = 10.1735f * r / 2 - 0.25f * Mathf.Pow((10.1735f * r / 2), 3) + Mathf.Pow((10.1735f * r / 2), 5) / 12 - Mathf.Pow((10.1735f * r / 2), 7) / 288;
        a4 = 13.3237f * r / 2 - 0.25f * Mathf.Pow((13.3237f * r / 2), 3) + Mathf.Pow((13.3237f * r / 2), 5) / 12 - Mathf.Pow((13.3237f * r / 2), 7) / 288;
        x = 0.0f;

        do
        {
            x += 0.1f;
            w1 = 7.78f * Mathf.Tan(jiao) / 2 / Mathf.PI * a1 *Mathf.Exp(-(16.675f) * (1 + (4.15f * Mathf.Pow(10 , (-3)) * Mathf.Pow(re , 0.86f))) / re * x);
            w2 = 5.26f * Mathf.Tan(jiao) / 2 / Mathf.PI * a2 * Mathf.Exp(-(55.714f) * (1 + (4.15f * Mathf.Pow(10, (-3)) * Mathf.Pow(re, 0.86f))) / re * x);
            w3 = 3.93f * Mathf.Tan(jiao) / 2 / Mathf.PI * a3 * Mathf.Exp(-(117.86f) * (1 + (4.15f * Mathf.Pow(10, (-3)) * Mathf.Pow(re, 0.86f))) / re * x);
            w4 = 3.16f * Mathf.Tan(jiao) / 2 / Mathf.PI * a4 * Mathf.Exp(-(203.73f) * (1 + (4.15f * Mathf.Pow(10, (-3)) * Mathf.Pow(re, 0.86f))) / re * x);
            w = w1 + w2 + w3 + w4;
            PointPos pos = new PointPos(x, w);
            posList.Add(pos);
        }
        while (w>0.0035);

        return posList;
    }
}

public class PointPos
{
    public PointPos(float x,float y)
    {
        this.x = x;
        this.y = y;
    }
    //轴向距离
    public float x;
    //切向速度
    public float y;
}
