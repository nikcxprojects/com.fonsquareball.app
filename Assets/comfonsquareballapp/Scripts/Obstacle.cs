using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private const float speed = 4.0f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }
}
