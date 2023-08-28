using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game0_1 : MonoBehaviour
{
    public SetManager set;
    public GameObject[] gameObjects = new GameObject[5];
    public Vector3[] initGameObjects = new Vector3[5];
    public Image[] judgeImages = new Image[5];
    public GameObject gameClearImage;

    // public TextMeshProUGUI testText;

    public GameObject explainPanel;

    void Start()
    {
        for (int i = 0; i < 5; i++) initGameObjects[i] = gameObjects[i].transform.position;
        if (PlayerPrefs.GetInt("StageNum", 1) < 3 || StageManager.instance.isTutorial)
        {
            explainPanel.SetActive(true);
            return;
        }

    }

    void Update()
    {
        if (gameObjects[0].transform.position.y == judgeImages[0].transform.position.y && gameObjects[1].transform.position.y == judgeImages[1].transform.position.y && gameObjects[2].transform.position.y == judgeImages[2].transform.position.y && gameObjects[3].transform.position.y == judgeImages[3].transform.position.y && gameObjects[4].transform.position.y == judgeImages[4].transform.position.y)
        {
            gameClearImage.SetActive(true);
        }

        for (int i = 0; i < 5; i++)
        {
            if (gameObjects[i].transform.position.y == judgeImages[i].transform.position.y) judgeImages[i].enabled = true;
            else judgeImages[i].enabled = false;

            for (int j = 0; j < 5; j++) if (gameObjects[i].transform.position == gameObjects[j].transform.position && i != j)
                {
                    gameObjects[j].transform.position = initGameObjects[j];
                }
        }
        // testText.text = gameObjects[0].transform.position.y.ToString() + gameObjects[1].transform.position.y.ToString() + gameObjects[2].transform.position.y.ToString() + gameObjects[3].transform.position.y.ToString() + gameObjects[4].transform.position.y.ToString();
    }

    public void PushCloseButtonForExplain()
    {
        explainPanel.SetActive(false);
    }

    //説明用
    public GameObject[] explainImages = new GameObject[4];

    public void PushExplainButton()
    {
        for (int i = 0; i < 4; i++)
        {
            if (explainImages[i].activeSelf)
            {
                explainImages[i].SetActive(false);

                if (i == 3) explainPanel.SetActive(false);
                else explainImages[i + 1].SetActive(true);
                return;
            }
        }
    }
}
