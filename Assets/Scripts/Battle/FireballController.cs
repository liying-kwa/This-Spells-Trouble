using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    // Components
    private Rigidbody2D fireballBody;

    // Physics
    public float aimAngle;

    // Constants
    private float speed = 1;
    private float destroyTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        fireballBody = GetComponent<Rigidbody2D>();
        fireballBody.AddForce(new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle)) * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
