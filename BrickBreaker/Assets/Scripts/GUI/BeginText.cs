using UnityEngine;
using UnityEngine.UI;

public class BeginText : MonoBehaviour
{
    public GameObject supertextobject;

    private void Start()
    {
        ShowText();
        FindObjectOfType<GameManager>().isGameActive = false;
    }

    public void RemoveText()
    {
        supertextobject.SetActive(false);
    }

    public void ShowText()
    {
        supertextobject.SetActive(true);
    }
}
