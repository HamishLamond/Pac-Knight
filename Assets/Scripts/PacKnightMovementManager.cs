using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacKnightMovementManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pacKnight;
    private Tweener tweener;
    private Vector3 topLeftPosition = new Vector3(-13, 14, 0);
    private Vector3 topRightPosition = new Vector3(-8, 14, 0);
    private Vector3 bottomLeftPosition = new Vector3(-13, 10);
    private Vector3 bottomRightPosition = new Vector3(-8, 10);

    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pacKnight.transform.position);
        if (pacKnight.transform.position == topLeftPosition)
        {
            tweener.AddTween(pacKnight.transform, pacKnight.transform.position, topRightPosition, 2.5f);
        }
        if (pacKnight.transform.position == topRightPosition)
        {
            tweener.AddTween(pacKnight.transform, pacKnight.transform.position, bottomRightPosition, 2f);
        }
        if (pacKnight.transform.position == bottomRightPosition)
        {
            tweener.AddTween(pacKnight.transform, pacKnight.transform.position, bottomLeftPosition, 2.5f);
        }
        if (pacKnight.transform.position == bottomLeftPosition)
        {
            tweener.AddTween(pacKnight.transform, pacKnight.transform.position, topLeftPosition, 2f);
        }
    }
}
