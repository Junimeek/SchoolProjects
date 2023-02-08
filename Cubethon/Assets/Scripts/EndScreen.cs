using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}
