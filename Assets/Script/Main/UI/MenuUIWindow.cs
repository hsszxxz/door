using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuUIWindow:UIWindow
{
    public Image[] doorLogo;//从前往后依次画
    public Button[] buttons;//0:开始，1：制作人名单，2：退出,3:创意工坊
    public Image peoplePage;
    public Quaternion target;
    public GameObject CaoZuoMenu;
    public GameObject Introduction;
    public Sprite[] introductionSprite;
    private int index
    {
        get
        {
            return indexValue;
        }
        set
        {
            indexValue = value;
            if (value >= introductionSprite.Length)
            {
                Introduction.SetActive(false);
                StartCoroutine(ShowLogo(0));
            }
            else
            {
                Introduction.GetComponent<Image>().sprite = introductionSprite[value];
            }
        }
    }
    private int indexValue = 0;

    protected override void Awake()
    {
        base.Awake();
        Time.timeScale = 0;
        buttons[0].onClick.AddListener(StartButton);
        buttons[1].onClick.AddListener(PeopleButton);
        buttons[2].onClick.AddListener(QuitButton);
        buttons[3].onClick.AddListener(FactoryButton);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            peoplePage.gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            peoplePage.gameObject.SetActive(false);
            index = Mathf.Min( index+ 1,introductionSprite.Length);
        }
    }
    private void FactoryButton()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return null;
        SceneManager.LoadScene("Factory");
    }
    IEnumerator ShowLogo(int index)
    {
        while (Mathf.Abs(doorLogo[index].fillAmount -1)>0.01f)
        {
            yield return null;
            doorLogo[index].fillAmount = Mathf.Lerp(doorLogo[index].fillAmount,1f,0.02f);
        }
        if (index < doorLogo.Length-1)
        {
            StartCoroutine(ShowLogo(index+1));
        }
        else
        {
            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(true);
            }
        }
    }
    private void StartButton()
    {
        StartCoroutine(OpenDoor());
    }
    IEnumerator OpenDoor()
    {
        while (Mathf.Abs(doorLogo[2].gameObject.transform.localPosition.y ) > 0.1f)
        {
            yield return null;
            doorLogo[2].gameObject.transform.localPosition = Vector3.Lerp(doorLogo[2].gameObject.transform.localPosition, new Vector3(doorLogo[2].gameObject.transform.localPosition.x, 0, 0), 0.02f);
        }
        while(Mathf.Abs(transform.rotation.y -target.y )>0.05f)
        {
            yield return null;
            transform.rotation = Quaternion.Lerp(transform.rotation, target, 0.005f);
        }
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        CaoZuoMenu.SetActive(true);
    }
    private void PeopleButton()
    {
        peoplePage.gameObject.SetActive(true);
    }
    private void QuitButton()
    {
        Application.Quit();
    }
}
