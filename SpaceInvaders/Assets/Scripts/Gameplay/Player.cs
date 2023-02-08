using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Projectile laserPrefab;
    public float speed = 5f;
    private bool _laserActive;
    [SerializeField] private GameManager gameManager;
    private GameStorageContainer storage;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        storage = FindObjectOfType<GameStorageContainer>();
    }

    private void Start()
    {
        speed = storage.PlayerSpeed;

        if (gameManager.isDebugMode == true)
        {
            speed = 20;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (!_laserActive)
        {
            Projectile projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed;
            _laserActive = true;
        }
    }

    private void LaserDestroyed()
    {
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            gameManager.LifeLoss();
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            gameManager.EndGame();
        }
    }
}
