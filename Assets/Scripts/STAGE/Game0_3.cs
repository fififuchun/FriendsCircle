using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game0_3 : MonoBehaviour
{
    public GameObject bottomObj;
    public GameObject gameClear;

    public static Game0_3 instance;
    void Awake() { instance = this; }
    //自身のインスタンス化

    public GameObject[] answerGameObjects = new GameObject[6];
    public GameObject emptyObj;
    public GameObject aObj;
    public GameObject bObj;
    public GameObject abObj;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "STAGE1_3" && (PlayerPrefs.GetInt("StageNum", 1) == 3 || StageManager.instance.isTutorial)) explainImage1.SetActive(true);
        if (SceneManager.GetActiveScene().name == "STAGE1_4" && (PlayerPrefs.GetInt("StageNum", 1) == 4 || StageManager.instance.isTutorial)) explainImage2.SetActive(true);

        emptyObj = Resources.Load<GameObject>("Empty");
        aObj = Resources.Load<GameObject>("a");
        bObj = Resources.Load<GameObject>("b");
        abObj = Resources.Load<GameObject>("ab");

        Instantiate(emptyObj, bottomObj.transform);
        Instantiate(aObj, bottomObj.transform);
        Instantiate(bObj, bottomObj.transform);
        Instantiate(abObj, bottomObj.transform);
    }

    void Update()
    {
        for (int i = 0; i < 6; i++) if (answerGameObjects[i] == null) return;

        if (SceneManager.GetActiveScene().name == "STAGE1_3" && answerGameObjects[0].tag == "3" && answerGameObjects[1].tag == "13" && answerGameObjects[2].tag == "13" && answerGameObjects[3].tag == "2" && answerGameObjects[4].tag == "2" && answerGameObjects[5].tag == "3")
        {
            if (PlayerPrefs.GetInt("StageNum", 1) == 3) afterExplainImage.SetActive(true);
            else gameClear.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "STAGE1_4" && answerGameObjects[0].tag == "3" && answerGameObjects[1].tag == "5" && answerGameObjects[2].tag == "13" && answerGameObjects[3].tag == "2" && answerGameObjects[4].tag == "2" && answerGameObjects[5].tag == "2")
        {
            if (PlayerPrefs.GetInt("StageNum", 1) == 4) afterExplainImage.SetActive(true);
            else gameClear.SetActive(true);
        }
        else gameClear.SetActive(false);
    }

    public GameObject explainImage1;
    public GameObject explainImage2;

    public void PushExplain1Button()
    {
        explainImage1.SetActive(false);
        explainImage2.SetActive(true);
        explainImages[0].SetActive(true);
    }

    public GameObject[] explainImages = new GameObject[2];
    private int explainIndex = 0;
    public void PushExplain2Button()
    {
        if (explainIndex == 0)
        {
            explainImages[0].SetActive(false);
            explainImages[1].SetActive(true);
            explainIndex++;
        }
        else if (explainIndex == 1)
        {
            explainImage2.SetActive(false);
        }
    }

    public GameObject afterExplainImage;
    public GameObject[] afterExplainImages = new GameObject[3];
    public GameObject afterExplainButton;
    private int afterExplainIndex = 0;
    public void PushAfterExplainButton()
    {
        afterExplainImages[afterExplainIndex].SetActive(false);
        if (afterExplainIndex == 2)
        {
            afterExplainImage.SetActive(false);
            gameClear.SetActive(true);
            afterExplainButton.SetActive(false);
            return;
        }
        afterExplainImages[afterExplainIndex + 1].SetActive(true);
        afterExplainIndex++;
    }
}