using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CaoZuoUIWindow:UIWindow
{
    public Button[] buttons;//0：暂停，1：重新开始，2：继续游戏，3：退出
    private GameObject script;
    private BallManager ballManager;
    private void Start()
    {
        script = GameObject.Find("Script");
        ballManager = script.GetComponent<BallManager>();
        buttons[0].onClick.AddListener(Stop);
        buttons[1].onClick.AddListener(Restart);
        buttons[2].onClick.AddListener(Continue);
        buttons[3].onClick.AddListener(Quit);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
    private void Restart()
    {
        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        Time.timeScale = 1.0f;
        ballManager.ResetAllBall();
        GetComponent<AudioSource>().Play();
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

