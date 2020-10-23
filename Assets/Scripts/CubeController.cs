using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private Material redMaterial;
    [SerializeField]
    private Material aquaMaterial;
    [SerializeField]
    private Material yellowMaterial;
    [SerializeField]
    string cubeColour;
    private float timer;
    private int lastTime;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        ResetTime();
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > lastTime + 1)
        {
            lastTime = (int)timer;
            if (cubeColour.Equals("yellow"))
            {
                ChangeColourYellow();
            }
            if (cubeColour.Equals("red"))
            {
                ChangeColourRed();
            }
            if (cubeColour.Equals("aqua"))
            {
                ChangeColourAqua();
            }
        }
        if (lastTime == 3)
        {
            ResetTime();
        }
    }

    private void ChangeColourYellow()
    {
        Debug.Log(lastTime);
        if (lastTime % 3 == 0)
        {
            renderer.material = yellowMaterial;
            return;
        }
        if (lastTime % 2 == 0)
        {
            renderer.material = aquaMaterial;
            return;
        }
        if (lastTime % 1 == 0)
        {
            renderer.material = redMaterial;
            return;
        }
    }

    private void ChangeColourRed()
    {
        if (lastTime % 3 == 0)
        {
            renderer.material = redMaterial;
            return;
        }
        if (lastTime % 2 == 0)
        {
            renderer.material = yellowMaterial;
            return;
        }
        if (lastTime % 1 == 0)
        {
            renderer.material = aquaMaterial;
            return;
        }
    }

    private void ChangeColourAqua()
    {
        if (lastTime % 3 == 0)
        {
            renderer.material = aquaMaterial;
            return;
        }
        if (lastTime % 2 == 0)
        {
            renderer.material = redMaterial;
            return;
        }
        if (lastTime % 1 == 0)
        {
            renderer.material = yellowMaterial;
            return;
        }
    }

    private void ResetTime()
    {
        timer = 0;
        lastTime = 0;
    }

}
