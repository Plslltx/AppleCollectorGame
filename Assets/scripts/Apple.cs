using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    private bool collectedByPlayer = false;
    private bool alreadyCollected = false;

    public GameObject collected;
    public int Score;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        GameController.instance.RegisterApple();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (alreadyCollected) return;

        if (collider.CompareTag("Player"))
        {
            // ignora o CircleCollider2D do player, só conta o BoxCollider2D
            if (collider is CircleCollider2D) return;

            alreadyCollected = true;
            collectedByPlayer = true;

            sr.enabled = false;
            circle.enabled = false;
            circle.isTrigger = false;

            collected.SetActive(true);

            GameController.instance.totalScore += Score;
            GameController.instance.AppleCollected();

            Destroy(gameObject, 0.3f);
        }
    }

    void OnDestroy() { }
}