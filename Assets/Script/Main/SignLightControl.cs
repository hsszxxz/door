using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class SignLightControl : MonoBehaviour
{
    public Light2D[] signLights;
    [HideInInspector]
    public int count = 0;
    public Transform location;
    private void Update()
    {
        if (Vector2.Distance(location.position,transform.position)<0.4f)
        {
            if (count >=19)
            {
                foreach (Light2D light in signLights)
                {
                    light.color = Color.green;
                }
            }
            else
            {
                foreach (Light2D light in signLights)
                {
                    light.color = Color.red;
                }
            }
        }
    }
}

