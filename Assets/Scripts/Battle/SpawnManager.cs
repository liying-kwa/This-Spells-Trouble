using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // References
    public GameObject playerPrefab;

    // ScriptableObjects
    public GameConstants gameConstants;
    public PlayerInputsArr playerInputsArr;

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
                // Assign mages references
                mages[currIndex] = playerInputsArr.GetValue(i).gameObject;
                // Disable previous script and activate current script and relevant components
                mages[currIndex].GetComponent<CharSelectionController>().enabled = false;
                mages[currIndex].GetComponent<BattleController>().enabled = true;
                mages[currIndex].GetComponent<BoxCollider2D>().enabled = true;
                // Change default actionmap to gameplay
                playerInputsArr.GetValue(i).actions.FindActionMap("CharSelection").Disable();
                playerInputsArr.GetValue(i).actions.FindActionMap("Battle").Enable();
                currIndex += 1;
            }
        }
        // Set mages active and assign their positions accordingly
        numPlayers = playerInputsArr.GetNumPlayers();
        switch (numPlayers) {
            case 2:
                mages[0].transform.position = gameConstants.topLeftPosition;
                mages[1].transform.position = gameConstants.bottomRightPosition;
                break;
            case 3:
                mages[0].transform.position = gameConstants.topLeftPosition;
                mages[1].transform.position = gameConstants.topRightPosition;
                mages[2].transform.position = gameConstants.bottomLeftPosition;
                break;
            case 4:
                mages[0].transform.position = gameConstants.topLeftPosition;
                mages[1].transform.position = gameConstants.topRightPosition;
                mages[2].transform.position = gameConstants.bottomLeftPosition;
                mages[3].transform.position = gameConstants.bottomRightPosition;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
