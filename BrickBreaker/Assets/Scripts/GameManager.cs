using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int MaxLevelCount;
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }
    public int level = 1;
    public int score = 0;
    public int lives;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        this.score = 0;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
        NewGame();
    }

    public void GameManagerNewGameStart()
    {
        NewGame();
    }
    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;

        if (isDebugActive)
        {
            LoadLevel(OverrideLevelStart);
        }
        else
        {
            LoadLevel(1);
        }
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        if (level > MaxLevelCount)
        {
            SceneManager.LoadScene("WinScreen");
            //Debug.LogError("LEVEL " + level.ToString() + " NOT FOUND");
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
        FindObjectOfType<BeginText>().ShowText();
    }

    private void ResetLevel()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();

        //for (int i = 0; i < this.bricks.Length; i++)
        //{
        //    this.bricks[i].ResetBrick();
        //}
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Destroy(this.gameObject);
    }

    public void Miss()
    {
        this.lives--;

        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }

    public void Hit(Brick brick)
    {
        this.score += brick.points;
        if(Cleared())
        {
            LoadLevel(this.level + 1);
        }
    }

    private bool Cleared()
    {
        for (int i = 0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
        }
        return true;
    }


    // menu management stuff below here
    public bool isGameActive;
    [SerializeField] private bool isDebugActive;
    [SerializeField] private int OverrideLevelStart;

    public void BeginDaGame()
    {
        FindObjectOfType<Ball>().ResetBall();
        FindObjectOfType<BeginText>().RemoveText();
    }

    public void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space) && isGameActive == false )
        {
            BeginDaGame();
            isGameActive = true;
            return;
        }
    }
}
