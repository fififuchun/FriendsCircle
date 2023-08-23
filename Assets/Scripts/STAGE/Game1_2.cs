using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game1_2 : MonoBehaviour
{
    public GameController onlySet;
    public GameObject gameOver;
    public GameObject gameClear;

    void Start()
    {
        // onlySet.isInsideSet = false;
    }

    void Update()
    {
        // if (onlySet.isInsideSet && PlayerManager.instance.endDragJudge) PlayerManager.instance.gameObject.transform.SetParent(onlySet.parentSet.transform);
        // else if (PlayerManager.instance.endDragJudge) gameOver.SetActive(true);

        if (!onlySet.isInsideSet && onlySet.setFamilyList.Contains(PlayerManager.instance.gameObject.name)) gameOver.SetActive(true);

        if (onlySet.setFamilyList.Contains("a") && onlySet.setFamilyList.Contains("ab")) gameClear.SetActive(true);
        else gameClear.SetActive(false);
    }
}