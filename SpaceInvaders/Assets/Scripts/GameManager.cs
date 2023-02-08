using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text liveText;
    [SerializeField] private Text invaderText;
    public int curScore;
    public int startingLives;
    public int curLives;
    //public int curLevel;
    public int MaxLevels;
    public bool isDebugMode;
    private Invaders invadergroup;
    private MenuManager menumanager;
    private GameStorageContainer storage;

    private void Awake()
    {
        invadergroup = FindObjectOfType<Invaders>();
        menumanager = FindObjectOfType<MenuManager>();
        storage = FindObjectOfType<GameStorageContainer>();
    }

    private void Start()
    {
        InitializeGame(startingLives);
    }

    public void Score(int worth)
    {
        curScore = curScore + worth;
        storage.StoredScore = curScore;

        if (curScore < 10)
        {
            scoreText.text = "000" + curScore.ToString();
        }
        else if (curScore >= 10 && curScore < 100)
        {
            scoreText.text = "00" + curScore.ToString();
        }
        else if (curScore >= 100 && curScore < 1000)
        {
            scoreText.text = "0" + curScore.ToString();
        }
        else if (curScore >= 1000)
        {
            scoreText.text = curScore.ToString();
        }

        storage.StoredScoreText = scoreText.text;
    }

    public void LifeLoss()
    {
        curLives = curLives - 1;
        if (curLives == 0)
        {
            EndGame();
        }
        else if (curLives > 0)
        {
            liveText.text = "X " + curLives.ToString();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("LoseState");
        storage.StoredScore = 0;
        storage.StoredScoreText = "0000";
    }

    public void AdvanceLevel()
    {
        if (storage.MaxLevels == storage.curLevel)
        {
            storage.StoredScore = 0;
            storage.StoredScoreText = "0000";
            SceneManager.LoadScene("WinState");
        }
        else if (storage.MaxLevels > storage.curLevel)
        {
            storage.curLevel++;
            SceneManager.LoadScene("Level" + storage.curLevel.ToString());
        }
    }

    public void InitializeGame(int livesToStart)
    {
        curScore = storage.StoredScore;
        curLives = livesToStart;
        invaderText.text = "100%";
        liveText.text = "X " + curLives.ToString();
        scoreText.text = storage.StoredScoreText;
    }

    public void InvaderPercentUpdate(float percent)
    {
        invaderText.text = Mathf.Round(percent*100f) + "%";
    }
}
