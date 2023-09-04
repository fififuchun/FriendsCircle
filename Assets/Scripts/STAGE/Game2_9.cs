using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game2_9 : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void PushReturnToSelectButton()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void PushGoReviewButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.FuchunGames");
    }
}
