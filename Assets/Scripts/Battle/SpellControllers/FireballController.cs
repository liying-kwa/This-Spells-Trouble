using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;

    // Components
    private Rigidbody2D fireballBody;
    private AudioSource audioSource;
    public AudioClip hitAudio;

    // Physics
    public float aimAngle;
    public Vector2 movement;

    // Game state
    public int srcPlayerID;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        fireballBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        // Get constants
        damage = gameConstants.fireballDamage;
        // Fireball movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        fireballBody.AddForce(movement * gameConstants.fireballSpeed, ForceMode2D.Impulse);
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
                // Debug.Log("Collided with other player!");
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * gameConstants.fireballSpeed * gameConstants.fireballForce, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                audioSource.Stop();
                AudioSource.PlayClipAtPoint(hitAudio, new Vector3(0, 0, 0));
                Destroy(gameObject);
            }
        }
    }
}
