using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;
    public BoolArrVariable playersAreAlive;

    // Components
    private Rigidbody2D fireballBody;

    // Physics
    public float aimAngle;
    public Vector2 movement;

    // Game state
    public int srcPlayerID;
    public int spellLevel;
    public float damage;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onFireballCastPlaySound;
    public GameEvent onFireballHitPlaySound;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        fireballBody = GetComponent<Rigidbody2D>();
        // Get constants
        damage = gameConstants.fireballDamage;
        // Fireball movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        fireballBody.AddForce(movement * gameConstants.fireballSpeed, ForceMode2D.Impulse);
        onFireballCastPlaySound.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, gameConstants.fireballDestroyTime);
    }

    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            int dstPlayerID = other.gameObject.GetComponent<BattleController>().playerID;
            if (srcPlayerID != dstPlayerID) {
                if (!playersAreAlive.GetValue(dstPlayerID)) {
                    return;
                }
                float knockback = playersKnockback.GetValue(dstPlayerID);
                float forceMultiplier = gameConstants.fireballForce * (gameConstants.knockbackInitial + gameConstants.knockbackMultiplier * Mathf.Log(knockback + 1));
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * forceMultiplier, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                onFireballHitPlaySound.Raise();
                Destroy(gameObject);
            }
        }
        // // hits other spells or obstacles and spells destroys itself
        // if (other.gameObject.tag == "Spell" || other.gameObject.tag == "Obstacle") {
        //     Destroy(gameObject);
        // }
        if (other.gameObject.tag == "Obstacle") {
            Destroy(gameObject);
        }
    }
}
