using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameManager gameManager = new GameManager();
    private Player playerScript;
    public Transform parentTransform;
    private GameObject playerObj;
    private Vector3 dragedObjPos;

    private Vector3 canvasPos = new Vector3(540, 960, 0);

    public void OnBeginDrag(PointerEventData data)
    {
        playerScript = gameManager.player.GetComponent<Player>();
        playerScript.enabled = false;
        playerObj = GameObject.Find(name);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData data)
    {
        Vector2 modifiedDataPos = new Vector2(data.position.x - canvasPos.x, data.position.y - canvasPos.y);
        // dragedObjPos = new Vector3(200 * (Mathf.Ceil(modifiedDataPos.x / 200)) - 100, 200 * (Mathf.Ceil(modifiedDataPos.y / 200)) - 100);
        // dragedObjPos = new Vector3(200 * (Mathf.Ceil(data.position.x - canvasPos.x / 200)) - 100, 200 * (Mathf.Ceil(data.position.y - canvasPos.y / 200)) - 100);

        // transform.position = dragedObjPos + canvasPos;
        transform.position = new Vector3(200 * (Mathf.Ceil(data.position.x - canvasPos.x / 200)) - 100, 200 * (Mathf.Ceil(data.position.y - canvasPos.y / 200)) - 100) + canvasPos;
    }
    public void OnEndDrag(PointerEventData data)
    {
        playerScript.enabled = true;
        if (dragedObjPos.x >= -400 && dragedObjPos.x <= 400 && dragedObjPos.y >= -200 && dragedObjPos.y <= 600)
        {
            playerObj.tag = "Content";
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}