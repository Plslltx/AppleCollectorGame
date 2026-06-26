using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;

    private bool colliding;
    public LayerMask Layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    private bool playerDestroyed;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rig.linearVelocity = new Vector2(speed, rig.linearVelocity.y);
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, Layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.contacts[0].point.y > headPoint.position.y)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                speed = 0f;
                anim.SetTrigger("die");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
            }
            else if (!playerDestroyed)
            {
                playerDestroyed = true;
                GameController.instance.GameOver();
                Destroy(collision.gameObject);
            }
        }
    }
}