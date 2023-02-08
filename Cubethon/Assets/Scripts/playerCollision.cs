using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public playerMovement movement; // Reference to PlayerMovement script
    
    // On collision with another object
    void OnCollisionEnter(Collision collisionInfo) // Checks for tag "Obstacle"
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false; // Disable movement
            FindObjectOfType<GameManager>().gameEnd(); // Runs gameEnd in GameManager
        }
    }
}
