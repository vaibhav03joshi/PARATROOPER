using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI HiScoreText;
    [SerializeField] private GameObject GameOverGameObject;
    [SerializeField] private Button RestartButton;
    public static Score score;
    private int currentScore = 0;
    private int HiScore = 0;
    private void Awake()
    {
        score = this;
        GameOverGameObject.SetActive(false);
        HiScore = PlayerPrefs.GetInt("HiScore", 0);
        currentScoreText.text = "0";
        HiScoreText.text = HiScore.ToString();
        RestartButton.onClick.AddListener(RestartGame);
    }
    private void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        StartCoroutine(TriggerGameOver());
        if (currentScore > HiScore)
        {
            PlayerPrefs.SetInt("HiScore", currentScore);
        }
    }
    IEnumerator TriggerGameOver()
    {
        yield return new WaitForSeconds(3);
        Enemy.TroopsOnPosition = 0;
        GameOverGameObject.SetActive(true);
    }
}