using UnityEngine;
using UnityEngine.UI;

public class UiScore : MonoBehaviour
{
    public Text ScoreText;
    public Text LivesText;
    public Text LevelText;

    void Update()
    {
        ScoreText.text = FindObjectOfType<GameManager>().score.ToString();
        LivesText.text = "LIVES: " + FindObjectOfType<GameManager>().lives.ToString();
        LevelText.text = "LEVEL: " + FindObjectOfType<GameManager>().level.ToString() + "/5";
    }
}
