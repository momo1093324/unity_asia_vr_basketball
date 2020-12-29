using UnityEngine;
using UnityEngine.UI; //引用介面API

public class ScoreManager : MonoBehaviour
{
    [Header("介面分數")]
    public Text textScore;
    [Header("分數")]
    public int score;
    [Header("投進的分數")]
    public int scoreIn=2;
    [Header("投進音效")]
    public AudioClip soundIn;

    //音效來源aud
    private AudioSource aud;
    
    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    //OTE條件:1.兩碰撞物件其一需勾選Is Trigger/2.要偵測此腳本物件是否產生碰撞/3.必須添加鋼體rigidbody
    private void OnTriggerEnter(Collider other)
    {
        //如果 碰撞物件標籤為籃球就加分
        if (other.tag=="籃球")
        {
            AddScore();
        }
        //如果 碰撞物件名稱為Player，會顯示玩家進入
        if (other.transform.root.name=="Player")
        {
            //玩家進入三分區域，將投進分數改為三分
            scoreIn = 3;
        }
    }
    //當碰撞物件離開碰撞範圍時執行一次
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.name == "Player")
        {
            //將投進分數改為二分
            scoreIn = 2;
        }
    }
    //加分數
    private void AddScore()
    {
        score += scoreIn;       //分數遞增
        textScore.text = "分數 ：" + score;         //介面顯示
        aud.PlayOneShot(soundIn, Random.Range(1f, 3f)); //音效來源.撥放一次PlayOneShot(音效片段，音量Rang)  **Random隨機值
    }
}
