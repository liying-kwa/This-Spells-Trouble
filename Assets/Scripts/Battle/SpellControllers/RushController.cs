using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public PlayerInputsArr playerInputsArr;

    // Physics
    public float aimAngle;

    // Game state
    public int srcPlayerID;
    GameObject playerObject;
    public Vector3 rushVectorVar;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onRushCastPlaySound;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = playerInputsArr.GetValue(srcPlayerID).gameObject; //Get corresponding player Game Object
        //Get the vector location of where the player is going to rush to
        rushVectorVar = new Vector3(transform.position.x - Mathf.Sin(Mathf.Deg2Rad * aimAngle) * gameConstants.rushDistance, 
                                                        transform.position.y + Mathf.Cos(Mathf.Deg2Rad * aimAngle) * gameConstants.rushDistance, 
                                                        transform.position.z);
        onRushCastPlaySound.Raise();
    }

    void FixedUpdate()
    {   
        // //Get the direction vector of where the player is rushing to
        // Vector3 dir = playerObject.transform.position - rushVectorVar;
        // // normalize directional vector
        // dir = dir.normalized;
        // //Shoot a raycast from the player to the rush destination, returns the hit if it found one.
        // if (Physics.Raycast(playerObject.transform.position, dir, out RaycastHit hit))
        // {
        //     //Hit obstacle
        //     rushVectorVar = hit.point + dir * gameConstants.playerOffset;
        // }

        // rush to the intended position
        playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, rushVectorVar, gameConstants.rushSpeed * Time.deltaTime);
        
        transform.position = playerObject.transform.position;
        Destroy(gameObject, gameConstants.rushDestroyTime);
    }
    
}
