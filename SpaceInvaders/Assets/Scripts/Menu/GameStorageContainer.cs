using UnityEngine;

public class GameStorageContainer : MonoBehaviour
{
    private static GameStorageContainer instance;

    [Header("Storage")]
    public int StoredScore;
    public int curLevel;
    public string StoredScoreText;

    [Header("Super Initialization")]
    public int PlayerSpeed;
    public int LaserSpeed;
    public int MissileSpeed;
    public int ShipSpeed;
    public int KillWorth;
    public int ShipKillWorth;
    public int MaxLevels;

    private void Awake()
    {
        StoredScoreText = "0000";

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
}
