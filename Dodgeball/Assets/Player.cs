using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Animations;

/// <summary>
/// Control the player on screen
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    /// <summary>
    /// Prefab for the orbs we will shoot
    /// </summary>
    public GameObject OrbPrefab;

    /// <summary>
    /// How fast our engines can accelerate us
    /// </summary>
    public float EnginePower = 1;
    
    /// <summary>
    /// How fast we turn in place
    /// </summary>
    public float RotateSpeed = 1;

    /// <summary>
    /// How fast we should shoot our orbs
    /// </summary>
    public float OrbVelocity = 10;
    /// <summary>
    /// Start the game by creating a Rigidbody2D
    /// </summary>
    /// 
    public Rigidbody2D Rigidbody;
    private void Start()
    {
        //TODO
        Rigidbody = GetComponent<Rigidbody2D>();
    }
    /// <summary>
    /// Handle moving and firing.
    /// Called by Uniity every 1/50th of a second, regardless of the graphics card's frame rate
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void FixedUpdate()
    {
        Manoeuvre();
        MaybeFire();
    }

    /// <summary>
    /// Fire if the player is pushing the button for the Fire axis
    /// Unlike the Enemies, the player has no cooldown, so they shoot a whole blob of orbs
    /// </summary>
    void MaybeFire()
    {
        // TODO
        if (Input.GetAxis("Fire") == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                FireOrb();
            }
        }
    }

    /// <summary>
    /// Fire one orb.  The orb should be placed one unit "in front" of the player.
    /// transform.right will give us a vector in the direction the player is facing.
    /// It should move in the same direction (transform.right), but at speed OrbVelocity.
    /// </summary>
    private void FireOrb()
    {
        // TODO
        var playerpos = new Vector2(Rigidbody.transform.localPosition.x + transform.right.x, Rigidbody.transform.localPosition.y + transform.right.y);
        var orb = Instantiate(OrbPrefab, playerpos, Quaternion.identity, Rigidbody.transform);
        orb.GetComponent<Rigidbody2D>().velocity = Rigidbody.transform.right * OrbVelocity;
       
    }

    /// <summary>
    /// Accelerate and rotate as directed by the player
    /// Apply a force in the direction (Horizontal, Vertical) with magnitude EnginePower
    /// Note that this is in *world* coordinates, so the direction of our thrust doesn't change as we rotate
    /// Set our angularVelocity to the Rotate axis time RotateSpeed
    /// </summary>
    void Manoeuvre()
    {
        // TODO
        var force = new Vector2(Input.GetAxis("Horizontal") * EnginePower, Input.GetAxis("Vertical") * EnginePower);

        Rigidbody.AddForce(force);
        Rigidbody.angularVelocity = Input.GetAxis("Rotate") * RotateSpeed;

    }

    /// <summary>
    /// If this is called, we got knocked off screen.  Deduct a point!
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void OnBecameInvisible()
    {
        ScoreKeeper.ScorePoints(-1);
    }
}
