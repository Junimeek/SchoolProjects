using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject ui;
    private GameManager gameManager;
    [SerializeField] private bool isDaGameActive;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        isDaGameActive = FindObjectOfType<GameManager>().isGameActive;
    }

    public void DetectSpaceBar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();

        }    
    }
    public void StartGame()
    {
        if (isDaGameActive == false)
        {
            FindObjectOfType<GameManager>().BeginDaGame();
            ui.SetActive(false);
            isDaGameActive = true;
        }
        else if (isDaGameActive == true)
        {
            return;
        }
    }

    public void StartLevel1()
    {
        return;
    }
}
