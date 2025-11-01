using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [Header("MOVEMENT")]
    public float moveSpeed = 12f;           // Speed toward player
    public float destroyDistance = -3f;     // Destroy when too close

    [Header("SPINNING")]
    public float spinSpeedX = 800f;
    public float spinSpeedY = 600f;
    public float spinSpeedZ = 400f;

    [Header("RANDOM SIZE")]
    public Vector3 minScale = new Vector3(0.005f, 0.005f, 0.015f);
    public Vector3 maxScale = new Vector3(0.01f,  0.01f,  0.03f);

    void Start()
    {
        // RANDOM SIZE
        Vector3 scale = new Vector3(
            Random.Range(minScale.x, maxScale.x),
            Random.Range(minScale.y, maxScale.y),
            Random.Range(minScale.z, maxScale.z)
        );
        transform.localScale = scale;

        // RANDOM SPIN
        spinSpeedX = Random.Range(500f, 1200f);
        spinSpeedY = Random.Range(400f, 900f);
        spinSpeedZ = Random.Range(200f, 700f);
    }

    void Update()
    {
        // MOVE TOWARD PLAYER (negative Z)
        transform.position += Vector3.back * moveSpeed * Time.deltaTime;

        // SPIN
        transform.Rotate(spinSpeedX * Time.deltaTime, spinSpeedY * Time.deltaTime, spinSpeedZ * Time.deltaTime);

        // DESTROY
        if (transform.position.z < destroyDistance)
            Destroy(gameObject);
    }
}