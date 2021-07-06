using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInputManager : MonoBehaviour
{
    // UI References
    public GameObject[] P1Characters;
    public GameObject[] P2Characters;
    public GameObject[] P3Characters;
    public GameObject[] P4Characters;
    public Text P1Text;
    public Text P2Text;
    public Text P3Text;
    public Text P4Text;

    // ScriptableObjects
    public PlayerInputsArr playerInputsArr;
    public BoolArrVariable playersJoined;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoined(PlayerInput playerInput) {
        int playerID = -1;
        for (int i = 0; i < playersJoined.GetLength(); i++) {
            if (playersJoined.GetValue(i) == false) {
                playerID = i;
                playersJoined.SetValue(i, true);
                break;
            }
        }
        if (playerID == -1) {
            Debug.Log("No more player slots left.");
            return;
        }
        playerInputsArr.SetValue(playerID, playerInput);
        // Pass in GameObjects accordingly
        GameObject playerObject = playerInput.gameObject;
        playerObject.GetComponent<CharSelectionController>().playerID = playerID;
        playerObject.GetComponent<BattleController>().playerID = playerID;
        switch (playerID) {
            case 0:
                playerObject.GetComponent<CharSelectionController>().characters = P1Characters;
                playerObject.GetComponent<CharSelectionController>().text = P1Text;
                break;
            case 1:
                playerObject.GetComponent<CharSelectionController>().characters = P2Characters;
                playerObject.GetComponent<CharSelectionController>().text = P2Text;
                break;
            case 2:
                playerObject.GetComponent<CharSelectionController>().characters = P3Characters;
                playerObject.GetComponent<CharSelectionController>().text = P3Text;
                break;
            case 3:
                playerObject.GetComponent<CharSelectionController>().characters = P4Characters;
                playerObject.GetComponent<CharSelectionController>().text = P4Text;
                break;
        }
    }
}
