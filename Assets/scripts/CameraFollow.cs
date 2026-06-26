using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float damping = 0.5f;
    public float offsetY = 0f;
    public float minY = 0f; // ajuste no Inspector: Y mínimo que a câmera pode chegar

    private float fixedX;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        fixedX = transform.position.x;
    }

    void LateUpdate()
    {
        if (player == null) return;

        float targetY = Mathf.Max(player.position.y + offsetY, minY);
        Vector3 target = new Vector3(fixedX, targetY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, damping);
    }
}