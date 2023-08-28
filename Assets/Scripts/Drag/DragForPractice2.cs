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
        initPos = playerObj.transform.position - canvas.transform.position;
        // Debug.Log(this.gameObject.name);
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

        if (currentPos.y < 375 && currentPos.y > -525 && (currentPos.x > 150 && currentPos.x < 300))
        {
            playerObj.transform.position = new Vector3(225.0f, 150 * Mathf.FloorToInt((playerObj.transform.position.y - canvas.transform.position.y + 75) / 150)) + canvas.transform.position;
        }
        else
        {
            playerObj.transform.position = initPos + canvas.transform.position;
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