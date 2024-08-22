using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
[Serializable]
public class Ball
{
    public int ID;

    private Light2D ballLight;

    public Vector3 position;

    public int size;

    //初始旋转方向，确定其移动方向
    public Quaternion direction;

    //灯光亮度
    public float lightIntensity;

    //灯光半径
    public float radius;

    /// <summary>
    /// 小球初始化
    /// </summary>
    public void BallInit(GameObject ball)
    {
        ballLight = ball.GetComponentInChildren<Light2D>();
        ball.name = size.ToString();
        ball.tag = "Ball";
        ball.transform.position = position;
        ball.transform.rotation = direction;
        ball.transform.localScale = new Vector3(1,1,1);
        ballLight.intensity = lightIntensity;
        ballLight.pointLightOuterRadius = radius;
    }
}

