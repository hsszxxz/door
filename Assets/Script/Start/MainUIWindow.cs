using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainUIWindow:UIWindow
{
    public float flashSpeed;
    public float flashTime;
    public override void ShutAndOpen(bool flag)
    {
        StartCoroutine(ShutOrOpen(flag));
    }
    IEnumerator ShutOrOpen(bool flag)
    {
        yield return new WaitForSeconds(0.5f);
        float tartget = flag ? 1 : 0;
        while(Mathf.Abs(canvasGroup.alpha-tartget)>0.01)
        {
            yield return null;
            canvasGroup.alpha =Mathf.Lerp(canvasGroup.alpha,tartget,flashSpeed) ;
        }
        canvasGroup.interactable = flag;
        canvasGroup.blocksRaycasts = flag;
        if (flag)
        {
            StartCoroutine(CloseUI());
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }
    IEnumerator CloseUI()
    {
        yield return new WaitForSeconds(flashTime);
        ShutAndOpen(false);
    }
}