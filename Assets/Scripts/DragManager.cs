using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public SetManager set;
    //setManagerのインスタンス化
    public static DragManager instance;
    void Awake() { instance = this; }
    //自身のインスタンス化

    //ここから下は自動入力
    private GameObject playerObj;
    //自分のゲームオブジェクトを取得
    private DragManager thisScript;
    //このスクリプトを格納する変数
    private Button buttonForDrag;
    //このgameObjectのButtonコンポーネント
    private Image imageForDrag;
    //
    private RectTransform RectForDrag;
    //

    public bool isInsideSetForOnlyDrag;
    //どれかの集合の中にいるかどうか
    private int gameControllNumber;
    //set.gameControllerArrayの何番目にいるのか
    // public AudioSource putPinSE;

    void Start()
    {
        set = GameObject.Find("SetManager").GetComponent<SetManager>();
        playerObj = GameObject.Find(name);
        thisScript = GetComponent<DragManager>();
        buttonForDrag = GetComponent<Button>();
        imageForDrag = GetComponent<Image>();
        RectForDrag = GetComponent<RectTransform>();

        buttonForDrag.onClick.AddListener(PushPlayerButton);
        if (gameObject.tag == "PlayerButton") buttonForDrag.enabled = false;
        else if (gameObject.tag == "Content") buttonForDrag.enabled = true;

        // putPinSE = Resources.Load<AudioSource>("PutPinAudio");
    }
    void Update()
    {
        for (int i = 0; i < set.gameControllerArray.Count(); i++)
        {
            isInsideSetForOnlyDrag = set.IsInsideIn(set.gameControllerArray[i].parentSet, set.gameControllerArray[i].parentSetRect, gameObject);
            if (isInsideSetForOnlyDrag)
            {
                // Debug.Log(gameControllNumber);
                gameControllNumber = i;
                break;
            }
        }

        if (buttonForDrag.enabled) imageForDrag.color = new Color(imageForDrag.color.r, imageForDrag.color.g, imageForDrag.color.b, (3 + Mathf.Sin(5 * Time.time)) / 4);
    }

    public void OnBeginDrag(PointerEventData data)
    {
        if (gameObject.tag == "PlayerButton")
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            PlayerManager.instance.playerScript.enabled = false;
            RectForDrag.sizeDelta = new Vector2(PlayerManager.instance.gameObjectMovePixel * 9 / 10, PlayerManager.instance.gameObjectMovePixel * 9 / 10);
        }
        else
        {
            Debug.Log("動かせないよ");
        }
    }
    public void OnDrag(PointerEventData data)
    {
        if (gameObject.tag == "PlayerButton")
        {
            transform.position = new Vector3(PlayerManager.instance.gameObjectMovePixel * (Mathf.Ceil((data.position.x - set.canvas.transform.position.x) / PlayerManager.instance.gameObjectMovePixel)) - PlayerManager.instance.gameObjectMovePixel / 2, PlayerManager.instance.gameObjectMovePixel * (Mathf.Ceil((data.position.y - set.canvas.transform.position.y) / PlayerManager.instance.gameObjectMovePixel)) - PlayerManager.instance.gameObjectMovePixel / 2) + set.canvas.transform.position;
        }
    }
    public void OnEndDrag(PointerEventData data)
    {
        if (gameObject.tag == "PlayerButton")
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            thisScript.enabled = false;
            PlayerManager.instance.playerScript.enabled = true;
            set.playerActionList.Add(5);
            GetComponent<AudioSource>().Play();

            for (int i = 0; i < set.setArray.Count(); i++)
            {
                if (set.IsSamePosAs(set.gameControllerArray[i].allSetPosList, gameObject.transform.position))
                {
                    Debug.Log("かぶってるよ");
                    // dragging.SetParent(bottomGameImage.transform);
                    // this.gameObject.transform.SetParent(set.bottomGameImage.transform);
                    // Debug.Log(set.bottomGameImage.transform.childCount);

                    // if (set.bottomGameImage.transform.childCount == 0) set.ReturnDraggingImage(1, gameObject.transform);
                    // else set.ReturnDraggingImage(set.bottomGameImage.transform.childCount + 1, gameObject.transform);
                    set.ReturnDraggingImage(set.bottomGameImage.transform.childCount, gameObject.transform);
                    RectForDrag.sizeDelta = new Vector2(180, 180);
                    thisScript.enabled = true;
                    return;
                }
            }
            Debug.Log("かぶってないよ");

            if (isInsideSetForOnlyDrag)
            {
                gameObject.tag = "Content";
                gameObject.transform.SetParent(set.gameControllerArray[gameControllNumber].parentSet.transform);
                set.bottomChildrenTransform.Remove(gameObject.transform);
            }
            set.FixDraggingImage(set.bottomGameImage.transform.childCount);
        }
    }

    public void PushPlayerButton()
    {
        Debug.Log("PlayerButtonおされたよ");
        set.bottomChildrenTransform.Add(gameObject.transform);
        gameObject.tag = "PlayerButton";
        buttonForDrag.enabled = false;
        RectForDrag.sizeDelta = new Vector2(180, 180);
        imageForDrag.color = new Color(imageForDrag.color.r, imageForDrag.color.g, imageForDrag.color.b, 1.0f);
        set.ReturnDraggingImage(set.bottomGameImage.transform.childCount + 1, gameObject.transform);
    }
}
