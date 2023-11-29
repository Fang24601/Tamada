using MongoDB.Bson.Serialization.Serializers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class HatchAnimManager : MonoBehaviour
{
    public GameObject animObject;
    public Animator animator;

    public GameObject selectionTileMap;
    public GameObject nameTileMap;
    public GameObject selectionUI;
    public GameObject nameUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadName()
    {
        animObject.SetActive(false);

        this.nameTileMap.SetActive(true);
        this.nameUI.SetActive(true);
        this.selectionTileMap.SetActive(false);
        this.selectionUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
