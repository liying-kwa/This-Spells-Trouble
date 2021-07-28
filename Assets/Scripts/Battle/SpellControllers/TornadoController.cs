using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;
    public BoolArrVariable playersAreAlive;

    // Components
    private Rigidbody2D tornadoBody;
   
    // Physics
    public float aimAngle;
    public Vector2 movement;

    // Game state
    public int srcPlayerID;
    public float damage;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onTornadoCastPlaySound;
    public GameEvent onTornadoHitPlaySound;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        tornadoBody = GetComponent<Rigidbody2D>();
        // Get constants
        damage = gameConstants.tornadoDamage;
        // Tornado movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        tornadoBody.AddForce(movement * gameConstants.tornadoSpeed, ForceMode2D.Impulse);
        onTornadoCastPlaySound.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, gameConstants.tornadoDestroyTime);
    }

    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            int dstPlayerID = other.gameObject.GetComponent<BattleController>().playerID;
            if (srcPlayerID != dstPlayerID) {
                if (!playersAreAlive.GetValue(dstPlayerID)) {
                    return;
                }
                float knockback = playersKnockback.GetValue(dstPlayerID);
                float forceMultiplier = gameConstants.tornadoForce * (gameConstants.knockbackInitial + gameConstants.knockbackMultiplier * Mathf.Log(knockback + 1));
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * forceMultiplier, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                // Tornado doesn't destroy itself when hit with other players
                onTornadoHitPlaySound.Raise();
                // Destroy(gameObject);
            }
    
        }
        // when tornado hits other spells it destroys other spells but not itself
        if (other.gameObject.tag == "Spell") {
            Destroy(other.gameObject);
        }
    }
}
