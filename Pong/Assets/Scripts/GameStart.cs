using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject Player1Flash;
    public GameObject Player2Flash;
    public bool isGameActive;

    void Start()
    {
        LoadGameStartText();
        isGameActive = false;
    }

    public void LoadGameStartText()
    {
        isGameActive = false;
        StartMenu.SetActive(true);
        Invoke("RemoveFlash", 1);
    }

    private void Update()
    {
        if (isGameActive == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGameActive = true;
                GetComponent<GameManager>().BeginRound();
                StartMenu.SetActive(false);
            }
        }
        else
        {
            return;
        }
    }

    private void RemoveFlash()
    {
        Player1Flash.SetActive(false);
        Player2Flash.SetActive(false);
    }
}
