using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BallManager))]
public class MainSceneLogic : MonoBehaviour
{
    BallManager ballManager;
    private void Start()
    {
        ballManager = GetComponent<BallManager>();
        ballManager.ResetAllBall();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal >0.1)
        {
            ballManager.BallMove(Direction.right, 1.5f);
        }
        else if (horizontal < -0.1)
        {
            ballManager.BallMove(Direction.left, 1.5f);
        }
        if (vertical > 0.1)
        {
            ballManager.BallMove(Direction.forward, 1.5f);
        }
        else if (vertical < -0.1)
        {
            ballManager.BallMove(Direction.backward, 1.5f);
        }
    }
}
