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

    //��ʼ��ת����ȷ�����ƶ�����
    public Quaternion direction;

    //�ƹ�����
    public float lightIntensity;

    //�ƹ�뾶
    public float radius;

    /// <summary>
    /// С���ʼ��
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

