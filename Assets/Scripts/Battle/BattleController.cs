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
    public BoolArrVariable playersAreAlive;
    public BoolVariable roundEnded;

    // GameObjects
    GameObject mageObject;
    GameObject aimObject;
    GameObject knockbackObject;
    public Image[] cooldownImages;
    public GameObject fireballPrefab;

    // Sprites
    public Sprite[] mageSprites;
    public Sprite[] deadSprites;
    
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
    float[] cooldownDurations = {-1, -1, -1, -1};
    float knockback;
    public bool onPlatform;
    bool isDead = false;
    
    // Controller functions
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
        playersAreAlive.SetValue(playerID, true);
        maxXScale = knockbackObject.transform.localScale.x;
        knockbackObject.transform.localScale = new Vector3(0, knockbackObject.transform.localScale.y, knockbackObject.transform.localScale.z);
        playersKnockback.SetValue(playerID, 0);
        for (int i = 0; i < 4; i++) {
            switch(playersSpells.GetSpell(playerID, i)) {
                case Spell.fireball:
                    cooldownDurations[i] = gameConstants.fireballCooldown;
                    break;
                default:
                    break;
            }
        }
        // Spell images
    }

    // Update is called once per frame
    void Update()
    {
        if (roundEnded.Value && !isDead) {
            rigidBody.velocity = new Vector3(0, 0, 0);
            return;
        }

        if (isDead) {
            rigidBody.velocity = new Vector3(0, 0, 0);
            mageSpriteRenderer.sprite = deadSprites[playersChars.GetValue(playerID)];
            playersAreAlive.SetValue(playerID, false);
            return;
        }

        // Death if knockback is 100 and not on platform
        knockback = playersKnockback.GetValue(playerID);
        if (knockback >= 100 && !onPlatform) {
            isDead = true;
            Debug.Log("Player " + (playerID+1) + " has died.");
        }

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

        // Knockback bar
        float knockbackFloat = knockback / 100;
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
        if (!spellsReady[0]) {
            cooldownImages[0].fillAmount -= 1 / cooldownDurations[0] * Time.deltaTime;
        }
        if (!spellsReady[1]) {
            cooldownImages[1].fillAmount -= 1 / cooldownDurations[1] * Time.deltaTime;
        }
        if (!spellsReady[2]) {
            cooldownImages[2].fillAmount -= 1 / cooldownDurations[2] * Time.deltaTime;
        }
        if (!spellsReady[3]) {
            cooldownImages[3].fillAmount -= 1 / cooldownDurations[3] * Time.deltaTime;
        }
    }

    IEnumerator SpellCooldown(int slot, float duration) {
        spellsReady[slot] = false;
        cooldownImages[slot].fillAmount = 1;
        yield return new WaitForSeconds(duration);
        spellsReady[slot] = true;
    }

    // Spells
    void CastFireball(int slot) {
        if (spellsReady[slot]) {
            GameObject fireballObject = Instantiate(fireballPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            fireballObject.GetComponent<FireballController>().srcPlayerID = playerID;
            fireballObject.GetComponent<FireballController>().aimAngle = aimAngle;
            StartCoroutine(SpellCooldown(slot, gameConstants.fireballCooldown));
        }
    }

}
