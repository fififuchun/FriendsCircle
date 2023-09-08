using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1_5 : MonoBehaviour
{
    public GameController firstSet;
    public GameController secondSet;
    public GameObject gameOver;
    public GameObject gameClear;

    private bool isGameOver;

    void Update()
    {
        // if (firstSet.isInsideSet) PlayerManager.instance.gameObject.transform.SetParent(firstSet.parentSet.transform);
        // else if (secondSet.isInsideSet) PlayerManager.instance.gameObject.transform.SetParent(secondSet.parentSet.transform);
        // else gameOver.SetActive(true);いらない

        // if (!firstSet.isInsideSet && !secondSet.isInsideSet && !(PlayerManager.instance.transform.parent.name == "BottomGameImage"))
        // {
        //     gameOver.SetActive(true);
        //     Debug.Log("だめ");
        // }
        // else gameOver.SetActive(false);

        if (firstSet.setFamilyList.Contains("a") && firstSet.setFamilyList.Contains("ac") && firstSet.set.IsTopsp(firstSet.setNumber)) gameClear.SetActive(true);
        else if (secondSet.setFamilyList.Contains("a") && secondSet.setFamilyList.Contains("ac") && secondSet.set.IsTopsp(secondSet.setNumber)) gameClear.SetActive(true);
        else gameClear.SetActive(false);
    }
}
