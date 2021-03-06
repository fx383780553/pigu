﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Painter : MonoBehaviour
{
    
    Button button1;
    List<Vector2> allPoints = new List<Vector2>();


    public void GenerateText(int num=1)
    {
        Texture2D tmp2D = new Texture2D(400, 300);
        for (int i = 0; i < tmp2D.width; i++)
        {
            for (int j = 0; j < tmp2D.height; j++)
            {
                tmp2D.SetPixel(i, j, Color.white);
            }
        }
        tmp2D.Apply();

        Debug.Log("allPoints.Count" + allPoints.Count);

        for (int i = 1; i < allPoints.Count; i++)
        {
           
            if(num==1)
            tmp2D.SetPixel((int)allPoints[i].x, (int)allPoints[i].y, Color.black);
            else
                tmp2D.SetPixel((int)allPoints[i].x, (int)(allPoints[i].y*Mathf.Cos(0.3927f)), Color.black);
            // 线条加粗
            //     for (int a = xx - 2; a < xx + 2; a++)
            //     {
            //         for (int b = yy - 2; b < yy + 2; b++)
            //         {
            //             tmp2D.SetPixel(a, b, Color.red);
            //         }
            //     }
        }
        tmp2D.Apply();
        //gameObject.GetComponent<Renderer>().material.mainTexture = tmp2D;
        gameObject.GetComponent<RawImage>().texture = tmp2D;
    }


    private void Start()
    {
        //Texture2D tmp2D = new Texture2D(300, 400);
        //for (int i = 0; i < 200; i++)
        //{
        //    for (int j = 0; j < 40; j++)
        //    {
        //        // 遍历图片上 每一个像素点
        //        tmp2D.SetPixel(i, j, Color.red);
        //    }
        //}
        //tmp2D.Apply();
        //GetComponent<Renderer>().material.mainTexture = tmp2D;

        //button1 = transform.GetComponent<Button>();
        //button1.onClick.AddListener(OnDraw);
    }


    //1参数表示左侧的图
    public void OnDraw(int num=1)
    {
        MainManager.Instance.ComputingAllPos();
        allPoints.Clear();
        for (int i = 0; i < MainManager.Instance.posList.Count; i++)
        {
            Vector2 vec2 = new Vector2();
            vec2.x = MainManager.Instance.posList[i].x*0.8f;
            vec2.y = MainManager.Instance.posList[i].y * 450;
            if (vec2.y < 300 && vec2.x < 400)
            {
                allPoints.Add(vec2);
            }
        }
        if (num == 1)
            GenerateText();
        else
            GenerateText(num);
    }

    public void OnDraw(List<PointPos> posList)
    {
        allPoints.Clear();
        for (int i = 0; i < posList.Count - 1; i++)
        {
            Vector2 pos1 = new Vector2();
            Vector2 pos2 = new Vector2();
            pos1.x = posList[i].x;
            pos1.y = posList[i].y;
            pos2.x = posList[i + 1].x;
            pos2.y = posList[i + 1].y;

            float k = (pos2.y - pos1.y) / (pos2.x - pos1.x);
            float b = pos1.y - k * pos1.x;

            float x = pos1.x + 0.1f;
            do
            {
                float y = k * x + b;
                Vector2 pos = new Vector2();
                pos.x = x;
                pos.y = y;
                if (pos.y < 400 && pos.x < 400)
                {
                    allPoints.Add(pos);
                }
                x += 0.1f;
            }
            while (x < pos2.x);
        }
        GenerateText(allPoints);
    }

    public void GenerateText(List<Vector2> posList)
    {
        Texture2D tmp2D = new Texture2D(400, 400);
        for (int i = 0; i < tmp2D.width; i++)
        {
            for (int j = 0; j < tmp2D.height; j++)
            {
                tmp2D.SetPixel(i, j, Color.white);
            }
        }
        tmp2D.Apply();
        Debug.Log("posList.Count:" + posList.Count);

        for (int i = 1; i < posList.Count; i++)
        {
            tmp2D.SetPixel((int)posList[i].x, (int)posList[i].y, Color.black);
        }
        tmp2D.Apply();
        gameObject.GetComponent<RawImage>().texture = tmp2D;
    }



    // static Material lineMaterial;
    // static void CreateLineMaterial()
    // {
    //     if (!lineMaterial)
    //     {
    //         // Unity has a built-in shader that is useful for drawing
    //         // simple colored things.
    //         Shader shader = Shader.Find("Hidden/Internal-Colored");
    //         lineMaterial = new Material(shader);
    //         lineMaterial.hideFlags = HideFlags.HideAndDontSave;
    //         // Turn on alpha blending
    //         lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
    //         lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
    //         // Turn backface culling off
    //         lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
    //         // Turn off depth writes
    //         lineMaterial.SetInt("_ZWrite", 0);
    //     }
    // }

    // Will be called after all regular rendering is done
    // public void OnRenderObject()
    // {
    //     CreateLineMaterial();
    //     // Apply the line material
    //     lineMaterial.SetPass(0);

    //     GL.PushMatrix();
    //     // Set transformation matrix for drawing to
    //     // match our transform  multify
    //     GL.MultMatrix(transform.localToWorldMatrix);

    //     // Draw lines
    //     GL.Begin(GL.LINES);

    //     // 将 透视投影变 正交投影
    //     GL.LoadOrtho();


    //     GL.Color(Color.red);
    //     //// One vertex at transform position
    //     //GL.Vertex3(0.2f, 0.2f, 0);
    //     //// Another vertex at edge of circle
    //     //GL.Vertex3(0.5f,0.5f,0 );


    //     for (int i = 1; i < allPoints.Count; i++)
    //     {
    //         Vector2 tmpFront = allPoints[i - 1];

    //         Vector2 tmpBack = allPoints[i];

    //         GL.Vertex3(tmpFront.x ,tmpFront.y ,0);

    //         GL.Vertex3(tmpBack.x, tmpBack.y,0);
    //     }

    //     //for (int i = 0; i < lineCount; ++i)
    //     //{
    //     //    float a = i / (float)lineCount;
    //     //    float angle = a * Mathf.PI * 2;
    //     //    // Vertex colors change from red to green
    //     //    GL.Color(new Color(a, 1 - a, 0, 0.8F));
    //     //    // One vertex at transform position
    //     //    GL.Vertex3(0, 0, 0);
    //     //    // Another vertex at edge of circle
    //     //    GL.Vertex3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
    //     //}
    //     GL.End();
    //     GL.PopMatrix();
    // }

    // private void Update()
    // {
    //     if(Input.GetMouseButton(0))
    //     {
    //         // 将 屏幕转视图
    //       Vector2  tmpPos=    Camera.main.ScreenToViewportPoint(Input.mousePosition);

    //         allPoints.Add(tmpPos);
    //     }

    //     if (Input.GetMouseButtonUp(0))
    //     {

    //         GenerateText();
    //         allPoints.Clear();
    //     }


    // }
}
