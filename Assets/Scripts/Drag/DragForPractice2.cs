using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragForPractice2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private GameObject playerObj;
    private Vector3 initPos;
    //修正されたドラッグ開始時の位置
    public Vector3 currentPos;
    //修正された現在位置
    private GameObject canvas;


    public void OnBeginDrag(PointerEventData data)
    {
        // playerObj = GameObject.Find(name);
        // Debug.Log(this.gameObject.name);
        initPos = playerObj.transform.position - canvas.transform.position;
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData data)
    {
        transform.position = data.position;
        // Debug.Log(playerObj.transform.position);
    }

    public void OnEndDrag(PointerEventData data)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);

        //ここからケーススタディ
        if (currentPos.y < 375 && currentPos.y > -525 && (currentPos.x > 150 && currentPos.x < 300))
        {
            playerObj.transform.position = new Vector3(225.0f, 150 * Mathf.FloorToInt((playerObj.transform.position.y - canvas.transform.position.y + 75) / 150)) + canvas.transform.position;
            playerObj.transform.SetParent(canvas.transform.Find("Answers"));
            if (initPos.y < 375 && initPos.y > -525 && (initPos.x > 150 && initPos.x < 300))
            {
                Game0_3.instance.answerGameObjects[Mathf.FloorToInt((initPos.y - 375) / -150)] = null;
                Game0_3.instance.answerGameObjects[Mathf.FloorToInt((currentPos.y - 375) / -150)] = this.gameObject;
                return;//bottomからbottomなら終了
            }

            //bottomからAnswerへ
            if (!(Game0_3.instance.answerGameObjects[Mathf.FloorToInt((currentPos.y - 375) / -150)] == null)) Destroy(Game0_3.instance.answerGameObjects[Mathf.FloorToInt((currentPos.y - 375) / -150)]);
            Game0_3.instance.answerGameObjects[Mathf.FloorToInt((currentPos.y - 375) / -150)] = playerObj;
            AppearPinsImage();
            // Debug.Log("1");
        }
        else if (currentPos.y < -550 && currentPos.y > -850)
        {
            //上から下へ
            if (initPos.y < 375 && initPos.y > -525 && (initPos.x > 150 && initPos.x < 300))
            {
                Game0_3.instance.answerGameObjects[Mathf.FloorToInt((initPos.y - 375) / -150)] = null;
                Destroy(this.gameObject);
            }
            //下から下
            else if (initPos.y < -550 && initPos.y > -850)
            {
                AppearPinsImage();
                Destroy(this.gameObject);
            }
            // Debug.Log("2");
        }
        else
        {
            playerObj.transform.position = initPos + canvas.transform.position;
            if (initPos.y < 375 && initPos.y > -525 && (initPos.x > 150 && initPos.x < 300)) return;
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 200);
        }
    }

    public void AppearPinsImage()
    {
        switch (playerObj.tag)
        {
            case "2":
                Instantiate(Game0_3.instance.emptyObj, Game0_3.instance.bottomObj.transform);
                break;
            case "3":
                Instantiate(Game0_3.instance.aObj, Game0_3.instance.bottomObj.transform);
                break;
            case "5":
                Instantiate(Game0_3.instance.bObj, Game0_3.instance.bottomObj.transform);
                break;
            case "13":
                Instantiate(Game0_3.instance.abObj, Game0_3.instance.bottomObj.transform);
                break;
        }
    }

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        playerObj = this.gameObject;
    }

    void Update()
    {
        if (playerObj == null) return;
        else currentPos = playerObj.transform.position - canvas.transform.position;
    }
}