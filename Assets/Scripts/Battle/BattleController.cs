using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;

    // GameObjects
    GameObject mageObject;
    GameObject aimObject;
    // public Image imageCooldown;
    public GameObject fireballPrefab;

    // Components
    private  Rigidbody2D rigidBody;

    // Physics
    Vector2 move;
    // float moveAngle;
    Vector2 aim;
    float aimAngle;

    // Game State
    public int playerID;
    bool fireballReady = true;
    
    private void OnMove(InputValue value) {
        move = value.Get<Vector2>();
    }
    private void OnAim(InputValue value) {
        aim = value.Get<Vector2>();
    }
    
    private void OnFire() {
        ThrowFireball();
    }

    // Start is called before the first frame update
    void Start()
    {
        // GameObjects
        foreach (Transform child in transform) {
            if (child.name == "Mage") {
                mageObject = child.gameObject;
                mageObject.SetActive(true);
            } else if (child.name == "Aim") {
                aimObject = child.gameObject;
                aimObject.SetActive(true);
            }
        }

        // Components
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (move.x != 0 && move.y != 0) {
            // Vector2 movement = new Vector2(move.x, move.y) * gameConstants.moveSpeed * Time.deltaTime;
            // transform.Translate(movement, Space.World);
            Vector2 movement = new Vector2(move.x, move.y) * gameConstants.playerSpeed;
            rigidBody.AddForce(new Vector2(move.x, move.y) * gameConstants.playerSpeed, ForceMode2D.Impulse);
            // moveAngle = Mathf.Atan2(-move.x, move.y) * Mathf.Rad2Deg;
            // Quaternion moveRotation = Quaternion.AngleAxis(moveAngle, Vector3.forward);
            // transform.rotation = Quaternion.Slerp(transform.rotation, moveRotation, turnSpeed * Time.time);
        }

        // Aim
        if (aim.x != 0 && aim.y != 0) {
            aimAngle = Mathf.Atan2(-aim.x, aim.y) * Mathf.Rad2Deg;
            // Uncomment next 2 lines and comment 3rd line if u want a turn lag
            //Quaternion aimRotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);
            //transform.rotation = Quaternion.Slerp(transform.rotation, aimRotation, turnSpeed * Time.time);
            aimObject.transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);
        }

        // Cooldowns
        if (!fireballReady) {
            // imageCooldown.fillAmount -= 1 / gameConstants.fireballCooldown * Time.deltaTime;
        }
    }

    // Buttons
    void ThrowFireball() {
        if (fireballReady) {
            Debug.Log("throwing fireball!");
            GameObject fireballObject = Instantiate(fireballPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            fireballObject.GetComponent<FireballController>().srcPlayerID = playerID;
            fireballObject.GetComponent<FireballController>().aimAngle = aimAngle;
            StartCoroutine(FireballCooldown());
        } else {
            //Debug.Log("cooling down...");
        }
    }

    IEnumerator FireballCooldown() {
        fireballReady = false;
        // imageCooldown.fillAmount = 1;
        yield return new WaitForSeconds(gameConstants.fireballCooldown);
        fireballReady = true;
    }

    
}
