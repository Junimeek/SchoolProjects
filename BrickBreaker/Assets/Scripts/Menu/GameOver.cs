using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Start()
    {
        return;
    }

    public void NewGameStart()
    {
        SceneManager.LoadScene("Global");
        //FindObjectOfType<GameManager>().GameManagerNewGameStart();
    }
}
