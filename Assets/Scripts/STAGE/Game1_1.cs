using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1_1 : MonoBehaviour
{
    public GameController onlySet;
    public GameObject gameOver;
    public GameObject gameClear;

    void Start()
    {
        onlySet.isInsideSet = true;
        if (PlayerPrefs.GetInt("StageNum", 1) == 4)
        {
            explains.SetActive(true);
            explainObject[0].SetActive(true);
            explainImages[0].SetActive(true);
            // Debug.Log("a");
        }
    }

    void Update()
    {
        if (onlySet.isInsideSet) PlayerManager.instance.gameObject.transform.SetParent(onlySet.parentSet.transform);
        else gameOver.SetActive(true);

        if (onlySet.setFamilyList.Contains("a") && onlySet.setFamilyList.Contains("b")) gameClear.SetActive(true);
        else gameClear.SetActive(false);
    }

    public GameObject explains;
    public GameObject[] explainObject = new GameObject[3];
    public GameObject[] explainImages = new GameObject[5];

    private int i = 1;

    public void PushExplainButton()
    {
        // if (i == 0)
        // {
        //     explainObject[0].SetActive(true);
        //     explainImages[0].SetActive(true);
        // }
        if (i == 1)
        {
            explainObject[0].SetActive(false);
            explainImages[0].SetActive(false);
            explainObject[1].SetActive(true);
            explainImages[1].SetActive(true);
        }
        else if (i == 2)
        {
            explainImages[1].SetActive(false);
            explainImages[2].SetActive(true);
        }
        else if (i == 3)
        {
            explainObject[1].SetActive(false);
            explainImages[2].SetActive(false);
            explainObject[2].SetActive(true);
            explainImages[3].SetActive(true);
        }
        else if (i == 4)
        {
            explainImages[3].SetActive(false);
            explainImages[4].SetActive(true);
        }
        else
        {
            explainImages[4].SetActive(false);
            explains.SetActive(false);
            return;
        }
        i++;
    }
}