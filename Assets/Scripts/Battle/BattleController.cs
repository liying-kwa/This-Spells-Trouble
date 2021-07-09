using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public IntArrVariable playersChars;
    public KnockbackArr playersKnockback;
    public ChosenSpellsArr playersSpells;

    // GameObjects
    GameObject mageObject;
    GameObject aimObject;
    GameObject knockbackObject;

    // public Image imageCooldown;
    public GameObject fireballPrefab;

    // Sprites
    public Sprite[] mageSprites;
    
    // Components
    private  Rigidbody2D rigidBody;
    SpriteRenderer mageSpriteRenderer;
    SpriteRenderer knockbackSpriteRenderer;

    // Physics
    Vector2 move;
    // float moveAngle;
    Vector2 aim;
    float aimAngle;

    // Game State
    public int playerID;
    float maxXScale;
    bool[] spellsReady = {true, true, true, true};
    
    private void OnMove(InputValue value) {
        move = value.Get<Vector2>();
    }
    private void OnAim(InputValue value) {
        aim = value.Get<Vector2>();
    }
    
    private void OnSpell1() {
        executeSpell(0);
    }

    private void OnSpell2() {
        executeSpell(1);
    }

    private void OnSpell3() {
        executeSpell(2);
    }

    private void OnSpell4() {
        executeSpell(3);
    }

    private void executeSpell(int slot) {
        Spell spell = playersSpells.GetSpell(playerID, slot);
        switch (spell) {
            case Spell.fireball:
                CastFireball(slot);
                break;
            case Spell.teleport:
                break;
            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start() {

        // GameObjects
        foreach (Transform child in transform) {
            if (child.name == "Mage") {
                mageObject = child.gameObject;
                mageObject.SetActive(true);
            } else if (child.name == "Aim") {
                aimObject = child.gameObject;
                aimObject.SetActive(true);
            } else if (child.name == "Knockback") {
                knockbackObject = child.gameObject;
                knockbackObject.SetActive(true);
            }
        }

        // Components
        rigidBody = GetComponent<Rigidbody2D>();
        mageSpriteRenderer = mageObject.GetComponent<SpriteRenderer>();
        knockbackSpriteRenderer = knockbackObject.GetComponent<SpriteRenderer>();

        // Render the correct character sprite
        mageSpriteRenderer.sprite = mageSprites[playersChars.GetValue(playerID)];

        // Initialise values
        maxXScale = knockbackObject.transform.localScale.x;
        knockbackObject.transform.localScale = new Vector3(0, knockbackObject.transform.localScale.y, knockbackObject.transform.localScale.z);
        playersKnockback.SetValue(playerID, 0);
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

        // Knockback
        float knockbackFloat = playersKnockback.GetValue(playerID) / 100;
        knockbackObject.transform.localScale = new Vector3(knockbackFloat * maxXScale, knockbackObject.transform.localScale.y, knockbackObject.transform.localScale.z);
        if (knockbackFloat < 0.5f) {
            // gold
            knockbackSpriteRenderer.color = new Color(1, 0.8f, 0, 1);
        } else if (knockbackFloat < 0.99f) {
            // orange
            knockbackSpriteRenderer.color = new Color(1, 0.4f, 0, 1);
        } else {
            // red
            knockbackSpriteRenderer.color = new Color(1, 0, 0, 1);
        }

        // Cooldowns
        // if (!fireballReady) {
        //     imageCooldown.fillAmount -= 1 / gameConstants.fireballCooldown * Time.deltaTime;
        // }
    }

    // Spells
    void CastFireball(int slot) {
        if (spellsReady[slot]) {
            Debug.Log("throwing fireball!");
            GameObject fireballObject = Instantiate(fireballPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            fireballObject.GetComponent<FireballController>().srcPlayerID = playerID;
            fireballObject.GetComponent<FireballController>().aimAngle = aimAngle;
            StartCoroutine(SpellCooldown(slot, gameConstants.fireballCooldown));
        } else {
            //Debug.Log("cooling down...");
        }
    }

    IEnumerator SpellCooldown(int slot, float duration) {
        spellsReady[slot] = false;
        // imageCooldown.fillAmount = 1;
        yield return new WaitForSeconds(duration);
        spellsReady[slot] = true;
    }

    // void  OnTriggerEnter2D(Collider2D other) {
    //     if (other.gameObject.tag == "Spell") {
    //         FireballController spellController = other.gameObject.GetComponent<FireballController>();
    //         int srcPlayerID = spellController.srcPlayerID;
    //         if (srcPlayerID != playerID) {
    //             playersKnockback.ApplyChange(playerID, spellController.damage);
    //             Debug.Log(playerID + " " + playersKnockback.GetValue(playerID));
    //         }
    //     }
    // }

    
}
