using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public SetManager set;
    //SetManagerのインスタンス化
    public GameObject parentSet;
    //要素の集合を覆う白いゲームオブジェクト
    public GameObject gameOver;
    //ゲームオーバーのイメージ
    public GameObject blockImage;
    //setParentを覆う透明なブロックイメージ

    //ここから下は自動入力

    public long setNumber = 1;
    //集合族から自然数への全単射の終値
    public RectTransform parentSetRect;
    //parentSetのrectTransformをStartで取得
    private Image parentSetImage;
    //parentSetのImageコンポーネント
    private HashSet<int> setFamilyHashset = new HashSet<int>();
    //集合族をここで管理
    public List<string> setFamilyList = new List<string>();
    //現在の集合族の要素を文字列で逐一取得
    /*[SerializeField]*/
    public List<Vector2> setPosList = new List<Vector2>();
    //集合それぞれのtransform.positionを格納/Playerを除くparentSetを基準とした座標を格納
    public List<Vector2> allSetPosList = new List<Vector2>();
    //parentSetの子オブジェクトをcanvas基準でPlayerを含めて取得・格納
    public bool isInsideSet;
    //今PlayerがparentSetに入っているかどうか
    private int previousCount;
    //さっきまでsetFamilyListが何個だったかを表すメンバ変数であり、ChatGPTありがとう

    void Start()
    {
        parentSetRect = parentSet.GetComponent<RectTransform>();
        parentSetImage = parentSet.GetComponent<Image>();
        FixAllSet();
        FixSetInformation();
    }

    void Update()
    {
        FixAllSet();

        //set.playerActionListの個数が増えたら一回だけ次の関数を実行
        if (set.playerActionList.Count > previousCount)
        {
            FixSetInformation();
            // Debug.Log("actionListの個数:" + set.playerActionList.Count + ",さっきまでの個数:" + previousCount + ",setNumber:" + setNumber);
        }
        previousCount = set.playerActionList.Count();

        // Debug.Log(isInsideSet);
    }

    public void FixSetInformation()
    {
        //かぶらないでほしい
        if (set.IsSamePosAs(setPosList, PlayerManager.instance.gameObject.transform.localPosition) && parentSet.name == PlayerManager.instance.gameObject.transform.parent.name)
        {
            switch (set.playerActionList.Last())
            {
                case 1:
                    PlayerManager.instance.MoveLeft();
                    break;
                case 2:
                    PlayerManager.instance.MoveRight();
                    break;
                case 3:
                    PlayerManager.instance.MoveDown();
                    break;
                case 4:
                    PlayerManager.instance.MoveUp();
                    break;
            }
        }

        //親子関係を修正
        set.FixSet();

        //allSetPosListを修正
        allSetPosList.Clear();
        for (int i = 0; i < parentSet.transform.childCount; i++) if (parentSet.transform.GetChild(i).tag == "Content") allSetPosList.Add(parentSet.transform.GetChild(i).transform.position);

        //playerがこの集合の要素ならisInsideSetをtrueにする
        if (set.IsInsideIn(parentSet, parentSetRect, PlayerManager.instance.gameObject)) isInsideSet = true;
        else isInsideSet = false;

        //SetParent
        if (isInsideSet) PlayerManager.instance.gameObject.transform.SetParent(parentSet.transform);
    }

    public void FixAllSet()
    {
        //初期化
        setFamilyList.Clear();
        setFamilyHashset.Clear();
        setPosList.Clear();
        setNumber = 1;

        //更新
        for (int i = 0; i < parentSet.transform.childCount; i++)
        {
            if (parentSet.transform.GetChild(i).gameObject.tag == "Content")
            {
                setFamilyList.Add(parentSet.transform.GetChild(i).name);
                setPosList.Add(parentSet.transform.GetChild(i).transform.localPosition);
            }
        }
        if (parentSet.name == PlayerManager.instance.gameObject.transform.parent.name)
            setPosList.Remove(PlayerManager.instance.gameObject.transform.localPosition);

        set.ChangeHashSet(setFamilyList, setFamilyHashset);
        foreach (int i in setFamilyHashset) setNumber *= i;

        //色変える
        if (set.IsTopsp(setNumber))
        {
            parentSetImage.color = new Color(parentSetImage.color.r, parentSetImage.color.g, parentSetImage.color.b, 1.0f);
            blockImage.SetActive(false);
        }
        else
        {
            parentSetImage.color = new Color(parentSetImage.color.r, parentSetImage.color.g, parentSetImage.color.b, 0.5f);
            blockImage.SetActive(true);
            if (setFamilyList.Contains(PlayerManager.instance.gameObject.name))
            {
                gameOver.SetActive(true);
                Debug.Log("over");
            }
            else gameOver.SetActive(false);
        }

        // //playerがこの集合の要素ならisInsideSetをtrueにする
        // if (set.IsInsideIn(parentSet, parentSetRect, PlayerManager.instance.gameObject)) isInsideSet = true;
        // else isInsideSet = false;
    }
}