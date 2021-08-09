using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGroundController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;

    // Components
    private Rigidbody2D mineGroundBody;
    public GameObject explosion;

    // Physics
    public float aimAngle;
    public Vector2 movement;

    // Game state
    public int srcPlayerID;
    public int spellLevel;

    public float damage;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onMineHitPlaySound;
    public GameEvent onMineLandPlaySound;


    void Start()
    {
        //GET
        mineGroundBody = GetComponent<Rigidbody2D>();
        damage = gameConstants.mineGroundDamage;
        transform.Rotate(0f,0f,aimAngle);
        onMineLandPlaySound.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, gameConstants.mineGroundDestroyTime);
    }

    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            int dstPlayerID = other.gameObject.GetComponent<BattleController>().playerID;
            if (srcPlayerID != dstPlayerID) {
                float knockback = playersKnockback.GetValue(dstPlayerID);
                float forceMultiplier = gameConstants.mineGroundForce * (gameConstants.knockbackInitial + gameConstants.knockbackMultiplier * Mathf.Log(knockback + 1));
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * forceMultiplier, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                Instantiate(explosion, transform.position, Quaternion.identity);
                onMineHitPlaySound.Raise();
                Destroy(gameObject);
            }
        }
        // if (other.gameObject.tag == "Spell") {
        //     Instantiate(explosion, transform.position, Quaternion.identity);
        //     Destroy(other.gameObject);
        //     Destroy(this.gameObject);
        // }
    }
}
