using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 8f;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float horizontal = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1f;
        }

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1f;
        }

        rig.linearVelocity = new Vector2(horizontal * Speed, rig.linearVelocity.y);

        if (horizontal > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (horizontal < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!isJumping)
            {
                rig.linearVelocity = new Vector2(rig.linearVelocity.x, 0f);
                rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

                isJumping = true;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                rig.linearVelocity = new Vector2(rig.linearVelocity.x, 0f);
                rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

                doubleJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            doubleJump = false;
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.CompareTag("saw"))
        {
            GameController.instance.GameOver();
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
            anim.SetBool("jump", true);
        }
    }
}