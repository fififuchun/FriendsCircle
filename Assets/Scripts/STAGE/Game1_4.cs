using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1_4 : MonoBehaviour
{
    public GameController firstSet;
    public GameController secondSet;
    public GameObject gameOver;
    public GameObject gameClear;

    void Update()
    {
        if (firstSet.isInsideSet) PlayerManager.instance.gameObject.transform.SetParent(firstSet.parentSet.transform);
        else if (secondSet.isInsideSet) PlayerManager.instance.gameObject.transform.SetParent(secondSet.parentSet.transform);
        else gameOver.SetActive(true);

        if (secondSet.setFamilyList.Contains("Empty") && secondSet.setFamilyList.Contains("ac")&& !gameOver.activeSelf) gameClear.SetActive(true);
        else gameClear.SetActive(false);
    }
}