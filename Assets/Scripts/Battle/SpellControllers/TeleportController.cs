using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public PlayerInputsArr playerInputsArr;

    // Physics
    public float aimAngle;

    // Game state
    public int srcPlayerID;
    GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = playerInputsArr.GetValue(srcPlayerID).gameObject;
        playerObject.transform.position = new Vector3(transform.position.x - Mathf.Sin(Mathf.Deg2Rad * aimAngle) * gameConstants.teleportDistance, 
                                                        transform.position.y + Mathf.Cos(Mathf.Deg2Rad * aimAngle) * gameConstants.teleportDistance, 
                                                        transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerObject.transform.position;
        Destroy(gameObject, gameConstants.teleportDestroyTime);
    }
}
