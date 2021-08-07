using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAttackController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;
    public BoolArrVariable playersAreAlive;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onIceAttackCastPlaySound;
    public GameEvent onIceAttackHitPlaySound;

    // Components
    private Rigidbody2D iceBody;

    // Physics
    public float aimAngle;
    public Vector2 movement;

    // Game state
    public int srcPlayerID;
    public float damage;

    public Vector2 knockbackPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        iceBody = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        // Get constants
        damage = gameConstants.iceAttackDamage;
        // Fireball movement
        //movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle) * gameConstants.fireballDistance, Mathf.Cos(Mathf.Deg2Rad * aimAngle) * gameConstants.fireballDistance);
        //fireballBody.AddForce(movement * gameConstants.fireballSpeed, ForceMode2D.Impulse);
        // Fireball instantiation
        iceBody.transform.position = new Vector3(transform.position.x - Mathf.Sin(Mathf.Deg2Rad * aimAngle) * gameConstants.iceAttackDistance, 
                                                        transform.position.y + Mathf.Cos(Mathf.Deg2Rad * aimAngle) * gameConstants.iceAttackDistance, 
                                                        transform.position.z);
        transform.Rotate(0f,0f,aimAngle+90f);
        onIceAttackCastPlaySound.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = iceBody.transform.position;
        Destroy(gameObject, gameConstants.iceAttackDestroyTime);
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
                float forceMultiplier = gameConstants.iceAttackForce * (gameConstants.knockbackInitial + gameConstants.knockbackMultiplier * Mathf.Log(knockback + 1));
                knockbackPosition = other.transform.position - transform.position;
                knockbackPosition.Normalize();
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackPosition * forceMultiplier, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                onIceAttackHitPlaySound.Raise();
                //Destroy(gameObject);
            }
        }
        // // hits obstacles and spells destroys itself
        // if (other.gameObject.tag == "Obstacle") {
        //     Destroy(gameObject);
        // }
    
}
}