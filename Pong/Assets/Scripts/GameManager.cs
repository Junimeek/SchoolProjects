using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle playerPaddle;
    public Paddle computerPaddle;
    public Text playerScoreText;
    public Text computerScoreText;
    public GameObject FlashPlayer1;
    public GameObject FlashPlayer2;
    public bool FlipControls;
    private int _playerScore;
    private int _computerScore;

    public void PlayerScores()
    {
        _playerScore++;
        FlashPlayer1.SetActive(true);
        this.playerScoreText.text = _playerScore.ToString();
        GetComponent<GameStart>().LoadGameStartText();
        ResetRound();
    }

    public void Player2Scores()
    {
        _playerScore++;
        FlashPlayer2.SetActive(true);
        this.computerScoreText.text = _computerScore.ToString();
        GetComponent<GameStart>().LoadGameStartText();
        ResetRound();
    }

    public void ComputerScores()
    {
        _computerScore++;
        FlashPlayer2.SetActive(true);
        this.computerScoreText.text = _computerScore.ToString();
        GetComponent<GameStart>().LoadGameStartText();
        ResetRound();
    }

    public void ResetRound()
    {
        this.playerPaddle.ResetPosition();
        this.computerPaddle.ResetPosition();
        this.ball.ResetPosition();
        ResetRound();
    }

    public void BeginRound()
    {
        this.ball.AddStartingForce();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            TitleScreenReturn();
        }
    }
    private void TitleScreenReturn()
    {
        if (GetComponent<GameStart>().isGameActive == false)
        {
            SceneManager.LoadScene("Title");
        }
        else
        {
            return;
        }
    }
}
