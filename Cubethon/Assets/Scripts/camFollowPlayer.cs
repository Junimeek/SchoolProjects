using UnityEngine;

public class camFollowPlayer : MonoBehaviour
{
    public Transform player; // Checks player pos
    public Vector3 offset; // XYZ "Offset" in editor

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset; // Player pos + Cam Offset
    }
}
