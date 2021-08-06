using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineThrowController : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;

    // Components
    private Rigidbody2D mineThrowBody;
    public GameObject mineGround;
    // Physics
    public float aimAngle;
    public Vector2 movement;
    public bool isShrinking = true;
    public bool isDone = false;
    private IEnumerator createMinesCoroutine;
    private float xPos;
    private float yPos;
    private float xPos_original;
    // Game state
    public int srcPlayerID;
    // Sound Events
    [Header("Sound Events")]
    public GameEvent onMineCastPlaySound;
    // public GameEvent onMineLandPlaySound;

    void Start()
    {
        // Get components
        mineThrowBody = GetComponent<Rigidbody2D>();
        // mineThrow movement
        movement = new Vector2(-Mathf.Sin(Mathf.Deg2Rad * aimAngle), Mathf.Cos(Mathf.Deg2Rad * aimAngle));
        mineThrowBody.AddForce(movement * gameConstants.mineThrowSpeed, ForceMode2D.Impulse);
        transform.Rotate(0f,0f,aimAngle);
        onMineCastPlaySound.Raise();
    }
    void Update(){
        if (isShrinking){
            this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, new Vector3(0.3f,0.3f,1f), 0.2f/gameConstants.mineThrowTime/2*Time.deltaTime);
            if (this.transform.localScale.x <= 0.3f){
                isShrinking = false;
            }
        }
        if (!isShrinking && !isDone){
            this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, new Vector3(0.5f,0.5f,1f), 0.2f/gameConstants.mineThrowTime/2*Time.deltaTime);
            if (this.transform.localScale.x >= 0.5f){
                mineThrowBody.velocity = new Vector2(0f,0f);
                isDone = true;
                createMinesCoroutine = createMines();
                StartCoroutine(createMinesCoroutine);
            }
        }
    }
    public IEnumerator createMines()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        Debug.Log(transform.position.x + "," + transform.position.y);
        xPos = transform.position.x - (1-movement.x)*(gameConstants.mineThrowRows/2);
        yPos = transform.position.y + (1-movement.y)*(gameConstants.mineThrowColumns/2);
        if (gameConstants.mineThrowRows%2 == 0){
            xPos = transform.position.x + (1-movement.x)*(gameConstants.mineThrowRows/2-0.5f);
        }
        if (gameConstants.mineThrowColumns%2 == 0){
            yPos = transform.position.y + (1-movement.y)*(gameConstants.mineThrowColumns/2-0.5f);
        }
        xPos_original = xPos;
        for (int n=0; n<gameConstants.mineThrowColumns;n++){
            for (int m=0;m<gameConstants.mineThrowRows;m++){
                // Debug.Log("vs " +xPos + ", " + yPos);
                mineGround = Instantiate(mineGround, new Vector3(xPos, yPos,this.transform.position.z), Quaternion.identity);
                mineGround.GetComponent<MineGroundController>().srcPlayerID = srcPlayerID;
                mineGround.GetComponent<MineGroundController>().aimAngle = aimAngle;
                mineGround.GetComponent<MineGroundController>().movement = movement;
                xPos+=1f;
            }
            xPos = xPos_original;
            yPos -= 1f;
        }
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
