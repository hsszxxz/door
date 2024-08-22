using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DragThing
{
    wall=0,
    door=1,
    box=2,
    ball=3,
    empty=4,
    doorSingle =5
}
public class FollowMouse:MonoBehaviour
{
    [HideInInspector]
    public DragThing thing
    {
        get
        {
            return thingValue;
        }
        set
        {
            thingValue = value;
            transform.GetComponent<SpriteRenderer>().sprite = dragThingSprite[(int)value];
        }
    }
    private DragThing thingValue;
    public Sprite[] dragThingSprite;//0:Ç½£¬1£ºÃÅ£¬2£ºÏä×Ó£¬3£ºÇò£¬4£º¿Õ
    private void Start()
    {
        thing = DragThing.empty;
    }

    private void Update()
    {
        transform.position =new Vector3( Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
    }
}