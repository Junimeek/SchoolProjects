using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;
    private GameStorageContainer storage;

    private void Awake()
    {
        storage = FindObjectOfType<GameStorageContainer>();
    }

    private void Update()
    {
        if (gameObject.name == "Missile(Clone)")
        {
            this.transform.position += this.direction * storage.MissileSpeed * Time.deltaTime;
        }
        else if (gameObject.name == "Laser(Clone)")
        {
            this.transform.position += this.direction * storage.LaserSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.destroyed != null)
        {
            this.destroyed.Invoke();
        }
            
        Destroy(this.gameObject);
    }
}
