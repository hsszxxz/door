using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class EpilogueControl : MonoBehaviour
{
    private SignLightControl signScript;
    public Transform location;
    public GameObject floor;
    public GameObject wall;
    public GameObject eventSystem;
    public GameObject epilogue;
    public Sprite[] epilogueSprites;
    public GameObject[] buttons;
    private void Start()
    {
        signScript = GetComponent<SignLightControl>();
    }
    private void Update()
    {
        if (Vector2.Distance(location.position, transform.position) < 0.4f)
        {
            if (signScript.count >= 19)
            {
                epilogue.SetActive(true);
                foreach (GameObject go in buttons)
                {
                    go.SetActive(false);
                }
                floor.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
                wall.GetComponent<TilemapCollider2D>().enabled = false;
                wall.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
                eventSystem.SetActive(false);
                StartCoroutine(ShowEpilogue(0));
                enabled = false;
            }
        }
    }
    IEnumerator ShowEpilogue(int index)
    {
        epilogue.GetComponent<Image>().sprite = epilogueSprites[index];
        epilogue.GetComponent<Image>().SetNativeSize();
        yield return new WaitForSeconds(6);
        if(index==epilogueSprites.Length-1)
        {
            Application.Quit();
        }
        else
        {
            StartCoroutine(ShowEpilogue(index + 1));
        }
    }
}
