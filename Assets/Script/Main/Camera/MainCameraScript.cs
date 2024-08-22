using System.Collections;
using UnityEngine;
public class MainCameraScript : MonoBehaviour
{
    public Transform mainBall;
    private Vector3 targetPosition;
    private Coroutine coroutine = null;
    private Vector3 mainBallPos;
    private void Update()
    {
        mainBallPos = mainBall.position;
        if (coroutine == null)
        {
            float x = transform.position.x, y = transform.position.y;
            if (mainBallPos.x - x < -3.84f)
            {
                x = mainBallPos.x + 1.92f * Random.value;
            }
            else if (mainBallPos.x - x > 3.84f)
            {
                x = mainBallPos.x - 1.92f * Random.value;
            }
            if (mainBallPos.y - y < -2.16f)
            {
                y = mainBallPos.y + 1.08f * Random.value;
            }
            else if (mainBallPos.y - y> 2.16f)
            {
                y = mainBallPos.y - 1.08f * Random.value;
            }
            if (!(x == transform.position.x && y == transform.position.y))
            {
                targetPosition = new Vector3(x, y, 0);
                coroutine = StartCoroutine(CameraMove(targetPosition));
            }
        }
    }
    IEnumerator CameraMove(Vector3 target)
    {
        while (Vector3.Distance(transform.position,target) >0.1f)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, target, 0.01f);
        }
        coroutine = null;
    }
}
