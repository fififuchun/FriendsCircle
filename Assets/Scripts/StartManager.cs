using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public TextMeshProUGUI explainText;

    public Image titleImage;

    void Start()
    {
        // explainText.text = "??";
        titleImage.GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.x, GameObject.Find("Canvas").GetComponent<RectTransform>().sizeDelta.y);
    }

    void Update()
    {
        explainText.color = new Color(1.0f, 1.0f, 1.0f, 0.6f + (Mathf.Sin(3 * Time.time) / 3));
    }

    public void PushGoNextButon()
    {
        SceneManager.LoadScene("SelectScene");
    }
}
