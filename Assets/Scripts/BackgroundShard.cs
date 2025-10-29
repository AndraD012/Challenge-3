using UnityEngine;

public class BackgroundShardBob : MonoBehaviour
{
    [Header("Bobbing Motion Settings")]
    public float floatAmplitude = 1f;   // Height of the bobbing motion
    public float floatSpeed = 1f;       // Speed of bobbing motion

    private Vector3 startPos;
    private float offset;

    void Start()
    {
        // Store the original position so the shard returns to it
        startPos = transform.position;

        // Random offset so all shards don't bob in sync
        offset = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        // Create a smooth up-down motion using sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed + offset) * floatAmplitude;

        // Apply new Y position
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
