using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Painter : MonoBehaviour {

    // When added to an object, draws colored rays from the
    // transform position.


        public  void GenerateText()
    {
        Texture2D tmp2D = new Texture2D(300, 400);
        for(int i=0;i<tmp2D.width;i++)
        {
            for(int j=0;j<tmp2D.height;j++)
            {
                tmp2D.SetPixel(i, j, Color.black);
            }
        }
        tmp2D.Apply();

        Debug.Log("allPoints.Count"+ allPoints.Count);
       
        for (int i = 1; i < allPoints.Count; i++)
        {
            // int  xx=  (int)(allPoints[i].x * tmp2D.width);

            //int yy = (int)(allPoints[i].y * tmp2D.height);

            //tmp2D.SetPixel(xx,yy,Color.red);

            Vector2 tmpFront = allPoints[i - 1];
            Vector2 tmpBack = allPoints[i];

            //  两点之间 在插入 100 个像素点
            for (int j = 0; j < 100; j++)
            {
                int  xx = (int)  Mathf.Lerp(tmpFront.x * tmp2D.width , tmpBack.x* tmp2D.width, j / 100.0f);

                int yy = (int)Mathf.Lerp(tmpFront.y* tmp2D.height, tmpBack.y * tmp2D.height, j / 100.0f);

                tmp2D.SetPixel(xx, yy, Color.red);
                // 线条加粗
                for (int a = xx - 2; a < xx + 2; a++)
                {
                    for (int b = yy - 2; b < yy + 2; b++)
                    {
                        tmp2D.SetPixel(a, b, Color.red);
                    }
                }
            }


        }


        tmp2D.Apply();


        gameObject.GetComponent<Renderer>().material.SetTexture("_TwoTex",tmp2D);


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



    }


    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        CreateLineMaterial();
        // Apply the line material
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform  multify
        GL.MultMatrix(transform.localToWorldMatrix);

        // Draw lines
        GL.Begin(GL.LINES);

        // 将 透视投影变 正交投影
        GL.LoadOrtho();

        
        GL.Color(Color.red);
        //// One vertex at transform position
        //GL.Vertex3(0.2f, 0.2f, 0);
        //// Another vertex at edge of circle
        //GL.Vertex3(0.5f,0.5f,0 );


        for (int i = 1; i < allPoints.Count; i++)
        {
            Vector2 tmpFront = allPoints[i - 1];

            Vector2 tmpBack = allPoints[i];

            GL.Vertex3(tmpFront.x ,tmpFront.y ,0);

            GL.Vertex3(tmpBack.x, tmpBack.y,0);
        }

        //for (int i = 0; i < lineCount; ++i)
        //{
        //    float a = i / (float)lineCount;
        //    float angle = a * Mathf.PI * 2;
        //    // Vertex colors change from red to green
        //    GL.Color(new Color(a, 1 - a, 0, 0.8F));
        //    // One vertex at transform position
        //    GL.Vertex3(0, 0, 0);
        //    // Another vertex at edge of circle
        //    GL.Vertex3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);
        //}
        GL.End();
        GL.PopMatrix();
    }

    List<Vector2> allPoints = new List<Vector2>();
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            // 将 屏幕转视图
          Vector2  tmpPos=    Camera.main.ScreenToViewportPoint(Input.mousePosition);

            allPoints.Add(tmpPos);
        }

        if (Input.GetMouseButtonUp(0))
        {

            GenerateText();
            allPoints.Clear();
        }


    }
}
