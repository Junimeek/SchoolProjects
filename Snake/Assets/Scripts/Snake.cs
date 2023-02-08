using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.zero;
    public List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize;
    private Vector2 input;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (_direction.x == 0f && _direction.y == 0f)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                input = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                input = Vector2.down;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                input = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                input = Vector2.right;
            }
        }

        // Only allow turning up or down while moving in the x-axis
        if (_direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                input = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                input = Vector2.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (_direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                input = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                input = Vector2.left;
            }
        }
    }

    private void FixedUpdate()
    {
        if (input != Vector2.zero)
        {
            _direction = input;
        }

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            FindObjectOfType<GameManager>().UpdateScore();
        }
        else if (other.tag == "Obstacle")
        {
            ResetState();
            FindObjectOfType<GameManager>().UpdateScore();
        }
    }

    private void ResetState()
    {
        _direction = Vector2.zero;
        input = Vector2.zero;

        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
        
    }

    public bool Occupies(float x, float y)
    {
        foreach (Transform segment in _segments)
        {
            if (segment.position.x == x && segment.position.y == y)
            {
                return true;
            }
        }

        return false;
    }
}
