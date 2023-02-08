using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayAIGame()
    {
        SceneManager.LoadScene("PongAI");
    }

    public void Play2PGame()
    {
        SceneManager.LoadScene("Pong2p");
    }
}
