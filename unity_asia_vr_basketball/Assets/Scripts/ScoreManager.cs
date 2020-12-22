using UnityEngine;
using UnityEngine.UI; //引用介面API

public class ScoreManager : MonoBehaviour
{
    [Header("介面分數")]
    public Text textScore;
    [Header("分數")]
    public int score;

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
    }
}
