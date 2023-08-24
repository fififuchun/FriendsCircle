using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Game1_8 : MonoBehaviour
{
    
    public GameController onlySet;
    public GameObject gameOver;
    public GameObject gameClear;
    
    void Start()
    {

    }
    
    void Update()
    {
        if (!onlySet.isInsideSet && !(PlayerManager.instance.transform.parent.name == "BottomGameImage")) gameOver.SetActive(true);

        if (onlySet.setFamilyList.Contains("e") && !gameOver.activeSelf) gameClear.SetActive(true);
        else gameClear.SetActive(false);
    }
}
