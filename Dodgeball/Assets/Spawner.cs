using UnityEngine;

/// <summary>
/// Periodically spawns the specified prefab in a random location.
/// </summary>
public class Spawner : MonoBehaviour
{
    /// <summary>
    /// Object to spawn
    /// </summary>
    public GameObject Prefab;

    /// <summary>
    /// Seconds between spawn operations
    /// </summary>
    public float SpawnInterval = 2;

    /// <summary>
    /// How many units of free space to try to find around the spawned object
    /// </summary>
    public float FreeRadius = 10;

    /// <summary>
    /// Check if we need to spawn and if so, do so.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    float localTime = 0;

    void Update()
    {
        // TODO
        if (Time.time > localTime)
        {
            var spawnpoint = SpawnUtilities.RandomFreePoint(FreeRadius);
            Instantiate(Prefab, spawnpoint, Quaternion.identity, Canvas.FindObjectOfType<Spawner>().transform);
            localTime += SpawnInterval;
        }
    }
}
