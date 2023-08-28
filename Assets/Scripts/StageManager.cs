using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageManager : MonoBehaviour
{
    public void Push1_1Button()
    {
        SceneManager.LoadScene("STAGE2_1");
    }

    public void Push1_2Button()
    {
        SceneManager.LoadScene("STAGE2_2");
    }

    public void Push1_3Button()
    {
        SceneManager.LoadScene("STAGE2_3");
    }

    public void Push1_4Button()
    {
        SceneManager.LoadScene("STAGE2_4");
    }

    public void Push1_5Button()
    {
        SceneManager.LoadScene("STAGE2_5");
    }

    public void Push1_6Button()
    {
        SceneManager.LoadScene("STAGE2_6");
    }

    public void Push1_7Button()
    {
        SceneManager.LoadScene("STAGE2_7");
    }

    public void Push1_8Button()
    {
        SceneManager.LoadScene("STAGE2_8");
    }

    public void Push1_9Button()
    {
        SceneManager.LoadScene("STAGE2_9");
    }

    public void Push0_1Button()
    {
        SceneManager.LoadScene("STAGE1_1");
    }

    public void Push0_2Button()
    {
        SceneManager.LoadScene("STAGE1_2");
    }

    public void Push0_3Button()
    {
        SceneManager.LoadScene("STAGE1_3");
    }

    public void Push0_4Button()
    {
        SceneManager.LoadScene("STAGE1_4");
    }

    public void Push0_5Button()
    {
        SceneManager.LoadScene("STAGE1_5");
    }

    // public void PushTestButton()
    // {
    //     SceneManager.LoadScene("STAGE1_2 1");
    // }

    public void PushResetButton()
    {
        PlayerPrefs.SetInt("StageNum", 1);
        Start();
    }

    public static StageManager instance;
    void Awake() { instance = this; }

    public bool isTutorial;
    public GameObject tutorialLockImage;
    private Camera camera;

    public void PushTutorialButton()
    {
        if (!isTutorial)
        {
            isTutorial = true;
            camera.backgroundColor = new Color32(255, 100, 0, 255);
            for (int i = 0; i < stageButtons.Length; i++) if (i > Min(stageNum - 2, 7)) stageButtons[i].gameObject.SetActive(false);
            return;
        }
        else if (isTutorial)
        {
            Start();
            camera.backgroundColor = new Color32(0, 0, 64, 255);
            isTutorial = false;
            return;
        }
    }

    public int Min(int a, int b)
    {
        if (a < b) return a;
        else return b;
    }

    public Button[] stageButtons = new Button[14];
    public Image[] lockImages = new Image[14];
    public Button tutorialButton;
    public Image titleImage;
    private int stageNum;
    //初期状態は1です、0_1クリアで2になります、以下同様

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        titleImage.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y);
        for (int i = 0; i < stageButtons.Length; i++)
        {
            //たぶんリセットに必要
            stageButtons[i].enabled = false;
            lockImages[i].enabled = true;
            if (i < stageButtons.Length - 1) stageButtons[i + 1].gameObject.SetActive(false);
        }

        stageNum = PlayerPrefs.GetInt("StageNum", 1);
        if (stageNum > 1)
        {
            content.transform.localPosition = new Vector3(-250 * (stageNum - 2), content.transform.localPosition.y);
            tutorialButton.enabled = true;
            tutorialLockImage.SetActive(false);
        }
        for (int i = 0; i < stageNum; i++)
        {
            stageButtons[i].enabled = true;
            lockImages[i].enabled = false;
            if (i < stageButtons.Length - 1) stageButtons[i + 1].gameObject.SetActive(true);
        }
    }

    public GameObject content;
    public TextMeshProUGUI clearNumber;
    void Update()
    {
        content.transform.localPosition = new Vector3(content.transform.localPosition.x, 300);
        clearNumber.text = (stageNum - 1).ToString();

        for (int i = 0; i < stageButtons.Length; i++)
        {
            if (Mathf.Abs(stageButtons[i].gameObject.transform.position.x - 540) < 250) stageButtons[i].gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);
            else stageButtons[i].gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}