using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject[] topLeftSpellIcons;
    public GameObject[] topRightSpellIcons;
    public GameObject[] bottomLeftSpellIcons;
    public GameObject[] bottomRightSpellIcons;
    public GameObject[] topLeftSpells;
    public GameObject[] topRightSpells;
    public GameObject[] bottomLeftSpells;
    public GameObject[] bottomRightSpells;

    // Game State
    int numPlayers;
    GameObject[] mages = {null, null, null, null};

    void Awake() {
        // Set frame rate to be 50 FPS
	    Application.targetFrameRate =  50;

        int currIndex = 0;
        for (int i = 0; i < playerInputsArr.GetLength(); i++) {
            if (playerInputsArr.GetValue(i) != null) {
                playersAreAlive.SetValue(i, true);
                // Assign mages references
                mages[currIndex] = playerInputsArr.GetValue(i).gameObject;
                // Change default actionmap to gameplay
                playerInputsArr.GetValue(i).actions.FindActionMap("CharSelection").Disable();
                playerInputsArr.GetValue(i).actions.FindActionMap("SpellShop").Disable();
                playerInputsArr.GetValue(i).actions.FindActionMap("Battle").Enable();
                currIndex += 1;
            } else {
                playersAreAlive.SetValue(i, false);
            }
        }

        // Assign mages' positions accordingly
        numPlayers = playerInputsArr.GetNumPlayers();
        switch (numPlayers) {
            case 2:
                // Set used stuff active and unused stuff inactive
                foreach (GameObject spellObject in topLeftSpells) {
                    spellObject.transform.gameObject.SetActive(true);
                }
                foreach (GameObject spellObject in bottomRightSpells) {
                    spellObject.transform.gameObject.SetActive(true);
                }
                foreach (GameObject spellObject in bottomLeftSpells) {
                    spellObject.transform.gameObject.SetActive(false);
                }
                foreach (GameObject spellObject in topRightSpells) {
                    spellObject.transform.gameObject.SetActive(false);
                }
                mages[0].transform.position = gameConstants.topLeftPosition;
                mages[1].transform.position = gameConstants.bottomRightPosition;
                mages[0].GetComponent<BattleController>().cooldownImages = topLeftCooldownImages;
                mages[1].GetComponent<BattleController>().cooldownImages = bottomRightCooldownImages;
                mages[0].GetComponent<BattleController>().spellIcons = topLeftSpellIcons;
                mages[1].GetComponent<BattleController>().spellIcons = bottomRightSpellIcons;
                break;
            case 3:
                // Set used stuff active and unused stuff inactive
                foreach (GameObject spellObject in topLeftSpells) {
                    spellObject.transform.gameObject.SetActive(true);
                }
                foreach (GameObject spellObject in topRightSpells) {
                    spellObject.transform.gameObject.SetActive(true);
                }
                foreach (GameObject spellObject in bottomLeftSpells) {
                    spellObject.transform.gameObject.SetActive(true);
                }
                foreach (GameObject spellObject in bottomRightSpells) {
                    spellObject.transform.gameObject.SetActive(false);
                }
                mages[0].transform.position = gameConstants.topLeftPosition;
                mages[1].transform.position = gameConstants.topRightPosition;
                mages[2].transform.position = gameConstants.bottomLeftPosition;
                mages[0].GetComponent<BattleController>().cooldownImages = topLeftCooldownImages;
                mages[1].GetComponent<BattleController>().cooldownImages = topRightCooldownImages;
                mages[2].GetComponent<BattleController>().cooldownImages = bottomLeftCooldownImages;
                mages[0].GetComponent<BattleController>().spellIcons = topLeftSpellIcons;
                mages[1].GetComponent<BattleController>().spellIcons = topRightSpellIcons;
                mages[2].GetComponent<BattleController>().spellIcons = bottomLeftSpellIcons;
                break;
            case 4:
                // Set used stuff active and unused stuff inactive
                foreach (GameObject spellObject in topLeftSpells) {
                    spellObject.transform.gameObject.SetActive(true);
                }
                foreach (GameObject spellObject in topRightSpells) {
                    spellObject.transform.gameObject.SetActive(true);
                }
                foreach (GameObject spellObject in bottomLeftSpells) {
                    spellObject.transform.gameObject.SetActive(true);
                }
                foreach (GameObject spellObject in bottomRightSpells) {
                    spellObject.transform.gameObject.SetActive(true);
                }
                mages[0].transform.position = gameConstants.topLeftPosition;
                mages[1].transform.position = gameConstants.topRightPosition;
                mages[2].transform.position = gameConstants.bottomLeftPosition;
                mages[3].transform.position = gameConstants.bottomRightPosition;
                mages[0].GetComponent<BattleController>().cooldownImages = topLeftCooldownImages;
                mages[1].GetComponent<BattleController>().cooldownImages = topRightCooldownImages;
                mages[2].GetComponent<BattleController>().cooldownImages = bottomLeftCooldownImages;
                mages[3].GetComponent<BattleController>().cooldownImages = bottomRightCooldownImages;
                mages[0].GetComponent<BattleController>().spellIcons = topLeftSpellIcons;
                mages[1].GetComponent<BattleController>().spellIcons = topRightSpellIcons;
                mages[2].GetComponent<BattleController>().spellIcons = bottomLeftSpellIcons;
                mages[3].GetComponent<BattleController>().spellIcons = bottomRightSpellIcons;
                break;
        }
        for (int i = 0; i < 4; i++) {
            if (mages[i] == null) {
                continue;
            }
            // Disable previous script and activate current script and relevant components
            mages[i].GetComponent<CharSelectionController>().enabled = false;
            mages[i].GetComponent<ShopController>().enabled = false;
            mages[i].GetComponent<BattleController>().enabled = true;
            mages[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
