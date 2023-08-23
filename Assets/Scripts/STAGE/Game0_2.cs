using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game0_2 : MonoBehaviour
{
    public SetManager set;
    public GameObject[] gameObjects = new GameObject[5];
    public Vector3[] initGameObjects = new Vector3[5];
    public Image[] judgeImages = new Image[5];
    public GameObject gameClearImage;

    void Start()
    {
        for (int i = 0; i < 5; i++) initGameObjects[i] = gameObjects[i].transform.position;
    }

    void Update()
    {
        if (gameObjects[0].transform.position.y == 1610 && gameObjects[1].transform.position.y == 1360 && gameObjects[2].transform.position.y == 1110 && gameObjects[3].transform.position.y == 860 && gameObjects[4].transform.position.y == 610)
        {
            gameClearImage.SetActive(true);
        }

        for (int i = 0; i < 5; i++)
        {
            if (gameObjects[i].transform.position.y == 1610 - 250 * i) judgeImages[i].enabled = true;
            else judgeImages[i].enabled = false;

            for (int j = 0; j < 5; j++) if (gameObjects[i].transform.position == gameObjects[j].transform.position && i != j)
                {
                    gameObjects[j].transform.position = initGameObjects[j];
                }
        }
    }
}
