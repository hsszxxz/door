using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonControl : MonoBehaviour
{
    public Button[] buttons;//0:墙，1：门，2：盒子，3：球，4：加，5：减，6：取消
    public GameObject ChooseThing;
    private FollowMouse followMouse;
    private string[] prefabName = { "Prefab/Wall", "Prefab/door", "Prefab/box", "Prefab/ball","","Prefab/doorSingle" };
    public InputSize inputSize;
    private enum ChooseCondition
    {
        plus,
        minus,
        cancel
    }
    private ChooseCondition choose = ChooseCondition.cancel;
    private Map map;
    private Quaternion thingRotation;
    private int zAngle;
    private smallBallManager ballManager;
    private void Start()
    {
        followMouse = ChooseThing.GetComponent<FollowMouse>();
        ballManager = GetComponent<smallBallManager>();
        map = GetComponent<Map>();
        buttons[0].onClick.AddListener(WallThing);
        buttons[1].onClick.AddListener(DoorThing);
        buttons[2].onClick.AddListener(BoxThing);
        buttons[3].onClick.AddListener(BallThing);
        buttons[4].onClick.AddListener(PlusThing);
        buttons[5].onClick.AddListener(MinusThing);
        buttons[6].onClick.AddListener(CancelThing);
    }
    private void WallThing()
    {
        if (choose == ChooseCondition.plus)
            StartCoroutine(ProduceDragThing(DragThing.wall));
    }
    private void DoorThing()
    {
        if (choose == ChooseCondition.plus)
            StartCoroutine(ProduceDragThing(DragThing.door));
    }
    private void BoxThing()
    {
        if (choose == ChooseCondition.plus)
            StartCoroutine(ProduceDragThing(DragThing.box));
    }
    private void BallThing()
    {
        if (choose == ChooseCondition.plus)
            StartCoroutine(ProduceDragThing(DragThing.ball));
    }
    private void PlusThing()
    {
        map.ShowAndShutLine(true);
        choose = ChooseCondition.plus;
    }
    private void MinusThing()
    {
        choose = ChooseCondition.minus;
        followMouse.thing = DragThing.empty;
    }
    private void CancelThing()
    {
        choose = ChooseCondition.cancel;
        map.ShowAndShutLine(false);
        followMouse.thing = DragThing.empty;
    }
    private void Update()
    {
        switch (choose)
        {
            case ChooseCondition.plus:
                if (Input.GetMouseButtonDown(1)&& followMouse.thing != DragThing.empty)
                {
                    zAngle = (zAngle + 90) % 360;
                    thingRotation = Quaternion.Euler(0, 0, zAngle);
                    ChooseThing.transform.rotation = thingRotation;
                }
                if(Input.GetMouseButtonDown(0)&& followMouse.thing != DragThing.empty)
                {
                    GameObject addtion = loadGameObject(thingRotation);
                   if(! map.AddThing(ChooseThing.transform.position, addtion))
                        Destroy(addtion);
                    if (followMouse.thing == DragThing.ball)
                    {
                        Ball ball = new Ball();
                        ball.direction = thingRotation;
                        ball.position = addtion.transform.position;
                        ball.size = inputSize.sizeCount;
                        ball.radius = Mathf.Sqrt(inputSize.sizeCount);
                        addtion.name =inputSize.sizeCount.ToString();
                        addtion.tag = "Ball";
                        ballManager.AddNewBall(ball, addtion);
                    }
                    thingRotation = Quaternion.identity;
                    ChooseThing.transform.rotation = thingRotation;
                }
                if (followMouse.thing == DragThing.door ||followMouse.thing == DragThing.doorSingle)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        followMouse.thing = followMouse.thing == DragThing.door ? DragThing.doorSingle:DragThing.door;
                    }
                }
                break;
            case ChooseCondition.minus:
                if(Input.GetMouseButtonDown(0))
                {
                    map.RemoveThing(ChooseThing.transform.position);
                }
                break;
        }
    }

    IEnumerator  ProduceDragThing(DragThing drag)
    {
        yield return null;
        followMouse.thing = drag;
    }

    private GameObject loadGameObject(Quaternion quaternion)
    {
        GameObject go = Instantiate(Resources.Load(prefabName[(int)followMouse.thing])as GameObject);
        go.transform.rotation = quaternion;
        return go;
    }
}
