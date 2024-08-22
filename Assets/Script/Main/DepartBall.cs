using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class DepartBall : MonoBehaviour
{
    public GameObject mainBall;
    private MainBall mainBallScript;
    public Transform[] BallLocation;
    public GameObject buttonTishi;
    public GameObject CaoZuoMenu;
    private void Start()
    {
        mainBallScript = mainBall.GetComponent<MainBall>();
    }
    public int departNum;
    private void Update()
    {
        if (Vector2.Distance(mainBall.transform.position,transform.position)<0.8f)
        {
            if(buttonTishi!= null )
            {
                buttonTishi.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if ((mainBallScript.size/departNum) >=1)
                {
                    mainBallScript.size/=departNum;
                    for (int i =0;i<departNum-1;i++)
                    {
                        GameObject ballObj = Instantiate(Resources.Load("Prefab/ball1") as GameObject);
                        ballObj.transform.SetParent(BallLocation[i]);
                        ballObj.transform.localPosition = Vector3.zero;
                        ballObj.tag = "Ball2";
                        ballObj.GetComponentInChildren<Light2D>().intensity = mainBallScript.ballLight.intensity;
                        ballObj.GetComponentInChildren<Light2D>().pointLightOuterRadius = 1.3f;
                    }
                    mainBall.GetComponent<SignLightControl>().count += departNum;
                    this.enabled = false;
                }
                else
                {
                    CaoZuoMenu.GetComponent<CaoZuoUIWindow>().Stop();
                }
            }
        }
    }
}
