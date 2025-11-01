using UnityEngine;

public class ShardSpawnScript : MonoBehaviour
{
    [Header("SPAWN SETTINGS")]
    public GameObject shard;                     // Drag your SHARD PREFAB here
    [Range(0.4f, 1.2f)] public float startSpawnRate = 0.9f;
    [Range(0.2f, 0.8f)] public float minSpawnRate = 0.4f;

    [Header("VR-SAFE SCREEN AREA")]
    public float maxDistance = 6f;               // Max Z spawn
    public float screenWidth = 4f;               // ±2 X
    public float screenHeight = 2f;              // Eye level only

    [Header("PROGRESSIVE DIFFICULTY")]
    public int speedUpEvery = 5;
    public float reduceBy = 0.1f;

    private float timer = 0;
    private float currentRate;
    public static int score = 0;

    void Start()
    {
        currentRate = startSpawnRate;
        SpawnNow(); // First shard immediately
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= currentRate)
        {
            SpawnNow();
            timer = 0;

            // Speed up
            int level = score / speedUpEvery;
            currentRate = Mathf.Max(minSpawnRate, startSpawnRate - level * reduceBy);
        }
    }

    void SpawnNow()
    {
        if (shard == null) { Debug.LogError("Shard prefab missing!"); return; }

        Vector3 pos = new Vector3(
            Random.Range(-screenWidth/2, screenWidth/2),
            Random.Range(0.8f, 1.8f),
            Random.Range(3f, maxDistance)
        );

        Quaternion rot = Quaternion.Euler(0, Random.Range(0f, 360f), 180f);

        GameObject obj = Instantiate(shard, pos, rot);
        // Ensure mover is active
        var mover = obj.GetComponent<ObstacleMover>();
        if (mover) mover.enabled = true;
    }

    public void OnHit()
    {
        score++;
        Debug.Log($"Score: {score} | Next spawn in {currentRate:F2}s");
    }
}