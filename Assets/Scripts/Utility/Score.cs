using TMPro;
using UnityEngine;

class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI HiScoreText;
    public static Score score;
    private int currentScore = 0;
    private int HiScore = 0;
    private void Awake()
    {
        score = this;
        HiScore = PlayerPrefs.GetInt("HiScore", 0);
        currentScoreText.text = "0";
        HiScoreText.text = HiScore.ToString();
    }
    public static Score GetScoreManager()
    {
        return score;
    }
    public void AddToScore(int score)
    {
        if (currentScore == 0 && score < 0)
        {
            return;
        }
        currentScore += score;
        currentScoreText.text = currentScore.ToString();
    }
    public void GameOver()
    {
        if (currentScore > HiScore) {
            PlayerPrefs.SetInt("HiScore", currentScore);
            //Go to main menu
        }
    }
}