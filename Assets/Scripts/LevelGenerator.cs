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

    private int rowValues = 15;
    private int columnValues = 14;
    GameObject temp;

    int[,] levelMap = new int [,] {
     {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
     {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
     {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
     {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
     {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
     {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
     {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
     {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
     {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
     {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
     {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
     {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
     {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
     {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
     {0,0,0,0,0,0,5,0,0,0,4,0,0,0}
     };

    // Start is called before the first frame update
    void Start()
    {
        generateLevel(1, 1, rowValues, 0, 0, 0, 0);
        generateLevel(1, -1, rowValues - 1, 0, -2, 180, 0);
        generateLevel(-1, 1, rowValues, 1, 0, 0, 180);
        generateLevel(-1, -1, rowValues - 1, 1, -2, 180, 180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateLevel(int xMultiplier, int yMultiplier, int numberOfRows, int xModifier, int yModifier,int xRotationChange, int yRotationChange)
    {
        int currentValue;
        for (int row = 0; row < numberOfRows; ++row)
        {
            for (int column = 0; column < columnValues; ++column)
            {
                currentValue = levelMap[row, column];
                switch (currentValue)
                {
                    case 0:
                        break;
                    case 1:
                        temp = Instantiate(outsideCorner, new Vector2((column - 14 + xModifier) * xMultiplier, (15 - row + yModifier) * yMultiplier), Quaternion.identity);
                        outsideCornerRotate(temp, row, column, xRotationChange, yRotationChange);
                        break;
                    case 2:
                        temp = Instantiate(outsideWall, new Vector2((column - 14 + xModifier) * xMultiplier, (15 - row + yModifier) * yMultiplier), Quaternion.identity);
                        outsideWallRotate(temp, row, column);
                        break;
                    case 3:
                        temp = Instantiate(insideCorner, new Vector2((column - 14 + xModifier) * xMultiplier, (15 - row + yModifier) * yMultiplier), Quaternion.identity);
                        insideCornerRotate(temp, row, column, xRotationChange, yRotationChange);
                        break;
                    case 4:
                        temp = Instantiate(insideWall, new Vector2((column - 14 + xModifier) * xMultiplier, (15 - row + yModifier) * yMultiplier), Quaternion.identity);
                        insideWallRotate(temp, row, column);
                        break;
                    case 5:
                        temp = Instantiate(armour, new Vector2((column - 14 + xModifier) * xMultiplier, (15 - row + yModifier) * yMultiplier), Quaternion.identity);
                        break;
                    case 6:
                        temp = Instantiate(sword, new Vector2((column - 14 + xModifier) * xMultiplier, (15 - row + yModifier) * yMultiplier), Quaternion.identity);
                        break;
                    case 7:
                        temp = Instantiate(tJunction, new Vector2((column - 14 + xModifier) * xMultiplier, (15 - row + yModifier) * yMultiplier), Quaternion.identity);
                        tJunctionRotate(temp, row, column, xRotationChange, yRotationChange);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void insideWallRotate(GameObject wall, int row, int column)
    {
        bool aboveLink = false;
        bool belowLink = false;
        bool rightLink = false;
        bool leftLink = false;

        if (column > 0)
        {
            if (arrayComparer(row, column - 1, 3) || arrayComparer(row, column - 1, 4))
            {
                leftLink = true;
            }
        }
        if (column < columnValues - 1)
        {
            if (arrayComparer(row, column + 1, 3) || arrayComparer(row, column + 1, 4))
            {
                rightLink = true;
            }
        }
        if (row > 0)
        {
            if (arrayComparer(row - 1, column, 3) || arrayComparer(row - 1, column, 4))
            {
                aboveLink = true;
            }
        }
        if (row < rowValues - 1)
        {
            if (arrayComparer(row + 1, column, 3) || arrayComparer(row + 1, column, 4))
            {
                belowLink = true;
            }
        }

        if ((leftLink == true || rightLink == true) && (aboveLink != true || belowLink != true))
        {
            temp.transform.Rotate(0, 0, 90);
        }

    }

    public void insideCornerRotate(GameObject corner, int row, int column, int xRotationChange, int yRotationChange)
    {
        bool aboveLink = false;
        bool bottomLink = false;
        bool leftLink = false;
        bool rightLink = false;
        if (row > 0)
        {
            if (levelMap[row - 1, column] == 4)
            {
                aboveLink = true;
            }
        }
        if (row < rowValues - 1)
        {
            if (levelMap[row + 1, column] == 4)
            {
                bottomLink = true;
            }
        }
        if (column > 0)
        {
            if (levelMap[row, column - 1] == 4)
            {
                leftLink = true;
            }
        }
        if (column < columnValues - 1)
        {
            if (levelMap[row, column + 1] == 4)
            {
                rightLink = true;
            }
        }
        if (aboveLink == true && rightLink == true)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 90);
            return;
        }
        if (bottomLink == true && rightLink == true)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 0);
            return;
        }
        if (bottomLink == true && leftLink == true)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 270);
            return;
        }
        if (aboveLink == true && leftLink == true)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 180);
            return;
        }
        if (row > 0)
        {
            if (levelMap[row - 1, column] == 3)
            {
                aboveLink = true;
            }
        }
        if (row < rowValues - 1)
        {
            if (levelMap[row + 1, column] == 3)
            {
                bottomLink = true;
            }
        }
        if (column > 0)
        {
            if (levelMap[row, column - 1] == 3)
            {
                leftLink = true;
            }
        }
        if (column < columnValues - 1)
        {
            if (levelMap[row, column + 1] == 3)
            {
                rightLink = true;
            }
        }
        if ((aboveLink == true && leftLink == false && rightLink == false) || (aboveLink == true && rightLink == true))
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 90);
            return;
        }
        if (bottomLink == true && rightLink == true)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 0);
            return;
        }
        if (bottomLink == true && leftLink == true)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 270);
            return;
        }
        if (aboveLink == true && leftLink == true)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 180);
            return;
        }

    }

    public void outsideCornerRotate(GameObject corner, int row, int column, int xRotationChange, int yRotationChange)
    {
        bool aboveLink = false;
        bool leftLink = false;
        if (row > 0)
        {
            if (arrayComparer(row - 1, column, 2))
            {
                aboveLink = true;
            }
        }
        if (column > 0)
        {
            if (arrayComparer(row, column - 1, 2))
            {
                leftLink = true;
            }
        }
        if (aboveLink == true && leftLink == true)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 180);
        }
        if (aboveLink == true && leftLink == false)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 90);
        }
        if (aboveLink == false && leftLink == true)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 270);
        }
        if (aboveLink == false && leftLink == false)
        {
            corner.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 0);
        }
    }

    public void outsideWallRotate(GameObject wall, int row, int column)
    {
        if (row > 0)
        {
            if (arrayComparer(row - 1, column, 1) || arrayComparer(row - 1, column, 2))
            {
                temp.transform.Rotate(0, 0, 90);
            }
        }
    }

    public void tJunctionRotate(GameObject junction, int row, int column, int xRotationChange, int yRotationChange)
    {
        
        if (row > 0)
        {
            if (arrayComparer(row - 1, column, 2))
            {
                junction.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 180);
            }
        }
        if (column > 0)
        {
            if (arrayComparer(row, column - 1, 2))
            {
                junction.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 270);
            }
        }
        if (row < rowValues - 1)
        {
            if (arrayComparer(row + 1, column, 2))
            {
                junction.transform.Rotate(0 + xRotationChange, 0 + yRotationChange, 90 );
            }
        }
    }

    public bool arrayComparer(int x, int y, int comparedValue)
    {
        if (levelMap[x, y] == comparedValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
