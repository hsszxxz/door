using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
public class MainBall : MonoBehaviour
{
    public Light2D ballLight;
    private Vector3 primPosition;
    private Quaternion primDirection;
    public Text sizeNum;

    public Camera mainCamera;

    public int sizeValue=1;
    public int size 
    { 
        get 
        {
            return sizeValue;
        } 
        set
        {
            sizeValue = value;
            ballLight.intensity = primLightIntensity*(1+ (float)Mathf.Sqrt(value) / 5);
            ballLight.pointLightOuterRadius = primRadius * (1 + (float)Mathf.Sqrt(value) / 30);
            mainCamera.orthographicSize = primOrthographicSize*(1 + (float)Mathf.Sqrt(value) / 50);
            sizeNum.text = value.ToString();
        }
    }
    private int primSize = 1;

    //µ∆π‚¡¡∂»
    public float lightIntensity;
    private float primLightIntensity = 2;

    //µ∆π‚∞Îæ∂
    public float radius;
    private float primRadius = 2;

    private float primOrthographicSize = 5;
    private void Start()
    {
        ballLight = GetComponentInChildren<Light2D>();
        primPosition = transform.position;
        primDirection = transform.rotation;
    }
    public void MainBallReset()
    {
        transform.position = primPosition;
        transform.rotation = primDirection;
        transform.localScale = new Vector3(1, 1, 1) *primSize / 2;
        ballLight.intensity = primLightIntensity;
        ballLight.pointLightOuterRadius = primRadius;
        size=1;
    }
    public void MainBallMove(float speed,Direction direction)
    {
        float horizontal = 0;
        float vertical = 0;
        switch (direction)
        {
            case Direction.right:
                horizontal = 1; break;
            case Direction.left: 
                horizontal = -1;break;
            case Direction.forward:
                vertical = 1; break;
            case Direction.backward:
                vertical = -1; break;
        }
        Vector3 movement = new Vector3(horizontal,vertical,0)*speed*Time.deltaTime;
        transform.Translate(movement);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            size += int.Parse(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }
}

