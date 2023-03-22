using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject credit;

    private void Start()
    {
        ShowMenu();
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("GravityFalls");
    }

    public void QuitGame()
    {
        Debug.LogWarning("QUIT GAME");
        Application.Quit();
    }

    public void ShowMenu()
    {
        title.SetActive(true);
        credit.SetActive(false);
    }

    public void ShowCredit()
    {
        title.SetActive(false);
        credit.SetActive(true);
    }

    public void PageFPS()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/characters/humanoids/sci-fi/easy-fps-73776");
    }

    public void PageStructure()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/3d/environments/industrial/rpg-fps-game-assets-for-pc-mobile-industrial-set-v3-0-101429");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                Debug.LogWarning("QUIT GAME");
                Application.Quit();
            }
        }
    }
}
