using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningProjectileController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;

    // Components
    private Rigidbody2D lightningProjectileBody;
    //private AudioSource audioSource;
    //public AudioClip hitAudio;

    // Physics
    public float aimAngle;
    public Vector2 movement;

    // Game state
    public int srcPlayerID;
    public float damage;

    // Sound Events

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        lightningProjectileBody = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        // Get constants
        damage = gameConstants.lightningProjectileDamage;
        // LightningProjectile movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        lightningProjectileBody.AddForce(movement * gameConstants.lightningProjectileSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, gameConstants.lightningProjectileDestroyTime);
    }

    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            int dstPlayerID = other.gameObject.GetComponent<BattleController>().playerID;
            if (srcPlayerID != dstPlayerID) {
                // Debug.Log("Collided with other player!");
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * gameConstants.lightningProjectileSpeed * gameConstants.lightningProjectileForce, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                Destroy(gameObject);
            }
    
        }
        // hits other spells and it destroy sitself
        if (other.gameObject.tag == "Spell") {
            Destroy(gameObject);
        }
    }
}
