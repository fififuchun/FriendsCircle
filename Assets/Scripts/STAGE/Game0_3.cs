using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game0_3 : MonoBehaviour
{
    public GameObject bottomObj;
    public GameObject gameClear;

    public static Game0_3 instance;
    void Awake() { instance = this; }
    //自身のインスタンス化

    public GameObject[] answerGameObjects = new GameObject[6];
    public GameObject emptyObj;
    public GameObject aObj;
    public GameObject bObj;
    public GameObject abObj;

    void Start()
    {
        emptyObj = Resources.Load<GameObject>("Empty");
        aObj = Resources.Load<GameObject>("a");
        bObj = Resources.Load<GameObject>("b");
        abObj = Resources.Load<GameObject>("ab");

        Instantiate(emptyObj, bottomObj.transform);
        Instantiate(aObj, bottomObj.transform);
        Instantiate(bObj, bottomObj.transform);
        Instantiate(abObj, bottomObj.transform);
    }

    void Update()
    {
        for (int i = 0; i < 6; i++) if (answerGameObjects[i] == null) return;
        
        if (SceneManager.GetActiveScene().name == "STAGE1_3" && answerGameObjects[0].tag == "3" && answerGameObjects[1].tag == "13" && answerGameObjects[2].tag == "13" && answerGameObjects[3].tag == "2" && answerGameObjects[4].tag == "2" && answerGameObjects[5].tag == "3")
        {
            gameClear.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "STAGE1_4" && answerGameObjects[0].tag == "3" && answerGameObjects[1].tag == "5" && answerGameObjects[2].tag == "13" && answerGameObjects[3].tag == "2" && answerGameObjects[4].tag == "2" && answerGameObjects[5].tag == "2")
        {
            gameClear.SetActive(true);
        }
        else gameClear.SetActive(false);
    }
}