using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputSize : MonoBehaviour
{
    public Button[] buttons;//0:ÉÏ£¬1£ºÏÂ
    [HideInInspector]
    public int sizeCount =1;
    public Text sizeNum;
    private void Start()
    {
        buttons[0].onClick.AddListener(UpSize);
        buttons[1].onClick.AddListener(DownSize);
    }
    private void UpSize()
    {
        sizeCount += 1;
        sizeNum.text = sizeCount.ToString();
    }
    private void DownSize()
    {
        sizeCount -= 1;
        sizeNum.text = sizeCount.ToString();
    }
}

