using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public SetManager set;
    //インスタンス化
    public static PlayerManager instance;
    void Awake() { instance = this; }
    //自身のインスタンス化

    private Vector3 startTouchPos;
    private Vector3 endTouchPos;
    private float flickValue_x;
    private float flickValue_y;
    //playerManagerでPlayerを動かすために使うメンバ変数

    private RectTransform playerTransform;
    //このスクリプトがアタッチされているgameObjectのrectTransformを格納
    public int gameObjectMovePixel;
    //このスクリプトがアタッチされているgameObjectを動かすときの大きさ

    // public Vector3 currentPos;
    //修正された現在位置・デバッグ用です、消せ
    // private Vector3 canvasPos = new Vector3(540.0f, 960.0f, 0f);
    //キャンバスの大きさ
    public PlayerManager playerScript;

    void Start()
    {
        set = GameObject.Find("SetManager").GetComponent<SetManager>();
        playerTransform = gameObject.GetComponent<RectTransform>();
        gameObjectMovePixel = (int)playerTransform.sizeDelta.x * 10 / 9;
        playerScript = gameObject.GetComponent<PlayerManager>();
    }

    // private bool isInsideAnySet
    void Update()
    {
        if (gameObject.tag == "Content")
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                startTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }
            if (Input.GetMouseButtonUp(0) == true)
            {
                endTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
                GetDirection();
            }
        }
        // currentPos = playerObj.transform.position - canvasPos;

        if (!(isInsideAnySet()) && !(this.gameObject.transform.parent.transform.gameObject.name == "BottomGameImage"))
        {
            set.gameOver.SetActive(true);
            Debug.Log("外出た");
        }
    }

    //どれかに入ってたらtrue
    public bool isInsideAnySet()
    {
        for (int i = 0; i < set.gameControllerArray.Length; i++) if (set.gameControllerArray[i].isInsideSet) return true;
        return false;
    }

    //ここから関数
    //if(gameObject.tag=="Content")
    void GetDirection()
    {
        flickValue_x = endTouchPos.x - startTouchPos.x;
        flickValue_y = endTouchPos.y - startTouchPos.y;

        if (Mathf.Abs(flickValue_x) > Mathf.Abs(flickValue_y)) flickValue_y = 0;
        else flickValue_x = 0;

        if (flickValue_x > 300.0f) MoveRight();
        else if (flickValue_x < -300.0f) MoveLeft();
        else if (flickValue_y > 300.0f) MoveUp();
        else if (flickValue_y < -300.0f) MoveDown();
    }

    public void MoveRight()
    {
        transform.position += new Vector3(gameObjectMovePixel, 0);
        set.playerActionList.Add(1);
    }

    public void MoveLeft()
    {
        transform.position += new Vector3(-gameObjectMovePixel, 0);
        set.playerActionList.Add(2);
    }

    public void MoveUp()
    {
        transform.position += new Vector3(0, gameObjectMovePixel);
        set.playerActionList.Add(3);
    }

    public void MoveDown()
    {
        transform.position += new Vector3(0, -gameObjectMovePixel);
        set.playerActionList.Add(4);
    }

    //if(gameObject.tag=="PlayerButton")
    // public void OnBeginDrag(PointerEventData data)
    // {
    //     if (gameObject.tag == "PlayerButton") GetComponent<CanvasGroup>().blocksRaycasts = false;
    // }

    // public void OnDrag(PointerEventData data)
    // {
    //     if (gameObject.tag == "PlayerButton") transform.position = new Vector3(200 * (Mathf.Ceil((data.position.x - canvasPos.x) / 200)) - 100, 200 * (Mathf.Ceil((data.position.y - canvasPos.y) / 200)) - 100) + canvasPos;
    // }

    // public bool endDragJudge = false;
    // public void OnEndDrag(PointerEventData data)
    // {
    //     if (gameObject.tag == "PlayerButton")
    //     {
    //         GetComponent<CanvasGroup>().blocksRaycasts = true;
    //         endDragJudge = true;

    //         transform.position = new Vector3(200 * (Mathf.Ceil((data.position.x - canvasPos.x) / 200)) - 100, 200 * (Mathf.Ceil((data.position.y - canvasPos.y) / 200)) - 100) + canvasPos;
    //         set.playerActionList.Add(5);
    //     }
    // }

    // public void EndDrag()
    // {
    //     if (endDragJudge) gameObject.tag = "Content";
    //     endDragJudge = false;
    // }

    // public void ReturnBottomImage()
    // {
    //     gameObject.tag = "PlayerButton";
    //     gameObject.transform.SetParent(bottomImage.transform);
    //     gameObject.transform.localPosition = new Vector3(250, 0, 0);
    //     set.playerActionList.Add(6);
    // }
}