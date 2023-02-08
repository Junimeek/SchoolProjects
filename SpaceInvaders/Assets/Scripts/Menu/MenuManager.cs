using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameStorageContainer storage;

    private void Awake()
    {
        storage = FindObjectOfType<GameStorageContainer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            storage.curLevel = 1;
            SceneManager.LoadScene("Level1");
        }
    }
}
