using UnityEngine;

/// <summary>
/// Event handler for Orb objects
/// </summary>
public class Orb : MonoBehaviour
{
    /// <summary>
    /// If this gets called, then we're off screen
    /// So destroy ourselves
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnBecameInvisible()
    {
        // TODO
        Orb.Destroy(gameObject);
    }

    /// <summary>
    /// If this is called, then we hit something
    /// Destroy ourselves unless the thing we hit was another Orb.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO
        //print($"{collision.collider}");
        if (collision.collider.gameObject.GetComponent<Orb>() == null)
        {
            Orb.Destroy(gameObject);
        }

    }
}
