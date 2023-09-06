using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DragForPractice : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject playerObj;
    private Vector3 initPos;
    //修正されたドラッグ開始時の位置
    public Vector3 currentPos;
    //修正された現在位置
    private GameObject canvas;

    public void OnBeginDrag(PointerEventData data)
    {
        playerObj = GameObject.Find(name);
        initPos = playerObj.transform.position - canvas.transform.position;
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
        GetComponent<AudioSource>().Play();

        if (currentPos.y < 775 && currentPos.y > -475 && (currentPos.x > 200 || currentPos.x < 400))
        {
            playerObj.transform.position = new Vector3(300.0f, 250 * Mathf.FloorToInt((playerObj.transform.position.y - canvas.transform.position.y - 275) / 250) + 400) + canvas.transform.position;
        }
        else
        {
            playerObj.transform.position = initPos + canvas.transform.position;
        }
    }

    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        if (playerObj == null)
        {
            return;
        }
        else
        {
            currentPos = playerObj.transform.position - canvas.transform.position;
        }
    }
}