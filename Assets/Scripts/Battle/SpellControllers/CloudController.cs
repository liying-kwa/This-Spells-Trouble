using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    // Start is called before the first frame update
    // ScriptableObjects
    public GameConstants gameConstants;
    // Components
    private Rigidbody2D cloudBody;

    // Physics
    public float aimAngle;
    public Vector2 movement;
    // Game state
    public int srcPlayerID; //it shouldn't delete own player's spells but whatever
    public int spellLevel;

    //Game events
    public GameEvent onCloudCastPlaySound;
    // public GameEvent onCloudHitPlaySound;
    
    void Start()
    {
        //GET
        cloudBody = GetComponent<Rigidbody2D>();
        //Movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        cloudBody.AddForce(movement * gameConstants.cloudSpeed, ForceMode2D.Impulse);
        onCloudCastPlaySound.Raise();
        //rotate projectile accordingly top aim angle
        transform.Rotate(0f,0f,aimAngle);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, gameConstants.cloudDestroyTime);
    }
    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Spell") {
            // onCloudHitPlaySound.Raise();
            Destroy(other.gameObject);
        }
    }
}
