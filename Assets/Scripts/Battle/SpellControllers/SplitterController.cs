using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterController : MonoBehaviour
{
    //Split Projectile
    public GameObject splitProj;
    
    // ScriptableObjects
    public GameConstants gameConstants;
    public KnockbackArr playersKnockback;

    // Components
    private Rigidbody2D splitterBody;
    //private AudioSource audioSource;
    //public AudioClip hitAudio;

    // Physics
    public float aimAngle;
    public Vector2 movement;
    public float splitAngle;

    // Game state
    public int srcPlayerID;
    public float damage;

    private IEnumerator splitCoroutine;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onSplitterCastPlaySound;
    public GameEvent onSplitterHitPlaySound;
    public GameEvent onSplitProjCastPlaySound;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        splitterBody = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        // Get constants
        damage = gameConstants.splitterDamage;
        // Splitter movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        splitterBody.AddForce(movement * gameConstants.splitterSpeed, ForceMode2D.Impulse);
        //this.transform.Rotate(0f,0f,aimAngle);
        //onSplitterCastPlaySound.Raise();
        splitCoroutine = waitandSplit(gameConstants.splitterDestroyTime);
        StartCoroutine(splitCoroutine);
    }

    public IEnumerator waitandSplit(float waitTime){
        //Debug.Log("coroutine");
        yield return new WaitForSeconds(waitTime);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        //this.transform.Rotate(0f,0f,gameConstants.splitterStartAngle);
        splitAngle = aimAngle + gameConstants.splitterStartAngle;
        for (int i = 0; i < gameConstants.splitterNumber; i++){
            Debug.Log("i = "+splitAngle);
            splitProj = Instantiate(splitProj, transform.position, transform.rotation);
            splitProj.GetComponent<SplitProjController>().srcPlayerID = this.srcPlayerID;
            splitProj.GetComponent<SplitProjController>().startAngle = splitAngle;
            splitAngle += -gameConstants.splitterStartAngle*2/(gameConstants.splitterNumber-1);
            yield return null;
        //onSplitProjCastPlaySound.Raise();
        Destroy(gameObject, 1f);
        }
    }

    void  OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            int dstPlayerID = other.gameObject.GetComponent<BattleController>().playerID;
            if (srcPlayerID != dstPlayerID) {
                // Debug.Log("Collided with other player!");
                StopCoroutine(splitCoroutine);
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * gameConstants.splitterSpeed * gameConstants.splitterForce, ForceMode2D.Impulse);
                playersKnockback.ApplyChange(dstPlayerID, damage);
                other.gameObject.GetComponent<BattleController>().Hurt();
                //audioSource.Stop();
                //AudioSource.PlayClipAtPoint(hitAudio, new Vector3(0, 0, 0));
                //onSplitterHitPlaySound.Raise();
                Destroy(gameObject);
            }
        }
    }
}
