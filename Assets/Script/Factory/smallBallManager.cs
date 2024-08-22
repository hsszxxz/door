using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class smallBallManager : MonoSingleton<BallManager>
{
    [HideInInspector]
    public List<Ball> balls;
    public GameObject mainBall;
    private MainBall mainBallScript;
    private List<GameObject> ballGameObjects;
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    private void Start()
    {
        balls = new List<Ball>();
        ballGameObjects = new List<GameObject>();
        mainBallScript = mainBall.GetComponent<MainBall>();
        ResetAllBall();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0.1)
        {
            BallMove(Direction.right, 1.5f);
        }
        else if (horizontal < -0.1)
        {
            BallMove(Direction.left, 1.5f);
        }
        if (vertical > 0.1)
        {
            BallMove(Direction.forward, 1.5f);
        }
        else if (vertical < -0.1)
        {
            BallMove(Direction.backward, 1.5f);
        }
    }
    public void AddNewBall(Ball ball,GameObject ballObj)
    {
        balls.Add(ball);
        ball.ID = balls.IndexOf(ball);
        ballGameObjects.Add(ballObj);
    }
    public void ResetAllBall()
    {
        if (ballGameObjects != null)
        {
            foreach (GameObject gameObject in ballGameObjects)
            { Destroy(gameObject); }
            ballGameObjects.Clear();
        }
        GameObject ballObj = Resources.Load("Prefab/ball") as GameObject;
        foreach (Ball ball in balls)
        {
            GameObject ballObject = Instantiate(ballObj);
            ballGameObjects.Add(ballObject);
            ball.BallInit(ballObject);
        }
        mainBallScript.MainBallReset();
    }
    public void BallMove(Direction direction, float speed)
    {
        int size = mainBallScript.size;
        foreach (Ball ball in balls)
        {
            if (ball.size == size)
            {
                if (ballGameObjects[ball.ID] != null)
                {
                    ballGameObjects[ball.ID].GetComponent<BallMoto>().Move(direction, speed);
                }
            }
        }
        mainBallScript.MainBallMove(speed, direction);
    }
}

