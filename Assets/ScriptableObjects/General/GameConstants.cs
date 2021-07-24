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
    public float playerSpeed = 0.1f;
    public float spellAnimationDuration = 0.53f;
    public float hurtAnimationDuration = 0.53f;
    // float turnSpeed = 0.001f;
    public float lavaDamage = 10;
    public float lavaDamageInverval = 1;
    public float fireballCooldown = 3;
    public float fireballSpeed = 1.5f;
    public float fireballForce = 5;
    public float fireballDestroyTime = 1.5f;
    public int fireballDamage = 30;
    public float teleportDistance = 3;
    public float teleportCooldown = 5;
    public float teleportDestroyTime = 0.5f;
    public float lightningProjectileCooldown = 6;
    public float lightningProjectileSpeed = 2.25f;
    public float lightningProjectileForce = 2;
    public float lightningProjectileDestroyTime = 0.75f;
    public float lightningProjectileDamage = 20;
    public float tornadoCooldown = 16;
    public float tornadoSpeed = 0.75f;
    public float tornadoForce = 4;
    public float tornadoDestroyTime = 8;
    public float tornadoDamage = 20;
}
