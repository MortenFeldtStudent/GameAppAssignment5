using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    public GameObject playerText;
    public Animator animator;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] public int a = 100;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        playerText.GetComponent<Text>().text = "Timer: " + a;
        StartCoroutine(PlayerCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 60f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            animator.SetBool("IsJumping", true);
        }

        if(IsGrounded()) HandleMovement();

        if (a == 0)
        {
            playerText.GetComponent<Text>().text = "Game Over!";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    bool IsGrounded()
    {
        animator.SetBool("IsJumping", false);
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * .1f, layerMask);
        return raycastHit2d.collider != null;
    }

    void HandleMovement()
    {
        float moveSpeed = 10f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetFloat("Speed", 10f);
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
        } else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetFloat("Speed", 10f);
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
            } else
            {
                animator.SetFloat("Speed", 0f);
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            }
        }
    }

    IEnumerator PlayerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            a = a - 1;
            playerText.GetComponent<Text>().text = "Timer: " + a;
        }
    }

}
