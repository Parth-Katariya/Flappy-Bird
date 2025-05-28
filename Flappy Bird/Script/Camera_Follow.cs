using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform bird;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - bird.position;  // bird postion to camera position -10  [bird position is 0 & camera position is bird position -10]
    }

    void Update()
    {
        var pos = transform.position;
        pos.x = bird.position.x + offset.x;
        transform.position = pos;
    }
}
