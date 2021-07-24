using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    // ScriptableObjects
    public GameConstants gameConstants;
    public PlayerInputsArr playerInputsArr;
    public BoolArrVariable playersAreAlive;

    // GameObject References
    // public GameObject playerPrefab;
    public Image[] topLeftCooldownImages;
    public Image[] topRightCooldownImages;
    public Image[] bottomLeftCooldownImages;
    public Image[] bottomRightCooldownImages;

    // Game State
    int numPlayers;
    GameObject[] mages = {null, null, null, null};


    void Awake()
    {
        // Set frame rate to be 50 FPS
	    Application.targetFrameRate =  50;

        int currIndex = 0;
        for (int i = 0; i < playerInputsArr.GetLength(); i++) {
            if (playerInputsArr.GetValue(i) != null) {
                playersAreAlive.SetValue(i, true);
                // Assign mages references
                mages[currIndex] = playerInputsArr.GetValue(i).gameObject;
                // Disable previous script and activate current script and relevant components
                mages[currIndex].GetComponent<CharSelectionController>().enabled = false;
                mages[currIndex].GetComponent<ShopController>().enabled = false;
                mages[currIndex].GetComponent<BattleController>().enabled = true;
                mages[currIndex].GetComponent<BoxCollider2D>().enabled = true;
                // Change default actionmap to gameplay
                playerInputsArr.GetValue(i).actions.FindActionMap("CharSelection").Disable();
                playerInputsArr.GetValue(i).actions.FindActionMap("SpellShop").Disable();
                playerInputsArr.GetValue(i).actions.FindActionMap("Battle").Enable();
                currIndex += 1;
            } else {
                playersAreAlive.SetValue(i, false);
            }
        }
        // Set mages active and assign their positions accordingly
        numPlayers = playerInputsArr.GetNumPlayers();
        switch (numPlayers) {
            case 2:
                mages[0].transform.position = gameConstants.topLeftPosition;
                mages[1].transform.position = gameConstants.bottomRightPosition;
                mages[0].GetComponent<BattleController>().cooldownImages = topLeftCooldownImages;
                mages[1].GetComponent<BattleController>().cooldownImages = bottomRightCooldownImages;
                break;
            case 3:
                mages[0].transform.position = gameConstants.topLeftPosition;
                mages[1].transform.position = gameConstants.topRightPosition;
                mages[2].transform.position = gameConstants.bottomLeftPosition;
                mages[0].GetComponent<BattleController>().cooldownImages = topLeftCooldownImages;
                mages[1].GetComponent<BattleController>().cooldownImages = topRightCooldownImages;
                mages[2].GetComponent<BattleController>().cooldownImages = bottomLeftCooldownImages;
                break;
            case 4:
                mages[0].transform.position = gameConstants.topLeftPosition;
                mages[1].transform.position = gameConstants.topRightPosition;
                mages[2].transform.position = gameConstants.bottomLeftPosition;
                mages[3].transform.position = gameConstants.bottomRightPosition;
                mages[0].GetComponent<BattleController>().cooldownImages = topLeftCooldownImages;
                mages[1].GetComponent<BattleController>().cooldownImages = topRightCooldownImages;
                mages[2].GetComponent<BattleController>().cooldownImages = bottomLeftCooldownImages;
                mages[3].GetComponent<BattleController>().cooldownImages = bottomRightCooldownImages;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
