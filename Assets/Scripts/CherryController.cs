using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private GameObject cherrySprite;
    private GameObject spawnedCherry;
    private Camera camera;
    private float halfCameraWidth;
    private bool cherryExists;
    private Tweener cherryTweener;
    private Vector3 cherrySpawnPosition;
    private Vector3 cherryDestoryPosition;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        halfCameraWidth = camera.aspect * camera.orthographicSize;
        cherrySpawnPosition = new Vector3(halfCameraWidth + 1, 1);
        cherryDestoryPosition = new Vector3(-halfCameraWidth - 1, 1);
        timer = 0;
        cherryExists = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 30)
        {
            Debug.Log("workshere");
            CreateCherry();
            timer = 0;
        }
        if (cherryExists)
        {
            MoveCherry();
            if (spawnedCherry.transform.position == cherryDestoryPosition)
            {
                Destroy(spawnedCherry);
                cherryExists = false;
            }
        }
    }

    private void CreateCherry()
    {
        spawnedCherry = Instantiate(cherrySprite, cherrySpawnPosition, Quaternion.identity);
        spawnedCherry.transform.parent = gameObject.transform;
        cherryExists = true;
        cherryTweener = spawnedCherry.GetComponent<Tweener>();
    }

    private void MoveCherry()
    {
        if (cherryTweener != null)
        {
            cherryTweener.AddTween(spawnedCherry.transform, spawnedCherry.transform.position, cherryDestoryPosition, 10.0f);
        }
    }

}
