using UnityEngine;

public class ShardLookAt : MonoBehaviour
{
    public Transform player;  // The viewer or player to face

    void Update()
    {
        if (player == null) return;

        // Always face the player (camera or player transform)
        transform.LookAt(player);
    }
}
