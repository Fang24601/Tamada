using UnityEngine;

public class Food : MonoBehaviour
{
    //Creates a public (shows in editor) variable allowing us to 
    //reference the Grid Area object in the inspector for food
    public BoxCollider2D gridArea;

    //Start is called at the first frame of the game.
    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        //Creates a Bounds variable named bounds of the gridArea selected
        Bounds bounds = this.gridArea.bounds;
        //Generate random location 
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        //Assign food coordinates to our rounded vector coordinates defined above; z set to 0
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    //Function automatically called when triggered (on 2D collider)
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Tag is set in the Snake's object Inspector
        //If statement checks to make sure the player is what hits the food
        if (other.tag == "Player")
        {
            RandomizePosition();
        }
    }
}
