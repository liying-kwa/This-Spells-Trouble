using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    // ScriptableObjects
    public GameConstants gameConstants;
    public PlayerInputsArr playerInputsArr;
    public IntArrVariable playersChars;
    public IntVariable currentRound;
    public IntArrVariable playersGold;

    // GameObjects
    public Text countdownText;
    public GameObject[] characters;
    public GameObject[] P1SlotIcons;
    public GameObject[] P2SlotIcons;
    public GameObject[] P3SlotIcons;
    public GameObject[] P4SlotIcons;
    public List<GameObject> spellInfos;
    public Text[] spellNameTexts;
    public Text[] spellCostTexts;
    public Text[] spellDescTexts;
    public Text[] spellUpgradeTexts;
    public Text[] goldTexts;


    public List<GameObject> P1SkillStatus1;
    public List<GameObject> P1SkillStatus2;
    public List<GameObject> P1SkillStatus3;
    public List<GameObject> P1SkillStatus4;
    public List<GameObject> P2SkillStatus1;
    public List<GameObject> P2SkillStatus2;
    public List<GameObject> P2SkillStatus3;
    public List<GameObject> P2SkillStatus4;
    public List<GameObject> P3SkillStatus1;
    public List<GameObject> P3SkillStatus2;
    public List<GameObject> P3SkillStatus3;
    public List<GameObject> P3SkillStatus4;
    public List<GameObject> P4SkillStatus1;
    public List<GameObject> P4SkillStatus2;
    public List<GameObject> P4SkillStatus3;
    public List<GameObject> P4SkillStatus4;

    // Animation
    public RuntimeAnimatorController sorceressAnimatorController;
    public RuntimeAnimatorController cultistAnimatorController;
    public RuntimeAnimatorController possessedEnemyAnimatorController;

    void Awake() {
        currentRound.ApplyChange(1);
        for (int i = 0; i < playerInputsArr.GetLength(); i++) {
            if (playerInputsArr.GetValue(i) == null) {
                // Set unused UI objects inactive
                characters[i].SetActive(false);
                spellInfos[i].SetActive(false);
                goldTexts[i].text = "";
                switch (i) {
                    case 0:
                        for (int j = 0; j < 4; j++) {
                            P1SlotIcons[j].SetActive(false);
                        }
                        break;
                    case 1:
                        for (int j = 0; j < 4; j++) {
                            P2SlotIcons[j].SetActive(false);
                        }
                        break;
                    case 2:
                        for (int j = 0; j < 4; j++) {
                            P3SlotIcons[j].SetActive(false);
                        }
                        break;
                    case 3:
                        for (int j = 0; j < 4; j++) {
                            P4SlotIcons[j].SetActive(false);
                        }
                        break;
                }
                continue;
            }
            // Render correct animator for characters
            switch (playersChars.GetValue(i)) {
                case 0:
                    characters[i].GetComponent<Animator>().runtimeAnimatorController = sorceressAnimatorController;
                    break;
                case 1:
                    characters[i].GetComponent<Animator>().runtimeAnimatorController = cultistAnimatorController;
                    break;
                case 2:
                    characters[i].GetComponent<Animator>().runtimeAnimatorController = possessedEnemyAnimatorController;
                    break;
            }
            // Pass in GameObjects accordingly
            GameObject player = playerInputsArr.GetValue(i).gameObject;
            ShopController controller = player.GetComponent<ShopController>();
            controller.spellInfo = spellInfos[i];
            controller.spellNameText = spellNameTexts[i];
            controller.spellCostText = spellCostTexts[i];
            controller.spellDescText = spellDescTexts[i];
            controller.spellUpgradeText = spellUpgradeTexts[i];
            controller.goldText = goldTexts[i];
            switch (i) {
                case 0:
                    controller.slotIcons = P1SlotIcons;
                    break;
                case 1:
                    controller.slotIcons = P2SlotIcons;
                    break;
                case 2:
                    controller.slotIcons = P3SlotIcons;
                    break;
                case 3:
                    controller.slotIcons = P4SlotIcons;
                    break;
            }
            // Disable previous script and activate current script and relevant components
            player.GetComponent<CharSelectionController>().enabled = false;
            player.GetComponent<BattleController>().enabled = false;
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<ShopController>().enabled = true;
            // Change default actionmap
            playerInputsArr.GetValue(i).actions.FindActionMap("CharSelection").Disable();
            playerInputsArr.GetValue(i).actions.FindActionMap("Battle").Disable();
            playerInputsArr.GetValue(i).actions.FindActionMap("SpellShop").Enable();
        }
        // string toShow = "";
        // for (int i = 0; i < 4; i++) {
        //     toShow += "Player " + (i+1) + " gold: " + playersGold.GetValue(i) + "\n";
        // }
        // Debug.Log(toShow);
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Countdown() {
        for (int i = 0; i < gameConstants.shopCountdownTime; i++) {
            countdownText.text = "" + (gameConstants.shopCountdownTime-i);
            yield return new WaitForSeconds(1);
        }
        countdownText.text = "Loading...";
        switch(currentRound.Value) {
            case 1:
                StartCoroutine(ChangeScene("BattleScene1"));
                break;
            case 2:
                StartCoroutine(ChangeScene("BattleScene2"));
                break;
            case 3:
                StartCoroutine(ChangeScene("BattleScene3"));
                break;
            case 4:
                StartCoroutine(ChangeScene("BattleScene4"));
                break;
            case 5:
                StartCoroutine(ChangeScene("BattleScene5"));
                break;
            default:
                Debug.Log("CurrentRound=" + currentRound.Value + ". Tie breaker stage.");
                // Randomly pick one of the battle scenes
                int randomInt = Random.Range(1, 6);
                switch (randomInt) {
                    case 1:
                        StartCoroutine(ChangeScene("BattleScene1"));
                        break;
                    case 2:
                        StartCoroutine(ChangeScene("BattleScene2"));
                        break;
                    case 3:
                        StartCoroutine(ChangeScene("BattleScene3"));
                        break;
                    case 4:
                        StartCoroutine(ChangeScene("BattleScene4"));
                        break;
                    case 5:
                        StartCoroutine(ChangeScene("BattleScene5"));
                        break;
                    default:
                        Debug.Log("RandomInt=" + randomInt + ". Something is wrong.");
                        break;
                }
                break;
        }
    }

    private IEnumerator ChangeScene(string sceneName) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
