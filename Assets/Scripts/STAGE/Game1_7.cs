using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game1_7 : MonoBehaviour
{
    public GameController firstSet;
    public GameController secondSet;
    // public SetManager set;
    public GameObject gameOver;
    public GameObject gameClear;
    // private bool isGameOver;

    void Start()
    {

    }

    void Update()
    {
        // if (firstSet.isInsideSet) PlayerManager.instance.gameObject.transform.SetParent(firstSet.parentSet.transform);
        // else if (secondSet.isInsideSet) PlayerManager.instance.gameObject.transform.SetParent(secondSet.parentSet.transform);
        // else if (PlayerManager.instance.transform.parent.name == "BottomGameImage")
        // {
        //     isGameOver = false;
        //     // PlayerManager.instance.gameObject.transform.SetParent(set.bottomGameImage.transform);
        //     Debug.Log("a");
        // }
        // else if (isGameOver) gameOver.SetActive(true);
        // else isGameOver = true;

        if (!firstSet.isInsideSet && !secondSet.isInsideSet && !(PlayerManager.instance.transform.parent.name == "BottomGameImage")) gameOver.SetActive(true);

        if (secondSet.setFamilyList.Contains("a") && secondSet.setFamilyList.Contains("b") && !gameOver.activeSelf) gameClear.SetActive(true);
        else if (firstSet.setFamilyList.Contains("a") && firstSet.setFamilyList.Contains("b") && !gameOver.activeSelf) gameClear.SetActive(true);
        else gameClear.SetActive(false);
    }
}
