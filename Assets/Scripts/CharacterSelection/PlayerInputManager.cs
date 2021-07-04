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
        Debug.Log(playerID);
        // Pass in GameObjects accordingly
        GameObject characterObject = playerInput.gameObject;
        characterObject.GetComponent<SelectionController>().playerID = playerID;
        switch (playerID) {
            case 0:
                characterObject.GetComponent<SelectionController>().characters = P1Characters;
                characterObject.GetComponent<SelectionController>().text = P1Text;
                break;
            case 1:
                characterObject.GetComponent<SelectionController>().characters = P2Characters;
                characterObject.GetComponent<SelectionController>().text = P2Text;
                break;
            case 2:
                characterObject.GetComponent<SelectionController>().characters = P3Characters;
                characterObject.GetComponent<SelectionController>().text = P3Text;
                break;
            case 3:
                characterObject.GetComponent<SelectionController>().characters = P4Characters;
                characterObject.GetComponent<SelectionController>().text = P4Text;
                break;
        }
    }
}
