using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Jo's first spell, heavily based on ly's fireball :)

public class ArcController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;

    // Components
    private Rigidbody2D arcBody;
    //private AudioSource audioSource;
    //public AudioClip hitAudio;

    // Physics
    public float aimAngle;
    public Vector2 forwardMovement;
    public Vector2 currentDirection;

    // Game state
    public int srcPlayerID;
    public float damage;

    // Sound Events
    // [Header("Sound Events")]
    // public GameEvent onArcCastPlaySound;
    // public GameEvent onArcHitPlaySound;
    void Start()
    {
        // Get components
        arcBody = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        // Get constants
        damage = gameConstants.arcDamage;
        // Arc movement
        forwardMovement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * (aimAngle+gameConstants.arcAngle)), Mathf.Cos(Mathf.Deg2Rad * (aimAngle+gameConstants.arcAngle)));
        arcBody.AddForce(forwardMovement * gameConstants.arcForwardSpeed, ForceMode2D.Impulse);
        this.transform.Rotate(0f,0f,aimAngle+gameConstants.arcAngle);
        arcBody.angularVelocity = -gameConstants.arcAngle*2/gameConstants.arcDestroyTime;
        Debug.Log("angular velocity is "+ arcBody.angularVelocity);
        //onArcCastPlaySound.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        currentDirection = transform.up; 
        arcBody.velocity = currentDirection * arcBody.velocity.magnitude;
        Destroy(gameObject, gameConstants.arcDestroyTime);
        //Debug.Log("arcBody velocity is " + arcBody.velocity);
    }


    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            int dstPlayerID = other.gameObject.GetComponent<BattleController>().playerID;
            if (srcPlayerID != dstPlayerID) {
                // Debug.Log("Collided with other player!");
                // TO-DO: the forwardmovement might be wrong but I can't math now - Jo
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(forwardMovement * gameConstants.arcForwardSpeed * gameConstants.arcForce, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                //audioSource.Stop();
                //AudioSource.PlayClipAtPoint(hitAudio, new Vector3(0, 0, 0));
                //onArcHitPlaySound.Raise();
                Destroy(gameObject);
            }
        }
    }
}
