using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool isGameEnd = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    //public int CurLevel;
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            {
            Destroy(gameObject);
            return;
            }
        //DontDestroyOnLoad(gameObject);
    }
    void Start() { Debug.Log("LEVEL START"); }

    public void gameEnd()
    {
        if (isGameEnd == false)
        {
            isGameEnd = true;
            Debug.Log("GAME END");

            // Restart Game
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        //CurLevel = CurLevel + 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Checks scene name; restarts to same scene
    }
    public void completeLevel()
    {
        Debug.Log("LEVEL COMPLETE");
        completeLevelUI.SetActive(true);
    }
}
