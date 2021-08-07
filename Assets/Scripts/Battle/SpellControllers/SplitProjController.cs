using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitProjController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;

    // Components
    private Rigidbody2D splitterBody;
    //private AudioSource audioSource;
    //public AudioClip hitAudio;

    // Physics
    public float startAngle;
    public Vector2 movement;

    // Game state
    public int srcPlayerID;
    public float damage;

    private IEnumerator splitCoroutine;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onSplitProjCastPlaySound;
    public GameEvent onSplitProjHitPlaySound;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        splitterBody = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        // Get constants
        damage = gameConstants.splitProjDamage;
        // SplitProj movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * startAngle), Mathf.Cos(Mathf.Deg2Rad * startAngle));
        splitterBody.AddForce(movement * gameConstants.splitProjSpeed, ForceMode2D.Impulse);
        //this.transform.Rotate(0f,0f,startAngle);
        onSplitProjCastPlaySound.Raise();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, gameConstants.splitProjDestroyTime);
    }
    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            int dstPlayerID = other.gameObject.GetComponent<BattleController>().playerID;
            if (srcPlayerID != dstPlayerID) {
                // Debug.Log("Collided with other player!");
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * gameConstants.splitProjSpeed * gameConstants.splitProjForce, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                //audioSource.Stop();
                //AudioSource.PlayClipAtPoint(hitAudio, new Vector3(0, 0, 0));
                onSplitProjHitPlaySound.Raise();
                Destroy(gameObject);
            }
        }
        // hits other spells and spells destroys itself
        // probably need to make the spells not collide with each other on instantation
        if (other.gameObject.tag == "Obstacle") {
            Destroy(gameObject);
        }
    }
}
