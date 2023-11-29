using MongoDB.Bson.Serialization.Serializers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class HatchAnimManager : MonoBehaviour
{
    public Animator animator;

    public GameObject hatchButton;

    public GameObject selectionTileMap;
    public GameObject nameTileMap;
    public GameObject selectionUI;
    public GameObject nameUI;

    // Start is called before the first frame update
    void Start()
    {
        this.hatchButton.GetComponent<Button>().onClick.AddListener(StartHatchAnimation);
        //this.animator.SetTrigger("hatchIdle");
    }

    public void StartHatchAnimation()
    {
        animator.SetTrigger("hatch");
    }

    public void LoadName()
    {
        this.selectionTileMap.SetActive(false);
        this.selectionUI.SetActive(false);
        this.nameTileMap.SetActive(true);
        this.nameUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
