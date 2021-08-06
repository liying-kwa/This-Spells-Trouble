using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;
    public PlayerInputsArr playerInputsArr;

    // Components
    private Rigidbody2D boomerangBody;
    //private AudioSource audioSource;
    //public AudioClip hitAudio;

    // Physics
    public float aimAngle;
    public Vector2 movement;
    public bool isBoomerangFast = false;
    public bool isReturning = false;

    // Game state
    public int srcPlayerID;
    public float damage;
    public IEnumerator checkBoomerangFast;
    //Reference to same object
    public GameObject Boomerang;
    GameObject playerObject;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onBoomerangCastPlaySound;
    public GameEvent onBoomerangHitPlaySound;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get components
        boomerangBody = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        // Get constants
        damage = gameConstants.boomerangDamage;
        isBoomerangFast = false;
        // boomerang movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        boomerangBody.AddForce(movement * gameConstants.boomerangSpeed, ForceMode2D.Impulse);
        boomerangBody.angularVelocity = 360f;
        checkBoomerangFast = boomerangFast();
        StartCoroutine(checkBoomerangFast);
        onBoomerangCastPlaySound.Raise();
    }

    public IEnumerator boomerangFast(){
        yield return new WaitForSeconds(gameConstants.boomerangForwardTime-0.1f);
        isReturning = true;
        yield return new WaitForSeconds(gameConstants.boomerangForwardTime-0.1f);
        isBoomerangFast = true;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, gameConstants.boomerangForwardTime + gameConstants.boomerangBackwardTime);
    }

    void FixedUpdate(){
        boomerangBody.AddForce(-movement*gameConstants.boomerangSpeed/gameConstants.boomerangForwardTime);
    }

    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            StopAllCoroutines();
            int dstPlayerID = other.gameObject.GetComponent<BattleController>().playerID;
            if (srcPlayerID != dstPlayerID) {
                // Debug.Log("Collided with other player!");
                float knockback = playersKnockback.GetValue(dstPlayerID);
                if (isBoomerangFast){
                    float forceMultiplier = gameConstants.boomerangFastForce * (gameConstants.knockbackInitial + gameConstants.knockbackMultiplier * Mathf.Log(knockback + 1));
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * forceMultiplier, ForceMode2D.Impulse);
                    damage = gameConstants.boomerangFastDamage;
                }
                else if (isReturning){
                    float forceMultiplier = gameConstants.boomerangForce * (gameConstants.knockbackInitial + gameConstants.knockbackMultiplier * Mathf.Log(knockback + 1));
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(-movement * forceMultiplier, ForceMode2D.Impulse);
                }
                else {
                    float forceMultiplier = gameConstants.boomerangForce * (gameConstants.knockbackInitial + gameConstants.knockbackMultiplier * Mathf.Log(knockback + 1));
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * forceMultiplier, ForceMode2D.Impulse);
                }
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                //audioSource.Stop();
                //AudioSource.PlayClipAtPoint(hitAudio, new Vector3(0, 0, 0));
                onBoomerangHitPlaySound.Raise();
                Destroy(gameObject);
            }
            if (srcPlayerID == dstPlayerID && isReturning){
                Debug.Log("Caught and thrown Boomerang");
                playerObject = playerInputsArr.GetValue(srcPlayerID).gameObject;
                Boomerang = Instantiate(Boomerang, transform.position, transform.rotation);
                Boomerang.GetComponent<BoomerangController>().srcPlayerID = srcPlayerID;
                //TODO: Get current aim angle. remove band-aid fix
                //Boomerang.GetComponent<BoomerangController>().aimAngle = srcPlayerID.
                Boomerang.GetComponent<BoomerangController>().aimAngle = aimAngle;
                Destroy(gameObject);
            }
        }
    }
}
