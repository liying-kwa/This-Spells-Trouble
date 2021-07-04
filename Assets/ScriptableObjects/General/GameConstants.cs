using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "GameConstants", menuName =  "ScriptableObjects/GameConstants", order =  1)]
public class GameConstants : ScriptableObject
{
    // CharSelectionScene
    public int countdownTime = 10;

    // BattleScene
    public Vector3 topLeftPosition = new Vector3(-2.71f, 2.71f, 0);
    public Vector3 topRightPosition = new Vector3(2.71f, 2.71f, 0);
    public Vector3 bottomLeftPosition = new Vector3(-2.71f, -2.71f, 0);
    public Vector3 bottomRightPosition = new Vector3(2.71f, -2.71f, 0);
    public float moveSpeed = 1;
    // float turnSpeed = 0.001f;
    public float fireballCooldown = 3;
}
