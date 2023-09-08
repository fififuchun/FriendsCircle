using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2_8 : MonoBehaviour
{
    public GameController onlySet;
    public GameObject gameOver;
    public GameObject gameClear;


    void Update()
    {
        // if (!onlySet.isInsideSet && !(PlayerManager.instance.transform.parent.name == "BottomGameImage")) gameOver.SetActive(true);

        if (onlySet.setFamilyList.Contains("Empty") && onlySet.setFamilyList.Contains("c") && !gameOver.activeSelf) gameClear.SetActive(true);
        else gameClear.SetActive(false);
    }
}
