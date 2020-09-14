using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject insideWall;
    [SerializeField]
    private GameObject insideCorner;
    [SerializeField]
    private GameObject outsideWall;
    [SerializeField]
    private GameObject outsideCorner;
    [SerializeField]
    private GameObject tJunction;
    [SerializeField]
    private GameObject sword;
    [SerializeField]
    private GameObject armour;

    // Start is called before the first frame update
    void Start()
    {
        generateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateLevel()
    {

    }
}
