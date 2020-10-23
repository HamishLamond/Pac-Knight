using System.Collections;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    private Tweener tweener;
    private string lastInput;
    private Vector3 leftMovement = new Vector3(-1, 0);
    private Vector3 upMovement = new Vector3(0, 1);
    private Vector3 rightMovement = new Vector3(1, 0);
    private Vector3 downMovement = new Vector3(0, -1);
    private Vector3 movement;
    private Vector3 destination;
    [SerializeField]
    private float speed = 0.5f;
    private GameObject[] walls;
    private GameObject[] pellets;
    private GameObject[] powerPellets;
    private bool wallCollisionDetected;
    private bool pelletCollisionDetected;
    private bool powerPelletCollisionDetected;
    [SerializeField]
    private ObjectSoundPlayer soundPlayer;
    [SerializeField]
    private Animator animator;
    private string moveDirection;
    [SerializeField]
    private ParticleSystem dirtTrail;


    // Start is called before the first frame update
    void Start()
    {
        dirtTrail.Stop();
        tweener = gameObject.GetComponent<Tweener>();
        wallCollisionDetected = false;
        pelletCollisionDetected = false;
        powerPelletCollisionDetected = false;
        StartCoroutine(ExecuteAfterTime(0.0001f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            lastInput = "w";
            movement = upMovement;
            moveDirection = "moveUp";
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastInput = "a";
            movement = leftMovement;
            moveDirection = "moveLeft";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            lastInput = "s";
            movement = downMovement;
            moveDirection = "moveDown";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lastInput = "d";
            movement = rightMovement;
            moveDirection = "moveRight";
        }
        if (lastInput != null)
        {
            destination = transform.position + movement;
            wallCollisionDetected = false;
            pelletCollisionDetected = false;
            powerPelletCollisionDetected = false;
            foreach (GameObject wall in walls)
            {
                if (destination == wall.transform.position)
                {
                    wallCollisionDetected = true;
                }
            }
            foreach (GameObject pellet in pellets)
            {
                if (destination == pellet.transform.position)
                {
                    pelletCollisionDetected = true;
                }
            }
            foreach (GameObject powerPellet in powerPellets)
            {
                if (destination == powerPellet.transform.position)
                {
                    powerPelletCollisionDetected = true;
                }
            }
            if (wallCollisionDetected == false)
            {
                if (tweener.AddTween(transform, transform.position, destination, speed))
                {
                    dirtTrail.Play();
                    if (powerPelletCollisionDetected || pelletCollisionDetected)
                    {
                        soundPlayer.PlaySound(1);
                    }
                    else
                    {
                        soundPlayer.PlaySound(0);
                    }
                    SetMovementTrigger(moveDirection);
                }
            }
            else
            {
                dirtTrail.Stop();
                soundPlayer.StopSound();
                RemoveMovementTriggers();
            }
        }
        //if (gameObject.transform.position == topLeftPosition)
        //{
        //    tweener.AddTween(gameObject.transform, gameObject.transform.position, topRightPosition, 2.5f);
        //}
        //if (pacKnight.transform.position == topRightPosition)
        //{
        //    tweener.AddTween(gameObject.transform, gameObject.transform.position, bottomRightPosition, 2f);
        //}
        //if (pacKnight.transform.position == bottomRightPosition)
        //{
        //    tweener.AddTween(gameObject.transform, gameObject.transform.position, bottomLeftPosition, 2.5f);
        //}
        //if (pacKnight.transform.position == bottomLeftPosition)
        //{
        //    tweener.AddTween(gameObject.transform, gameObject.transform.position, topLeftPosition, 2f);
        //}
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        walls = GameObject.FindGameObjectsWithTag("Wall");
        pellets = GameObject.FindGameObjectsWithTag("Pellet");
        powerPellets = GameObject.FindGameObjectsWithTag("Power Pellet");
    }

    private void RemoveMovementTriggers()
    {
        animator.SetBool("moveRight", false);
        animator.SetBool("moveLeft", false);
        animator.SetBool("moveUp", false);
        animator.SetBool("moveDown", false);
    }

    private void SetMovementTrigger(string direction)
    {
        RemoveMovementTriggers();
        animator.SetBool(direction, true);
    }
}
