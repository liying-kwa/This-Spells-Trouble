using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "GameConstants", menuName =  "ScriptableObjects/GameConstants", order =  1)]
public class GameConstants : ScriptableObject
{
    // CharSelectionScene
    public int countdownTime = 3;

    // BattleScene
    public float playerSpeed = 0.4f;
    public float knockbackInitial = 1.5f;
    public float knockbackMultiplier = 0.5f;
    public float regenWait = 5;
    public float regenInterval = 1;
    public float regenValue = 2;
    public float spellAnimationDuration = 0.53f;
    public float hurtAnimationDuration = 0.53f;
    public float playerOffset = 1;
    public Vector3 topLeftPosition = new Vector3(-2.71f, 2.71f, 0);
    public Vector3 topRightPosition = new Vector3(2.71f, 2.71f, 0);
    public Vector3 bottomLeftPosition = new Vector3(-2.71f, -2.71f, 0);
    public Vector3 bottomRightPosition = new Vector3(2.71f, -2.71f, 0);
    public Vector3 Map2P1Position = new Vector3(0, 5.4f, 0);
    public Vector3 Map2P2Position = new Vector3(12.5f, -0.6f, 0);
    public Vector3 Map2P3Position = new Vector3(0, -5.4f, 0);
    public Vector3 Map2P4Position = new Vector3(-12.5f, -0.6f, 0);
    // float turnSpeed = 0.001f;
    public float lavaDamage = 1;
    public float lavaDamageInverval = 0.5f;
    public float fireballCooldown = 3;
    public float fireballSpeedL1L2 = 1.5f;
    public float fireballSpeedL3 = 2;
    public float fireballForce = 20;
    public float fireballDestroyTime = 1.5f;
    public int fireballDamageL1 = 10;
    public int fireballDamageL2L3 = 20;
    public float teleportDistanceL1 = 2;
    public float teleportDistanceL2L3 = 4;
    public float teleportCooldownL1L2 = 7;
    public float teleportCooldownL3 = 5;
    public float teleportDestroyTime = 0.5f;
    public float lightningProjectileCooldownL1L2 = 6;
    public float lightningProjectileCooldownL3 = 4;
    public float lightningProjectileSpeed = 2.25f;
    public float lightningProjectileForce = 15;
    public float lightningProjectileDestroyTime = 0.75f;
    public float lightningProjectileDamageL1 = 15;
    public float lightningProjectileDamageL2L3 = 25;
    public float tornadoCooldownL1L2 = 16;
    public float tornadoCooldownL3 = 10;
    public float tornadoSpeed = 0.75f;
    public float tornadoForce = 15;
    public float tornadoDestroyTimeL1 = 5;
    public float tornadoDestroyTimeL2L3 = 10;
    public float tornadoDamage = 20;
    public float rushDestroyTime = 1;
    public float rushSpeed = 5;
    public float rushDistance = 5;
    public float rushCooldown = 5;
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
    public float splitProjDamage = 10;
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
    public int laserDamage = 5;
    public float laserForce = 0;
    public float laserCooldown = 1;
    public float laserSpeed = 3;
    public float laserDestroyTime = 4;
    public float cloudCooldown = 10;
    public float cloudDestroyTime = 3;
    public float cloudSpeed = 2;
    public float mineThrowSpeed = 1.25f;
    public float mineThrowTime = 0.25f;
    public int mineThrowRows = 3;
    public int mineThrowColumns = 3;
    public float mineThrowCooldown = 15;
    public int mineGroundDamage = 10;
    public float mineGroundForce = 5;
    public float mineGroundSpeed = 1.5f; //this is only used to detemine knockback
    public float mineGroundDestroyTime = 5;
    public float groundAttackDamage = 12;
    public float groundAttackDistance = 6;
    public float groundAttackDestroyTime = 3;
    public float groundAttackForce = 8;
    public float groundAttackCooldown = 5;
    public float iceAttackDamage = 5;
    public float iceAttackDistance = 3.5f;
    public float iceAttackDestroyTime = 2.5f;
    public float iceAttackForce = 8;
    public float iceAttackCooldown = 5;
    public float shockwaveCooldown = 3;
    public float shockwaveSpeed = 3.5f;
    public float shockwaveForce = 5;
    public float shockwaveDestroyTime = 0.5f;
    public float shockwaveDamage = 10;
    public float wallDistance = 1.3f;
    public float wallDestroyTime = 9;
    public float wallCooldown = 12;
    public float wallForce = 0.01f;

    // SpellShopScene
    public int shopCountdownTime = 30;
    public int goldIncrement = 500;

    // VictoryScene
    public int showButtonsDuration = 5;
}
