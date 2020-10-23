using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject redCube;
    [SerializeField]
    GameObject yellowCube;
    [SerializeField]
    GameObject aquaCube;

    private int rowValues = 10;
    private int columnValues = 13;
    private int currentValue;
    GameObject temp;
    private int[,] cubeMap = new int[,]
    {
        {1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1},
        {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
        {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
        {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
        {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        {3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
        {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
        {1, 3, 2, 1, 3, 2, 1, 3, 2, 1, 3, 2, 1},
    };
    // Start is called before the first frame update
    void Start()
    {
        for (int row = 0; row < rowValues; ++row)
        {
            for (int column = 0; column < columnValues; ++column)
            {
                currentValue = cubeMap[row, column];
                switch (currentValue)
                {
                    case 0:
                        break;
                    case 1:
                        temp = Instantiate(yellowCube, new Vector2(column - 6, (row - 4.5f) * -1), Quaternion.identity);
                        break;
                    case 2:
                        temp = Instantiate(redCube, new Vector2(column - 6, (row - 4.5f) * -1), Quaternion.identity);
                        break;
                    case 3:
                        temp = Instantiate(aquaCube, new Vector2(column - 6, (row - 4.5f) * -1), Quaternion.identity);
                        break;
                    default:
                        break;
                }
                temp.transform.parent = gameObject.transform;
            }
        }
    }
}
