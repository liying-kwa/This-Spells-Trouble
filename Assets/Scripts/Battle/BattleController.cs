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

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onLavaPlaySound;
    public GameEvent onPlayerDeathPlaySound;

    // GameObjects
    MapManager mapManager;
    GameObject mageObject;
    GameObject aimObject;
    GameObject knockbackObject;
    public Image[] cooldownImages;
    public GameObject fireballPrefab;
    public GameObject teleportPrefab;

    // Sprites
    public Sprite[] mageSprites;
    public Sprite[] deadSprites;
    
    // Components
    private  Rigidbody2D rigidBody;
    // SpriteRenderer mageSpriteRenderer;
    Animator animator;
    SpriteRenderer knockbackSpriteRenderer;

    // Animation
    // public static readonly string[] staticDirections = {"Static_N", "Static_NW", "Static_W", "Static_SW", "Static_S", "Static_SE", "Static_E", "Static_NE"};
    // public static readonly string[] runDirections = {"Run_N", "Run_NW", "Run_W", "Run_SW", "Run_S", "Run_SE", "Run_E", "Run_NE"};
    // public static readonly string[] staticDirections = {"Static_N", "Static_W", "Static_S", "Static_E"};
    // public static readonly string[] runDirections = {"Run_N", "Run_W", "Run_S", "Run_E"};
    public static readonly string[] idleDirections = {"Idle_N", "Idle_W", "Idle_S", "Idle_E"};
    public static readonly string[] walkDirections = {"Walk_N", "Walk_W", "Walk_S", "Walk_E"};
    public static readonly string[] attackDirections = {"Attack_N", "Attack_W", "Attack_S", "Attack_E"};
    public static readonly string[] hurtDirections = {"Hurt_N", "Hurt_W", "Hurt_S", "Hurt_E"};
    public static readonly string[] deathDirections = {"Death_N", "Death_W", "Death_S", "Death_E"};
    
    int lastDirection = 0;
    bool castingSpell = false;
    IEnumerator spellAnimationCoroutine = null;
    bool hurting = false;
    IEnumerator hurtAnimationCoroutine = null;

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
    public bool onPlatform = true;
    bool isDead = false;
    IEnumerator damageCoroutine = null;
    
    // Controller functions
    private void OnMove(InputValue value) {
        move = value.Get<Vector2>();
    }
    private void OnAim(InputValue value) {
        aim = value.Get<Vector2>();
    }
    
    private void OnSpell1() {
        if (!isDead && !roundEnded.Value) {
            executeSpell(0);
        }
    }

    private void OnSpell2() {
        if (!isDead && !roundEnded.Value) {
            executeSpell(1);
        }
    }

    private void OnSpell3() {
        if (!isDead && !roundEnded.Value) {
            executeSpell(2);
        }
    }

    private void OnSpell4() {
        if (!isDead && !roundEnded.Value) {
            executeSpell(3);
        }
    }

    private void executeSpell(int slot) {
        if (!spellsReady[slot]) {
            return;
        }
        Spell spell = playersSpells.GetSpell(playerID, slot);
        if (spell == Spell.nullSpell) {
            return;
        }
        // Animation
        castingSpell = true;
        if (spellAnimationCoroutine != null) {
            StopCoroutine(spellAnimationCoroutine);
        }
        spellAnimationCoroutine = SpellAnimation();
        StartCoroutine(spellAnimationCoroutine);
        // Cast spell
        switch (spell) {
            case Spell.fireball:
                CastFireball(slot);
                break;
            case Spell.teleport:
                CastTeleport(slot);
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
        mapManager = FindObjectOfType<MapManager>();

        // Components
        rigidBody = GetComponent<Rigidbody2D>();
        // mageSpriteRenderer = mageObject.GetComponent<SpriteRenderer>();
        animator = mageObject.GetComponent<Animator>();
        knockbackSpriteRenderer = knockbackObject.GetComponent<SpriteRenderer>();

        // Render the correct character sprite
        // mageSpriteRenderer.sprite = mageSprites[playersChars.GetValue(playerID)];

        // Initialise values
        maxXScale = knockbackObject.transform.localScale.x;
        knockbackObject.transform.localScale = new Vector3(0, knockbackObject.transform.localScale.y, knockbackObject.transform.localScale.z);
        playersKnockback.SetValue(playerID, 0);
        for (int i = 0; i < 4; i++) {
            switch(playersSpells.GetSpell(playerID, i)) {
                case Spell.fireball:
                    cooldownDurations[i] = gameConstants.fireballCooldown;
                    break;
                case Spell.teleport:
                    cooldownDurations[i] = gameConstants.teleportCooldown;
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
            // mageSpriteRenderer.sprite = deadSprites[playersChars.GetValue(playerID)];
            return;
        }

        // Damage if outside platform
        onPlatform = !mapManager.GetTileDealsDamage(transform.position);
        if (!onPlatform) {
            // Start damage coroutine, if not started
            if (damageCoroutine == null) {
                damageCoroutine = Damage();
                StartCoroutine(damageCoroutine);
                //onLavaPlaySound.Raise();
            } 
        } else {
            // Stop damage coroutine, if running
            if (damageCoroutine != null) {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }

        // Death if knockback is 100 and not on platform
        knockback = playersKnockback.GetValue(playerID);
        if (knockback >= 100 && !onPlatform) {
            isDead = true;
            playersAreAlive.SetValue(playerID, false);
            animator.Play(deathDirections[lastDirection]);
            Debug.Log("Player " + (playerID+1) + " has died.");
            onPlayerDeathPlaySound.Raise();
        }

        // Idle/Walk Animation
        if (!castingSpell && !hurting) {
            string[] directionArray = null;
            if (move.x == 0 && move.y == 0) {
                directionArray = idleDirections;
            } else {
                directionArray = walkDirections;
                // lastDirection = DirectionToIndex(new Vector2(move.x, move.y), 8);
                lastDirection = DirectionToIndex(new Vector2(move.x, move.y), 4);
            }
            animator.Play(directionArray[lastDirection]);
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

    // Platform stuff
    public IEnumerator Damage() {
        while (true) {
            onLavaPlaySound.Raise();
            playersKnockback.SetValue(playerID, playersKnockback.GetValue(playerID) + gameConstants.lavaDamage);
            yield return new WaitForSeconds(gameConstants.lavaDamageInverval);
        }
    }

    // Animation stuff
    int DirectionToIndex(Vector2 dir, int sliceCount) {
        // get the normalized direction
        Vector2 normDir = dir.normalized;
        // calculate how many degrees one slice is
        float step = 360f / sliceCount;
        // calculate how many degrees half a slice is
        // we need this to offset the pie, so that the North slice is aligned in the center
        float halfStep = step / 2;
        // get the angle from -180 to 180 of the direction vector relative to the Up vector
        // this will return the angle between dir and North
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        // add the halfslice offset
        angle += halfStep;
        // if angle is negative, add the wraparound
        if (angle < 0) {
            angle += 360;
        }
        // calculate the amount of steps required to reach this angle
        float stepCount = angle / step;
        // round it off to get the answer
        return Mathf.FloorToInt(stepCount);
    }

    IEnumerator SpellAnimation() {
        Vector2 aimVector = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        // int aimDirection = DirectionToIndex(aimVector, 8);
        int aimDirection = DirectionToIndex(aimVector, 4);
        string clip = attackDirections[aimDirection];
        animator.Play(clip);
        yield return new WaitForSeconds(gameConstants.spellAnimationDuration);
        castingSpell = false;
        spellAnimationCoroutine = null;
    }

    public void Hurt() {
        hurting = true;
        if (hurtAnimationCoroutine != null) {
            StopCoroutine(hurtAnimationCoroutine);
        }
        hurtAnimationCoroutine = HurtAnimation();
        StartCoroutine(hurtAnimationCoroutine);
    }

    IEnumerator HurtAnimation() {
        string clip = hurtDirections[lastDirection];
        animator.Play(clip);
        yield return new WaitForSeconds(gameConstants.hurtAnimationDuration);
        hurting = false;
        hurtAnimationCoroutine = null;
    }

    // Spell stuff
    IEnumerator SpellCooldown(int slot, float duration) {
        spellsReady[slot] = false;
        cooldownImages[slot].fillAmount = 1;
        yield return new WaitForSeconds(duration);
        spellsReady[slot] = true;
    }

    void CastFireball(int slot) {
        GameObject fireballObject = Instantiate(fireballPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        fireballObject.GetComponent<FireballController>().srcPlayerID = playerID;
        fireballObject.GetComponent<FireballController>().aimAngle = aimAngle;
        StartCoroutine(SpellCooldown(slot, gameConstants.fireballCooldown));
    }

    void CastTeleport(int slot) {
        GameObject teleportObject = Instantiate(teleportPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        teleportObject.GetComponent<TeleportController>().srcPlayerID = playerID;
        teleportObject.GetComponent<TeleportController>().aimAngle = aimAngle;
        StartCoroutine(SpellCooldown(slot, gameConstants.teleportCooldown));
    }

}
