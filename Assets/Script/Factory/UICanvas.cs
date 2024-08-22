using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UICanvas : UIWindow
{
    public Button[] buttons;//0：暂停，1：回到主菜单，2：继续游戏，3：退出，4：开关灯
    public Sprite[] lights;//0：开，1:关
    public GameObject lightObj;
    private bool light = false;
    private void Start()
    {
        buttons[0].onClick.AddListener(Stop);
        buttons[1].onClick.AddListener(BackMainMenu);
        buttons[2].onClick.AddListener(Continue);
        buttons[3].onClick.AddListener(Quit);
        buttons[4].onClick.AddListener(TurnLight);
    }
    private void TurnLight()
    {
        light = !light;
        buttons[4].gameObject.GetComponent<Image>().sprite = light ? lights[0] : lights[1];
        lightObj.SetActive(light);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Stop();
        }
    }
    private void Quit()
    {
        Application.Quit();
    }
    private void Continue()
    {
        Time.timeScale = 1.0f;
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        GetComponent<AudioSource>().Play();
    }
    private void BackMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
    }
    public void Stop()
    {
        Time.timeScale = 0f;
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
        GetComponent<AudioSource>().Stop();
    }

}