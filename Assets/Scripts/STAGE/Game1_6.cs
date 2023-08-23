using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1_6 : MonoBehaviour
{
    public GameController onlySet;
    public GameObject gameOver;
    public GameObject gameClear;


    void Update()
    {
        if (!onlySet.isInsideSet && !(PlayerManager.instance.transform.parent.name == "BottomGameImage")) gameOver.SetActive(true);

        if (onlySet.setFamilyList.Contains("Empty") && onlySet.setFamilyList.Contains("d") && !gameOver.activeSelf) gameClear.SetActive(true);
        else gameClear.SetActive(false);
    }
}
