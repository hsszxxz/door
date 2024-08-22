using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
public class BallManager : MonoSingleton<BallManager>
{
    [SerializeField]
    public Ball[] balls;
    public GameObject mainBall;
    private MainBall mainBallScript;
    private List<GameObject> ballGameObjects;
    private void Awake()
    {
        ballGameObjects = new List<GameObject>();
        mainBallScript = mainBall.GetComponent<MainBall>();
    }
    public void ResetAllBall()
    {
        if (ballGameObjects !=null)
        {
            foreach (GameObject gameObject in ballGameObjects)
            { Destroy(gameObject); }
            ballGameObjects.Clear();
        }
        GameObject ballObj = Resources.Load("Prefab/ball") as GameObject;
        foreach (Ball ball in balls)
        {
            GameObject ballObject =Instantiate(ballObj);
            ballGameObjects.Add(ballObject);
            ball.BallInit(ballObject);
        }
        mainBallScript.MainBallReset();
    }
    public void BallMove(Direction direction,float speed)
    {
        int size =mainBallScript.size;
        foreach(Ball ball in balls)
        {
            if(ball.size ==  size)
            {
                if (ballGameObjects[ball.ID]!=null)
                {
                    ballGameObjects[ball.ID].GetComponent<BallMoto>().Move(direction,speed);
                }
            }
        }
        mainBallScript.MainBallMove(speed,direction);
    }
}

