using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;
    public BoolArrVariable playersAreAlive;

    // Components
    private Rigidbody2D laserBody;
    //private AudioSource audioSource;
    //public AudioClip hitAudio;

    // Physics
    public float aimAngle;
    public Vector2 movement;

    // Game state
    public int srcPlayerID;
    public float damage;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onLaserCastPlaySound;
    public GameEvent onLaserHitPlaySound;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        laserBody = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        // Get constants
        damage = gameConstants.laserDamage;
        // Laser movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        laserBody.AddForce(movement * gameConstants.laserSpeed, ForceMode2D.Impulse);
        transform.Rotate(0f,0f,aimAngle);
        onLaserCastPlaySound.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, gameConstants.laserDestroyTime);
    }

    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            int dstPlayerID = other.gameObject.GetComponent<BattleController>().playerID;
            if (srcPlayerID != dstPlayerID) {
                // Debug.Log("Collided with other player!");
                if (!playersAreAlive.GetValue(dstPlayerID)) {
                    return;
                }
                float knockback = playersKnockback.GetValue(dstPlayerID);
                float forceMultiplier = gameConstants.laserForce * (gameConstants.knockbackInitial + gameConstants.knockbackMultiplier * Mathf.Log(knockback + 1));
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * forceMultiplier, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                //audioSource.Stop();
                //AudioSource.PlayClipAtPoint(hitAudio, new Vector3(0, 0, 0));
                onLaserHitPlaySound.Raise();
                Destroy(gameObject);
            }
        }
        // hits other spells or obstacles and spells destroys itself
        // if (other.gameObject.tag == "Spell" || other.gameObject.tag == "Obstacle") {
        //     Destroy(gameObject);
        // }
        if (other.gameObject.tag == "Obstacle") {
            Destroy(gameObject);
        }
    }
}
