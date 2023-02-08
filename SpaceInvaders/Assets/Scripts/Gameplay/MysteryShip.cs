using UnityEngine;

public class MysteryShip : MonoBehaviour
{
    [SerializeField] private GameObject ship;
    private int speed;

    private bool isLowered;

    private Vector3 _direction = Vector2.right;
    private GameManager gameManager;
    private GameStorageContainer storage;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        storage = FindObjectOfType<GameStorageContainer>();
        ship.transform.position = new Vector3(0, 20, 0);
    }

    private void Start()
    {
        speed = storage.ShipSpeed;
        InvokeRepeating(nameof(ShipThing), 20, 15);
    }

    private void Update()
    {
        ship.transform.position += _direction * this.speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        if (_direction == Vector3.right && ship.transform.position.x >= (rightEdge.x - 1f))
        {
            _direction = Vector3.left;
        }
        else if (_direction == Vector3.left && ship.transform.position.x <= (leftEdge.x + 1f))
        {
            _direction = Vector3.right;
        }
    }

    private void ShipThing()
    {
        if (isLowered)
        {
            ship.transform.position = new Vector3(ship.transform.position.x, 20, 0);
            isLowered = false;
        }
        else if (!isLowered)
        {
            ship.transform.position = new Vector3(ship.transform.position.x, 13, 0);
            isLowered = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            gameManager.Score(storage.ShipKillWorth);
            ship.SetActive(false);
        }
    }
}
