using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float deadZoneX = 1.5f;
    public float deadZoneY = 1.5f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position;

        float moveX = 0;
        float moveY = 0;

        if (Mathf.Abs(targetPos.x - currentPos.x) > deadZoneX)
            moveX = targetPos.x - currentPos.x;

        if (Mathf.Abs(targetPos.y - currentPos.y) > deadZoneY)
            moveY = targetPos.y - currentPos.y;

        Vector3 newPosition = new Vector3(
            currentPos.x + moveX,
            currentPos.y + moveY,
            -10
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            newPosition,
            ref velocity,
            0.2f
        );
    }
}