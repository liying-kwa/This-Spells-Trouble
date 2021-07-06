using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;

    // Components
    private Rigidbody2D fireballBody;

    // Physics
    public float aimAngle;
    public Vector2 movement;

    // Game state
    public int srcPlayerID;

    // Start is called before the first frame update
    void Start()
    {
        fireballBody = GetComponent<Rigidbody2D>();
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
                Debug.Log("Collided with other player!");
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(movement * gameConstants.fireballSpeed * gameConstants.fireballForce, ForceMode2D.Impulse);
                Destroy(gameObject);
            }
        }
    }
}
