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
    public Vector3 newVectorVar;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onRushCastPlaySound;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = playerInputsArr.GetValue(srcPlayerID).gameObject;
        newVectorVar = new Vector3(transform.position.x - Mathf.Sin(Mathf.Deg2Rad * aimAngle) * gameConstants.rushDistance, 
                                                        transform.position.y + Mathf.Cos(Mathf.Deg2Rad * aimAngle) * gameConstants.rushDistance, 
                                                        transform.position.z);
        onRushCastPlaySound.Raise();
    }

    // Update is called once per frame
    void Update()
    {
    
        Destroy(gameObject, gameConstants.rushDestroyTime);

    }
    void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = newVectorVar;
        playerObject.transform.position = Vector3.MoveTowards(a, b, gameConstants.rushSpeed * Time.deltaTime);
        transform.position = playerObject.transform.position;
    }
    
}
