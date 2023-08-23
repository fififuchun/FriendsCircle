using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetManager : MonoBehaviour
{
    public GameObject canvas;
    //canvasをStartで自動入力
    public GameObject bottomGameImage;
    //その名の通り
    public GameObject pauseImage;
    //全画面のpauseImageのGameObject
    // public Sprite resumeImageForPrefab;
    //再生ボタンのsprite
    // public Sprite pauseImageForPrefab;
    //停止ボタンのsprite
    public GameObject pauseButton;
    //settingButtonの子どものpauseButton
    public GameObject hintButton;
    //
    public GoogleRewardAds rewardAdsManager;
    //リワード広告をアタッチしたオブジェクトのインスタンス化

    public List<int> playerActionList = new List<int>();
    //行動を示す番号付け
    public GameController[] gameControllerArray;
    //
    public GameObject[] setArray;
    //
    public List<Transform> bottomChildrenTransform;
    //bottomGameImageの子オブジェクトのtransformを配列で取得
    public GameObject explainHintImage;
    //ヒントそのもののオブジェクト
    private Button closeHintButton;
    //ヒントオブジェクトを閉じる

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        setArray = GameObject.FindGameObjectsWithTag("Set");
        bottomGameImage = GameObject.Find("BottomGameImage");
        gameControllerArray = new GameController[setArray.Count()];
        for (int i = 0; i < setArray.Count(); i++) gameControllerArray[i] = GameObject.FindGameObjectsWithTag("GameController")[i].GetComponent<GameController>();
        for (int i = 0; i < bottomGameImage.transform.childCount; i++) bottomChildrenTransform.Add(bottomGameImage.transform.GetChild(i).transform);

        if (SceneManager.GetActiveScene().name == "STAGE0_1" || SceneManager.GetActiveScene().name == "STAGE0_2" || SceneManager.GetActiveScene().name == "STAGE0_3") return;
        pauseImage = Resources.Load<GameObject>("PauseImage Variant");
        hintPrefab = Resources.Load<GameObject>("ForRewardAds");
        // resumeImageForPrefab = Resources.Load<Sprite>("pause");
        // pauseImageForPrefab = Resources.Load<Sprite>("stop2");

        pauseButton = GameObject.FindWithTag("SettingButton").transform.GetChild(0).gameObject;
        hintButton = GameObject.FindWithTag("SettingButton").transform.GetChild(1).gameObject;
        pauseButton.GetComponent<Button>().onClick.AddListener(PushPauseButton);
        hintButton.GetComponent<Button>().onClick.AddListener(PushHintButton);
        rewardAdsManager = GameObject.Find("RewardAdsManager").GetComponent<GoogleRewardAds>();
        // explainHintImage = GameObject.Find("ExplainHintImage");
        // closeHintButton = explainHintImage.transform.GetChild(1).GetComponent<Button>();
        // closeHintButton.onClick.AddListener(PushCloseHintButton);
    }

    //List<string>型のsetFamiltListをHashSetに変換
    public void ChangeHashSet(List<string> list, HashSet<int> set)
    {
        if (list.Contains("Empty")) set.Add(2);
        if (list.Contains("a")) set.Add(3);
        if (list.Contains("b")) set.Add(5);
        if (list.Contains("c")) set.Add(7);
        if (list.Contains("d")) set.Add(11);
        if (list.Contains("ab")) set.Add(13);
        if (list.Contains("ac")) set.Add(17);
        if (list.Contains("ad")) set.Add(19);
        if (list.Contains("bc")) set.Add(23);
        if (list.Contains("bd")) set.Add(29);
        if (list.Contains("cd")) set.Add(31);
        if (list.Contains("abc")) set.Add(37);
        if (list.Contains("abd")) set.Add(41);
        if (list.Contains("acd")) set.Add(43);
        if (list.Contains("bcd")) set.Add(47);
        if (list.Contains("abcd")) set.Add(53);
    }

    //setNumberによって位相空間かを判定
    public bool IsTopsp(int x)
    {
        if (
            x == 2 || x == 6 || x == 10 || x == 14 || x == 22 || //文字1つ

            x == 26 || x == 34 || x == 38 || x == 46 || x == 58 || x == 62 || //文字2つ
            x == 78 || x == 102 || x == 114 || x == 230 || x == 290 || x == 434 ||
            x == 130 || x == 238 || x == 418 || x == 322 || x == 638 || x == 682 ||
            x == 390 || x == 714 || x == 1254 || x == 1150 || x == 3190 || x == 4774 ||

            x == 74 || x == 222 || x == 370 || x == 518 || x == 962 || x == 1702 || x == 1258 || //文字3つ
            x == 5106 || x == 6290 || x == 6734 || x == 2886 || x == 3774 || x == 4810 || x == 8510 || x == 8806 || x == 11914 ||
            x == 14430 || x == 59570 || x == 26418 || x == 49062 || x == 110630 || x == 202538 ||
            x == 331890 || x == 774410 || x == 607614 || x == 1012690 || x == 245310 || x == 343434 || x == 39494910 ||
            x == 15458700270
        )
            return true;
        else return false;
    }

    //listの中にplayerPosと同じsetがいるかどうかを判定
    public bool IsSamePosAs(List<Vector2> list, Vector2 playerPos)
    {
        for (int i = 0; i < list.Count; i++) if (list[i] == playerPos) return true;
        return false;
    }

    //dragedPlayerがsetの中に完全に収まってるかどうか
    public bool IsInsideIn(GameObject set, RectTransform setRect, GameObject dragedPlayer)
    {
        if (Mathf.Abs(set.transform.position.x - dragedPlayer.transform.position.x) < setRect.sizeDelta.x / 2 && Mathf.Abs(set.transform.position.y - dragedPlayer.transform.position.y) < setRect.sizeDelta.y / 2)
        {
            return true;
        }
        else return false;
    }

    //ドラッグ時にかぶってたらBottomに帰す
    public void ReturnDraggingImage(int childNum, Transform dragging)
    {
        dragging.SetParent(bottomGameImage.transform);
        playerActionList.Add(6);
        Debug.Log("戻すよ");
        switch (childNum)
        {
            case 1:
                bottomChildrenTransform[0].localPosition = new Vector3(200, 0);
                break;
            case 2:
                bottomChildrenTransform[0].localPosition = new Vector3(100, 0);
                bottomChildrenTransform[1].localPosition = new Vector3(300, 0);
                break;
            case 3:
                bottomChildrenTransform[0].localPosition = new Vector3(0, 0);
                bottomChildrenTransform[1].localPosition = new Vector3(200, 0);
                bottomChildrenTransform[2].localPosition = new Vector3(400, 0);
                break;
            case 4:
                bottomChildrenTransform[0].localPosition = new Vector3(100, 100);
                bottomChildrenTransform[1].localPosition = new Vector3(300, 100);
                bottomChildrenTransform[2].localPosition = new Vector3(100, -100);
                bottomChildrenTransform[3].localPosition = new Vector3(300, -100);
                break;
            case 5:
                bottomChildrenTransform[0].localPosition = new Vector3(0, 100);
                bottomChildrenTransform[1].localPosition = new Vector3(200, 100);
                bottomChildrenTransform[2].localPosition = new Vector3(400, 100);
                bottomChildrenTransform[3].localPosition = new Vector3(100, -100);
                bottomChildrenTransform[4].localPosition = new Vector3(300, -100);
                break;
            case 6:
                bottomChildrenTransform[0].localPosition = new Vector3(0, 100);
                bottomChildrenTransform[1].localPosition = new Vector3(200, 100);
                bottomChildrenTransform[2].localPosition = new Vector3(400, 100);
                bottomChildrenTransform[3].localPosition = new Vector3(0, -100);
                bottomChildrenTransform[4].localPosition = new Vector3(200, -100);
                bottomChildrenTransform[5].localPosition = new Vector3(400, -100);
                break;
        }
    }

    public void FixDraggingImage(int childNum)
    {
        switch (childNum)
        {
            case 1:
                bottomChildrenTransform[0].localPosition = new Vector3(200, 0);
                break;
            case 2:
                bottomChildrenTransform[0].localPosition = new Vector3(100, 0);
                bottomChildrenTransform[1].localPosition = new Vector3(300, 0);
                break;
            case 3:
                bottomChildrenTransform[0].localPosition = new Vector3(0, 0);
                bottomChildrenTransform[1].localPosition = new Vector3(200, 0);
                bottomChildrenTransform[2].localPosition = new Vector3(400, 0);
                break;
            case 4:
                bottomChildrenTransform[0].localPosition = new Vector3(100, 100);
                bottomChildrenTransform[1].localPosition = new Vector3(300, 100);
                bottomChildrenTransform[2].localPosition = new Vector3(100, -100);
                bottomChildrenTransform[3].localPosition = new Vector3(300, -100);
                break;
            case 5:
                bottomChildrenTransform[0].localPosition = new Vector3(0, 100);
                bottomChildrenTransform[1].localPosition = new Vector3(200, 100);
                bottomChildrenTransform[2].localPosition = new Vector3(400, 100);
                bottomChildrenTransform[3].localPosition = new Vector3(100, -100);
                bottomChildrenTransform[4].localPosition = new Vector3(300, -100);
                break;
            case 6:
                bottomChildrenTransform[0].localPosition = new Vector3(0, 100);
                bottomChildrenTransform[1].localPosition = new Vector3(200, 100);
                bottomChildrenTransform[2].localPosition = new Vector3(400, 100);
                bottomChildrenTransform[3].localPosition = new Vector3(0, -100);
                bottomChildrenTransform[4].localPosition = new Vector3(200, -100);
                bottomChildrenTransform[5].localPosition = new Vector3(400, -100);
                break;
        }
    }

    public int Max(int a, int b)
    {
        if (a < b) return b;
        else return a;
    }

    public int Min(int a, int b)
    {
        if (a < b) return a;
        else return b;
    }

    public void PushOneMoreButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PushReturnButton()
    {
        SceneManager.LoadScene("SelectScene");
    }

    private bool isPause;
    private GameObject pauseObject;
    public void PushPauseButton()
    {
        if (isPause) return;
        if (isHint) PushReturnToGameButton();
        pauseObject = Instantiate(pauseImage, canvas.transform);
        isPause = true;
        pauseObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(PushOneMoreButton);
        pauseObject.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(PushReturnButton);
        pauseObject.transform.GetChild(3).gameObject.GetComponent<Button>().onClick.AddListener(PushResumeButton);
    }

    public void PushResumeButton()
    {
        Destroy(pauseObject);
        isPause = false;
    }

    private GameObject hintPrefab;
    private GameObject hintObject;
    private bool isHint;
    public void PushHintButton()
    {
        if (isHint) return;
        isHint = true;
        hintObject = Instantiate(hintPrefab, canvas.transform);
        hintObject.transform.GetChild(0).gameObject.GetComponent<Button>().onClick.AddListener(PushWatchAds);
        hintObject.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(PushReturnToGameButton);
        rewardAdsManager.LoadRewardedAd();
    }

    public void PushWatchAds()
    {
        rewardAdsManager.ShowRewardedAd();
    }

    public void PushReturnToGameButton()
    {
        Destroy(hintObject);
        isHint = false;
    }

    public void PushCloseHintButton()
    {
        explainHintImage.SetActive(false);
    }

    public void PushClearButton()
    {
        //クリア時の処理
        int stageNum = PlayerPrefs.GetInt("StageNum", 1);
        string stageName = SceneManager.GetActiveScene().name;

        switch (stageName)
        {
            case "STAGE0_1":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 2));
                break;
            case "STAGE0_2":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 3));
                break;
            case "STAGE0_3":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 4));
                break;
            case "STAGE0_4":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 5));
                break;
            case "STAGE0_5":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 6));
                break;
            case "STAGE1_1"://要修正ーーー
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 7));
                break;
            case "STAGE1_2":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 8));
                break;
            case "STAGE1_3":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 9));
                break;
            case "STAGE1_4":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 10));
                break;
            case "STAGE1_5":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 9));
                break;
            case "STAGE1_6":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 10));
                break;
            case "STAGE1_7":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 11));
                break;
            case "STAGE1_8":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 12));
                break;
            case "STAGE1_9":
                PlayerPrefs.SetInt("StageNum", Max(stageNum, 13));
                break;
        }

        SceneManager.LoadScene("SelectScene");
    }
}