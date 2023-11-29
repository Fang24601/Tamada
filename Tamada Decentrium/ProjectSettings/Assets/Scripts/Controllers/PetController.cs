using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PetController : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    

    public Animator petAnimator;

    private Vector3 destination;
    public float speed;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, this.destination) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        }
    }

    public void SetAnimator(Animator animator)
    {
        this.petAnimator = animator;
    }
    public void SetSprite(Sprite sprite)
    {
        Debug.Log("Setting sprite");
        if (this.spriteRenderer == null) return;
        this.spriteRenderer.sprite = sprite;
    }

    public void Move(Vector3 destination)
    {
        this.destination = destination;
    }

    /*
     * Use when 75+ value for each attribute
     */
    public void Happy()
    {
        // petAnimator.SetTrigger("Happy");
    }
    /*
     * Use when 25 - 50
     */
    public void Neutral()
    {
        // petAnimator.SetTrigger("Neutral");
    }

    /*
     * Use when 25- value for each attribute
     */
    public void Sad()
    {
        // petAnimator.SetTrigger("Sad");
    }

}
