using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction
{
    forward,
    backward,
    left,
    right
}
public class BallMoto : MonoBehaviour
{
    public void Move(Direction direction,float speed)
    {
        Vector3 movement = Vector3.zero;
        switch (direction)
        {
            case Direction.forward:
                movement = new Vector3 (0,1,0);
                break;
            case Direction.backward:
                movement = new Vector3(0, -1, 0);
                break;
            case Direction.left:
                movement = -Vector3.right;
                break;
            case Direction.right:
                movement = Vector3.right;
                break;
        }
        movement = movement * speed*Time.deltaTime;
        transform.Translate(movement,Space.Self);
    }
}

