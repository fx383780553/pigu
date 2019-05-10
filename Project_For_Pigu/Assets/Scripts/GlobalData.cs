using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData  {
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

    public int CalType
    {
        get
        {
            return calType;
        }

        set
        {
            calType = value;
        }
    }

    public float PipeLength
    {
        get
        {
            return pipeLength;
        }

        set
        {
            pipeLength = value;
        }
    }

    public float HorizLength
    {
        get
        {
            return horizLength;
        }

        set
        {
            horizLength = value;
        }
    }

    public float MakeXieLength
    {
        get
        {
            return makeXieLength;
        }

        set
        {
            makeXieLength = value;
        }
    }

    private int calType;

    private float pipeLength;

    private float horizLength;

    private float makeXieLength;
}
