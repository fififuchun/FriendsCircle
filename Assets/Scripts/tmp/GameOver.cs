using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private GameObject gameOver;

    void Start()
    {
        gameOver = GameObject.Find("GameOver");
        gameOver.SetActive(true);
    }

    void Update()
    {
        if (gameOver.activeSelf)
        {
            gameObject.SetActive(false);
            Debug.Log("remove");
        }
    }
}
