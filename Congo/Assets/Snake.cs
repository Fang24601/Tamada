using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //Vector2 has a float X and Y which allows movement for up and down
    //Setting our direction to .right defaults movement to the right.
    private Vector2 direction = Vector2.right;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public int initialSize = 2;
    public Animator anim;
    public int playerScore = 0;
    private void Start()
    {
        anim = GetComponent<Animator>();
        //Create first segment of the snake and create a list
        _segments = new List<Transform>();
        _segments.Add(this.transform);
        ResetState();
    }

    //Update is called every frame the game is running (common for input)
    private void Update()
    {
        processMovement();
        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
    }

    private void processMovement()
    {
        //Create player input and mapping keys
        if(Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
    }

    //Not called every frame, useful for physics so Bethesda tier movement doesnt happen
    private void FixedUpdate()
    {
        //Segments are added to the last
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i-1].position;
        }
        //Create vector movement for x,y,z movement.
        //Speed of the snake is not handled here, instead is in Project Settings>Time>FixedTimestep
        this.transform.position = new Vector3(
            //Mathf.Round to round to nearest whole number for grid-like movement
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        //Instantiate new segment, add to last spot in the list
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void ResetState()
    {
        //Delete segments of snake
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        //Clear list in memory
        _segments.Clear();
        //Add initial segment
        _segments.Add(this.transform);
        //Set score back to 0;
        playerScore = 0;

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }        
        //Place segment at position 0,0,0
        this.transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        if (other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
