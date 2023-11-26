using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 3.5f;
    private float jumpingPower = 7;
    private bool isFacingRight = true;
    public Checkpoints checkpoint;
    private Vector3 respawnPoint;
    public Animator animator;
    public int energyBars = 3;
    public gameOver GameOverHandler;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject redFloor;
    [SerializeField] private GameObject redCollision;

    [SerializeField] private GameObject blueFloor;
    [SerializeField] private GameObject blueCollision;

    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject jumpArrow;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            AudioManager.Instance.playSFX("Jump");
            Invoke("Landing", 1f);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetButtonDown("Horizontal") && IsGrounded())
        {
            if (SceneManager.GetActiveScene().name == "Tutorial" || SceneManager.GetActiveScene().name == "level1")
            {
                AudioManager.Instance.playSFX("MoveBricks");
                AudioManager.Instance.sfxSource.loop = true;
            }
            else
            {
                AudioManager.Instance.playSFX("MoveForest");
                AudioManager.Instance.sfxSource.loop = true;
            }

        }
        if (Input.GetButtonUp("Horizontal") && IsGrounded())
        {
            Invoke("moveStop", 0.25F);
        }
        if (IsGrounded())
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }
        Flip();

    }

    public void Landing()
    {
        AudioManager.Instance.landAudio();
    }
    public void moveStop()
    {
        AudioManager.Instance.sfxSource.Stop();
        AudioManager.Instance.sfxSource.loop = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Red")
        {
            redFloor.SetActive(true);
            redCollision.SetActive(false);
        }
        else
        {
            redFloor.SetActive(false);
            redCollision.SetActive(true);
        }
        if (collision.tag == "Blue")
        {
            blueFloor.SetActive(true);
            blueCollision.SetActive(false);
        }
        else
        {
            blueFloor.SetActive(false);
            blueCollision.SetActive(true);
        }
        //currently doesn't work but with a delayed death / death screen it should resolve issue
        if (collision.tag == "Death")
        {
            energyBars --;

            if (energyBars <= 0)
            {
                gameOver();
            }
            else
            {
                respawnPoint = GameObject.Find("CheckpointCollision").GetComponent<Checkpoints>().respawnPoint;

                transform.position = respawnPoint;
            }
        }
        if (collision.tag == "horizontal")
        {
            rightArrow.SetActive(false);
            leftArrow.SetActive(false);
        }
        if (collision.tag == "jump")
        {
           jumpArrow.SetActive(false);
        }
    }
    public void gameOver()
    {
        GameOverHandler.Setup();
    }
}
