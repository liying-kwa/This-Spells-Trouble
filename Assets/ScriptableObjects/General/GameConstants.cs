using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "GameConstants", menuName =  "ScriptableObjects/GameConstants", order =  1)]
public class GameConstants : ScriptableObject
{
    // CharSelectionScene
    public int countdownTime = 3;

    // BattleScene
    public Vector3 topLeftPosition = new Vector3(-2.71f, 2.71f, 0);
    public Vector3 topRightPosition = new Vector3(2.71f, 2.71f, 0);
    public Vector3 bottomLeftPosition = new Vector3(-2.71f, -2.71f, 0);
    public Vector3 bottomRightPosition = new Vector3(2.71f, -2.71f, 0);
    public float playerSpeed = 0.5f;
    public float knockbackInitial = 1.5f;
    public float knockbackMultiplier = 0.5f;
    public float regenWait = 5;
    public float regenInterval = 1;
    public float regenValue = 5;
    public float spellAnimationDuration = 0.53f;
    public float hurtAnimationDuration = 0.53f;
    // float turnSpeed = 0.001f;
    public float lavaDamage = 10;
    public float lavaDamageInverval = 1;
    public float fireballCooldown = 3;
    public float fireballSpeed = 1.5f;
    public float fireballForce = 20;
    public float fireballDestroyTime = 1.5f;
    public int fireballDamage = 30;
    public float teleportDistance = 3;
    public float teleportCooldown = 5;
    public float teleportDestroyTime = 0.5f;
    public float lightningProjectileCooldown = 6;
    public float lightningProjectileSpeed = 2.25f;
    public float lightningProjectileForce = 15;
    public float lightningProjectileDestroyTime = 0.75f;
    public float lightningProjectileDamage = 20;
    public float tornadoCooldown = 16;
    public float tornadoSpeed = 0.75f;
    public float tornadoForce = 15;
    public float tornadoDestroyTime = 8;
    public float tornadoDamage = 20;
    public float rushDestroyTime = 1;
    public float rushSpeed = 5;
    public float rushDistance = 5;
    public float rushCooldown = 10;
    public float arcDamage = 40;
    public float arcForce = 15;
    public float arcForwardSpeed = 1.5f;
    public float arcAngle = -60;
    public float arcCooldown = 5;
    public float arcDestroyTime = 2;
    public float arcDistance = 3;
    public float splitterDamage = 20;
    public float splitterForce = 15;
    public float splitterSpeed = 1;
    public float splitterCooldown = 7;
    public float splitterDestroyTime = 1;
    public float splitterNumber = 5;
    public float splitterStartAngle = -40;
    public float splitProjDamage = 30;
    public float splitProjForce = 8;
    public float splitProjSpeed = 1.5f;
    public float splitProjDestroyTime = 1.5f;
    public float boomerangDamage = 20;
    public float boomerangForce = 8;
    public float boomerangFastDamage = 40;
    public float boomerangFastForce = 20;
    public float boomerangForwardTime = 1;
    public float boomerangBackwardTime = 2;
    public float boomerangSpeed = 3;
    public float boomerangFastSpeed = 6;
    public float boomerangCooldown = 7;

    // SpellShopScene
    public int shopCountdownTime = 30;
    public int goldIncrement = 300;
}
