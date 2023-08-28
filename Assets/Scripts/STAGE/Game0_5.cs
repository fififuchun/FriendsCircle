using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game0_5 : MonoBehaviour
{
    public Toggle[] toggles = new Toggle[4];
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[4];
    public GameObject clearImage;

    void Start()
    {
        // Debug.Log(toggles[0].isOn);
        if (PlayerPrefs.GetInt("StageNum", 1) == 5 || StageManager.instance.isTutorial)
        {
            firstImage.SetActive(true);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++) if (toggles[i].isOn) texts[i].text = "友達の和";
            else texts[i].text = "友達の和じゃない";
    }

    public void PushSubmitButton()
    {
        if (toggles[0].isOn && !toggles[1].isOn && !toggles[2].isOn && toggles[3].isOn) clearImage.SetActive(true);
    }

    public GameObject firstImage;
    public GameObject secondImage;

    public GameObject[] explainImages = new GameObject[6];

    public GameObject[] maskImages = new GameObject[2];

    private int i = 1;

    public void PushFirstExplainButton()
    {
        firstImage.SetActive(false);
        secondImage.SetActive(true);

        maskImages[0].SetActive(true);
        explainImages[0].SetActive(true);
    }

    public void PushSecondExplainImage()
    {
        Debug.Log(i);
        if (i > 0 && i < 4)
        {
            maskImages[0].SetActive(true);
            maskImages[1].SetActive(false);
            explainImages[i - 1].SetActive(false);
            explainImages[i].SetActive(true);
            i++;
        }
        else if (i >= 4)
        {
            maskImages[0].SetActive(false);
            maskImages[1].SetActive(true);
            explainImages[i - 1].SetActive(false);
            if (i == 6)
            {
                secondImage.SetActive(false);
                return;
            }
            explainImages[i].SetActive(true);
            i++;
        }
    }
}
