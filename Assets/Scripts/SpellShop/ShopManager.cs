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

    // GameObjects
    public Text countdownText;
    public SkillModel[] offensiveSpells;
    public SkillModel[] defensiveSpells;
    public GameObject emptySprite;
    public Text[] skillNameTexts;
    public Text[] skillCostTexts;
    public Text[] skillDescTexts;
    public Text[] upgradeTexts;
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
    public List<GameObject> skillsControllers;

    void Awake()
    {
        for (int i = 0; i < playerInputsArr.GetLength(); i++) {
            if (playerInputsArr.GetValue(i) != null) {
                GameObject player = playerInputsArr.GetValue(i).gameObject;
                // Set mages inactive
                foreach (Transform child in player.transform) {
                    if (child.name == "Mage") {
                        child.gameObject.SetActive(false);
                    } else if (child.name == "Aim") {
                        child.gameObject.SetActive(false);
                    } else if (child.name == "Knockback") {
                        child.gameObject.SetActive(false);
                    }
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
                // Pass in GameObjects accordingly
                ShopController controller = player.GetComponent<ShopController>();
                controller.offensiveSpells = offensiveSpells;
                controller.defensiveSpells = defensiveSpells;
                controller.emptySprite = emptySprite;
                controller.skillNameText = skillNameTexts[i];
                controller.skillCostText = skillCostTexts[i];
                controller.skillDescText = skillDescTexts[i];
                controller.upgradeText = upgradeTexts[i];
                controller.skillsController = skillsControllers[i];
                switch (i) {
                    case 0:
                        controller.skillStatus1 = P1SkillStatus1;
                        controller.skillStatus2 = P1SkillStatus2;
                        controller.skillStatus3 = P1SkillStatus3;
                        controller.skillStatus4 = P1SkillStatus4;
                        break;
                    case 1:
                        controller.skillStatus1 = P2SkillStatus1;
                        controller.skillStatus2 = P2SkillStatus2;
                        controller.skillStatus3 = P2SkillStatus3;
                        controller.skillStatus4 = P2SkillStatus4;
                        break;
                    case 2:
                        controller.skillStatus1 = P3SkillStatus1;
                        controller.skillStatus2 = P3SkillStatus2;
                        controller.skillStatus3 = P3SkillStatus3;
                        controller.skillStatus4 = P3SkillStatus4;
                        break;
                    case 3:
                        controller.skillStatus1 = P4SkillStatus1;
                        controller.skillStatus2 = P4SkillStatus2;
                        controller.skillStatus3 = P4SkillStatus3;
                        controller.skillStatus4 = P4SkillStatus4;
                        break;
                }
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
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
        StartCoroutine(ChangeScene("BattleScene"));
        // StartCoroutine(ChangeScene("SpellShopScene"));
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
