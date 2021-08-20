using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator anim;
    public BoxCollider2D boxCol;
    public CircleCollider2D circleCol;

    public float movementSpeed;

    public GameObject GOPanel;

    public string nextLevel;

    public GameObject RSPanel;

    public GameObject WNPanel;

    public GameObject QTPanel;

    public Text scoreText;
    int score;

    public AudioClip hitClip, pickUpClip, PortalClip;
    AudioSource audioPlayer;

    //Ladder Variables
    [HideInInspector] public bool canClimb = false;
    [HideInInspector] public bool bottomLadder = false;
    [HideInInspector] public bool topLadder = false;
    private float naturalGravity;
    public Ladder ladder;

    [SerializeField] float climbSpeed = 3f;


    float horizontalMovementSpeed;
    bool isJumping = false;
    bool isHurt = false;


    private Rigidbody2D rb;


    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();

        anim = GetComponent<Animator>();

        controller = GetComponent<CharacterController2D>();

        rb = GetComponent<Rigidbody2D>();


        isJumping = false;
        isHurt = false;

        naturalGravity = rb.gravityScale;


        score = 0;
        GOPanel.SetActive(false);
        RSPanel.SetActive(false);
        WNPanel.SetActive(false);
        QTPanel.SetActive(false);
    }

    void Update()
    {

        scoreText.text = score.ToString();


        horizontalMovementSpeed = Input.GetAxisRaw("Horizontal") * movementSpeed;



        anim.SetFloat("speed", Mathf.Abs(horizontalMovementSpeed));

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
        }


        if (canClimb && Mathf.Abs(Input.GetAxis("Vertical")) > .1f)
        {
            Climb();
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            transform.position = new Vector3(ladder.transform.position.x, rb.position.y);
            //rb.gravityScale = 0f;
            //anim.SetBool("Climb", true);

        }

    }

    public void OnLanding()
    {
        isJumping = false;
        anim.SetBool("isJumping", false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Gem")
        {
            score++;
            Destroy(col.gameObject);
            audioPlayer.PlayOneShot(pickUpClip);
        }



        else if (col.gameObject.tag == "Enemy")
        {
            if (isJumping)
            {
                Destroy(col.gameObject);
                score++;
            }

            else
            {
                anim.SetBool("isHurt", true);
                Time.timeScale = 0;
                //Destroy(this.gameObject);
                GOPanel.SetActive(true);
                RSPanel.SetActive(true);
                QTPanel.SetActive(true);
                audioPlayer.PlayOneShot(hitClip);

            }
        }

        else if (col.gameObject.tag == "Win")
        {
            /* Time.timeScale = 0;
             WNPanel.SetActive(true);
             RSPanel.SetActive(true);
             QTPanel.SetActive(true); */

            /*audioPlayer.PlayOneShot(PortalClip);
            StartCoroutine(loadNextLevel()); */
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        }

        else if (col.gameObject.tag == "GoToLevel1")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    IEnumerator loadNextLevel()
    {
        yield return new WaitForSeconds(5);

    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quits()
    {
        Application.Quit();
    }

    void FixedUpdate()
    {
        //Movement
        controller.Move(horizontalMovementSpeed * Time.fixedDeltaTime, false, isJumping);


    }

    private void Climb()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            canClimb = false;
            isJumping = true;
            anim.SetBool("isJumping", true);
        }

        float vDirection = Input.GetAxis("Vertical");

        //Climbing Up
        if (vDirection > .1f && !topLadder)
        {
            rb.velocity = new Vector2(0f, vDirection * climbSpeed);
        }

        //Climbing Down
        else if (vDirection > -.1f && !bottomLadder)
        {
            rb.velocity = new Vector2(0f, vDirection * climbSpeed);

        }
        //Still
        else
        {

        }
    }
}