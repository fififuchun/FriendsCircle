using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    #region //位相空間の例
    public GameObject empty;
    public GameObject a;
    public GameObject b;
    public GameObject c;
    public GameObject d;
    public GameObject ab;
    public GameObject ac;
    public GameObject bc;

    //non sorted
    public List<string> list0_1 = new List<string>();

    public List<string> list1_1 = new List<string>();
    public List<string> list1_2 = new List<string>();
    public List<string> list1_3 = new List<string>();
    public List<string> list1_4 = new List<string>();


    public List<string> list2_1 = new List<string>();
    public List<string> list2_2 = new List<string>();
    public List<string> list2_3 = new List<string>();
    public List<string> list2_4 = new List<string>();
    public List<string> list2_5 = new List<string>();
    public List<string> list2_6 = new List<string>();
    public List<string> list2_7 = new List<string>();
    public List<string> list2_8 = new List<string>();
    public List<string> list2_9 = new List<string>();
    public List<string> list2_10 = new List<string>();
    public List<string> list2_11 = new List<string>();
    public List<string> list2_12 = new List<string>();

    //sorted
    public List<string> sortedList0_1 = new List<string>();

    public List<string> sortedList1_1 = new List<string>();
    public List<string> sortedList1_2 = new List<string>();
    public List<string> sortedList1_3 = new List<string>();
    public List<string> sortedList1_4 = new List<string>();

    public List<string> sortedList2_1 = new List<string>();
    public List<string> sortedList2_2 = new List<string>();
    public List<string> sortedList2_3 = new List<string>();
    public List<string> sortedList2_4 = new List<string>();
    public List<string> sortedList2_5 = new List<string>();
    public List<string> sortedList2_6 = new List<string>();
    public List<string> sortedList2_7 = new List<string>();
    public List<string> sortedList2_8 = new List<string>();
    public List<string> sortedList2_9 = new List<string>();
    public List<string> sortedList2_10 = new List<string>();
    public List<string> sortedList2_11 = new List<string>();
    public List<string> sortedList2_12 = new List<string>();


    void Awake()
    {
        list0_1.Add(empty.name);

        list1_1.Add(empty.name);
        list1_1.Add(a.name);

        list1_2.Add(empty.name);
        list1_2.Add(b.name);

        list1_3.Add(empty.name);
        list1_3.Add(c.name);

        list1_4.Add(empty.name);
        list1_4.Add(d.name);

        list2_1.Add(empty.name);
        list2_1.Add(ab.name);

        list2_2.Add(empty.name);
        list2_2.Add(a.name);
        list2_2.Add(ab.name);

        list2_3.Add(empty.name);
        list2_3.Add(b.name);
        list2_3.Add(ab.name);

        list2_4.Add(empty.name);
        list2_4.Add(a.name);
        list2_4.Add(b.name);
        list2_4.Add(ab.name);

        list2_5.Add(empty.name);
        list2_5.Add(ac.name);

        list2_6.Add(empty.name);
        list2_6.Add(bc.name);

        list2_7.Add(empty.name);
        list2_7.Add(a.name);
        list2_7.Add(ac.name);

        list2_8.Add(empty.name);
        list2_8.Add(c.name);
        list2_8.Add(ac.name);

        list2_9.Add(empty.name);
        list2_9.Add(b.name);
        list2_9.Add(bc.name);

        list2_10.Add(empty.name);
        list2_10.Add(c.name);
        list2_10.Add(bc.name);

        list2_11.Add(empty.name);
        list2_11.Add(a.name);
        list2_11.Add(c.name);
        list2_11.Add(ac.name);

        list2_12.Add(empty.name);
        list2_12.Add(b.name);
        list2_12.Add(c.name);
        list2_12.Add(bc.name);

        sortedList0_1 = list0_1.OrderBy(e => e).ToList();
        sortedList1_1 = list1_1.OrderBy(e => e).ToList();
        sortedList1_2 = list1_2.OrderBy(e => e).ToList();
        sortedList1_3 = list1_3.OrderBy(e => e).ToList();
        sortedList1_4 = list1_4.OrderBy(e => e).ToList();
        sortedList2_1 = list2_1.OrderBy(e => e).ToList();
        sortedList2_2 = list2_2.OrderBy(e => e).ToList();
        sortedList2_3 = list2_3.OrderBy(e => e).ToList();
        sortedList2_4 = list2_4.OrderBy(e => e).ToList();
        sortedList2_5 = list2_5.OrderBy(e => e).ToList();
        sortedList2_6 = list2_6.OrderBy(e => e).ToList();
        sortedList2_7 = list2_7.OrderBy(e => e).ToList();
        sortedList2_8 = list2_8.OrderBy(e => e).ToList();
        sortedList2_9 = list2_9.OrderBy(e => e).ToList();
        sortedList2_10 = list2_10.OrderBy(e => e).ToList();
        sortedList2_11 = list2_11.OrderBy(e => e).ToList();
        sortedList2_12 = list2_12.OrderBy(e => e).ToList();
    }

    public bool IsThisTopsp(List<string> judgeList)
    {
        if (judgeList.SequenceEqual(sortedList0_1))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList1_1))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList1_2))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList1_3))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList1_4))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_1))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_2))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_3))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_4))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_5))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_6))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_7))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_8))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_9))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_10))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_11))
        {
            return true;
        }
        else if (judgeList.SequenceEqual(sortedList2_12))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    //setStringList:それが位相空間か文字列の一致によって判定
    //setArray:     タグにより一括で動的入力
    public List<string> setStringList;
    public List<string> sortedSetStringList;
    public GameObject[] setArray;

    //setのタグを持つものをスタート関数で動的に入力
    public GameObject set;
    public Image setImage;
    private RectTransform setSize;

    //動かすプレイヤーとゲーム終了画面のここにアタッチ
    public GameObject player;
    public GameObject gameOverImage;
    public GameObject gameClearImage;

    //playerとgameImageの位置を管理
    private Vector3 playerPos;
    public GameObject canvas;
    private Vector3 modifiedPlayerPos;
    private Vector3 modifiedSetPos;
    public GameObject prefabs;
    public GameObject stageManager;

    //
    void Start()
    {
        set = GameObject.FindWithTag("Set");
        setSize = set.GetComponent<RectTransform>();
        setImage = set.GetComponent<Image>();
    }

    void Update()
    {
        //配列の動的変更
        setArray = GameObject.FindGameObjectsWithTag("Content");
        setStringList.Clear();
        for (int i = 0; i < setArray.Length; i++)
        {
            setStringList.Add(setArray[i].name);
        }
        sortedSetStringList = setStringList.OrderBy(e => e).ToList();

        //ゲームオーバー管理
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        modifiedPlayerPos = playerPos - canvas.transform.position;
        modifiedSetPos = set.transform.position - canvas.transform.position;

        if (modifiedPlayerPos.x > modifiedSetPos.x + setSize.sizeDelta.x / 2 || modifiedPlayerPos.x < modifiedSetPos.x - setSize.sizeDelta.x / 2 || modifiedPlayerPos.y > modifiedSetPos.y + setSize.sizeDelta.y / 2 || modifiedPlayerPos.y < modifiedSetPos.y - setSize.sizeDelta.y / 2)
        {
            // ShowGameOver();
        }

        //位相空間か判別
        if (!IsThisTopsp(sortedSetStringList))
        {
            setImage.color = new Color32(255, 255, 255, 127);
            if (sortedSetStringList.Contains(player.name)) ShowGameOver();
        }
        else
        {
            setImage.color = new Color32(255, 255, 255, 255);
        }

        // Debug.Log(sortedSetStringList.Contains(player.name));
    }

    public void ShowGameOver()
    {
        player.SetActive(false);
        gameOverImage.SetActive(true);
        stageManager.SetActive(false);
        gameClearImage.SetActive(false);
    }

    public void PushClearButton()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void PushOnemoreButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}