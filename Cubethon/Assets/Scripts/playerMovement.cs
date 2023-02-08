using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 1000f;
    public float sidewaysForce = 500f;

    // Start is called before the first frame update
     // void Start() { Debug.Log("Hello World"); }
    
    // FixedUpdate for physics
    void FixedUpdate()
    {
        // Add forward force
        rb.AddForce(0, 0, forwardForce*Time.deltaTime);

        // Right Force
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Left Force
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Checks for y=-1
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().gameEnd();
        }
    }
}
