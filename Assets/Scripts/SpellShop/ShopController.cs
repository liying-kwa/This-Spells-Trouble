using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    // ScriptableObjects
    public PlayersSpells playersSpells;
    public PlayersSpellLevels playersSpellLevels;
    public IntArrVariable playersGold;
    public GameConstants gameConstants;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onArrowButtonPlaySound;
    public GameEvent onBuySpellPlaySound;

    // GameObjects
    public SpellModel[] allSpellModels;
    public Texture emptyIcon;
    public GameObject[] slotIcons;
    public GameObject spellInfo;
    public Text spellNameText;
    public Text spellCostText;
    public Text spellDescText;
    public Text spellUpgradeText;
    public Text goldText;

    // public List<GameObject> skillStatus1;
    // public List<GameObject> skillStatus2;
    // public List<GameObject> skillStatus3;
    // public List<GameObject> skillStatus4;
    // private List<List<GameObject>> skillStatus;
    // private int[] skillMapping; // Maps slot to GameObjects
    // private int previousSelection;

    // Game State
    public int playerID;
    private int selectedSlot = 0;
    private int selectedSpellInt = -1;  // this is w.r.t. index in either offensiveSpellModels or defensiveSpellModels
    private Spell selectedSpell = Spell.nullSpell;
    private Vector3 spellInfoInitialPosition;
    private bool[] slotTiedToSpell = {false, false, false, false};
    private List<SpellModel> offensiveSpellModels;
    private List<SpellModel> defensiveSpellModels;
    private int goldAmount;


    private void OnPreviousSlot() {
        if (selectedSlot == 0) {
            return;
        }
        // Render earlier slot icon to be nothing if no spell is bought
        if (!slotTiedToSpell[selectedSlot]) {
            renderSpell(Spell.nullSpell, selectedSlot);
        }
        selectedSlot -= 1;
        // Render icon to display spell bought, or empty if nothing
        if (slotTiedToSpell[selectedSlot] == false) {
            selectedSpellInt = -1;
        }
        Spell spell = playersSpells.GetSpell(playerID, selectedSlot);
        renderSpell(spell, selectedSlot);
        // Shift the spellInfo gameobject group position
        spellInfo.transform.localPosition = new Vector3(0, spellInfoInitialPosition.y - selectedSlot * 70f, 0);
        // Zoom selected slot and unzoom earlier slot
        slotIcons[selectedSlot+1].transform.localScale = new Vector3(0.2772619f, 0.2772619f, 0.2772619f);
        slotIcons[selectedSlot].transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        onArrowButtonPlaySound.Raise();
        
    }

    private void OnNextSlot() {
        if (selectedSlot == 3) {
            return;
        }
        // Render earlier slot icon to be nothing if no spell is bought
        if (!slotTiedToSpell[selectedSlot]) {
            renderSpell(Spell.nullSpell, selectedSlot);
        }
        selectedSlot += 1;
        // Render icon to display skill bought, or empty if nothing
        if (slotTiedToSpell[selectedSlot] == false) {
            selectedSpellInt = -1;
        }
        Spell spell = playersSpells.GetSpell(playerID, selectedSlot);
        renderSpell(spell, selectedSlot);
        // Shift the skillInfo gameobject group position
        spellInfo.transform.localPosition = new Vector3(0, spellInfoInitialPosition.y - selectedSlot * 70f, 0);
        // Zoom selected slot and unzoom earlier slot
        slotIcons[selectedSlot-1].transform.localScale = new Vector3(0.2772619f, 0.2772619f, 0.2772619f);
        slotIcons[selectedSlot].transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        onArrowButtonPlaySound.Raise();
    }

    private void OnPreviousSpell() {
        // Fireball slot fixed
        if (selectedSlot == 1) {
            return;
        }
        // If a bought spell is tied to that slot, cannot view other spells in that slot until that spell is sold
        if (slotTiedToSpell[selectedSlot] == true) {
            return;
        }
        // Otherwise, render the correct offensive/defensive spell
        if (selectedSpellInt != -1) {
            selectedSpellInt -= 1;
        }
        if (selectedSlot == 0) {
            // Defensive spell slot
            if (selectedSpellInt < 0) {
                selectedSpellInt += defensiveSpellModels.Count;
            }
            Spell spell = defensiveSpellModels[selectedSpellInt].Spell;
            renderSpell(spell, selectedSlot);
        } else {
            // Offensive spell slot
            if (selectedSpellInt < 0) {
                selectedSpellInt += offensiveSpellModels.Count;
            }
            Spell spell = offensiveSpellModels[selectedSpellInt].Spell;
            renderSpell(spell, selectedSlot);
        }
        onArrowButtonPlaySound.Raise();
    }

    private void OnNextSpell() {
        // Fireball slot fixed
        if (selectedSlot == 1) {
            return;
        }
        // If a bought spell is tied to that slot, cannot view other spells in that slot until that spell is sold
        if (slotTiedToSpell[selectedSlot] == true) {
            return;
        }
        // Otherwise, render the correct offensive/defensive spell
        selectedSpellInt += 1;
        if (selectedSlot == 0) {
            // Defensive spell slot
            if (selectedSpellInt >= defensiveSpellModels.Count) {
                selectedSpellInt -= defensiveSpellModels.Count;
            }
            Spell spell = defensiveSpellModels[selectedSpellInt].Spell;
            renderSpell(spell, selectedSlot);
        } else {
            // Offensive spell slot
            if (selectedSpellInt >= offensiveSpellModels.Count) {
                selectedSpellInt -= offensiveSpellModels.Count;
            }
            Spell spell = offensiveSpellModels[selectedSpellInt].Spell;
            renderSpell(spell, selectedSlot);
        }
        onArrowButtonPlaySound.Raise();
    }

    void OnBuySpell() {
        // Do nothing if a spell is tied to that slot or if it is an empty spell
        if (slotTiedToSpell[selectedSlot] || selectedSpellInt == -1) {
            return;
        }
        // Check if enough gold
        if (goldAmount < allSpellModels[(int) selectedSpell].Cost) {
            return;
        }
        goldAmount -= allSpellModels[(int) selectedSpell].Cost;
        goldText.text = "Gold: " + goldAmount;
        playersGold.SetValue(playerID, goldAmount);
        slotTiedToSpell[selectedSlot] = true;
        playersSpells.SetSpell(playerID, selectedSlot, selectedSpell);
        onBuySpellPlaySound.Raise();
    }

    void OnSellSpell() {
        // Do nothing if it is the fireball slot, or not bought
        if (selectedSlot == 1 || !slotTiedToSpell[selectedSlot]) {
            return;
        }
        // Add gold, sell spell, remove icon and reset selectedSpell
        Spell soldSpell = playersSpells.GetSpell(playerID, selectedSlot);
        goldAmount += allSpellModels[(int) soldSpell].Cost;
        goldText.text = "Gold: " + goldAmount;
        playersGold.SetValue(playerID, goldAmount);
        slotTiedToSpell[selectedSlot] = false;
        playersSpells.SetSpell(playerID, selectedSlot, Spell.nullSpell);
        renderSpell(Spell.nullSpell, selectedSlot);
        selectedSpellInt = -1;
        selectedSpell = Spell.nullSpell;
        onBuySpellPlaySound.Raise();
    }

    void OnEnable() {
        refreshShopController();
    }

    void refreshShopController() {
        // Initialise some values
        for (int i = 3; i >= 0; i--) {
            // Render initial icons. Last one is first spell so no need to re-render.
            Spell spell = playersSpells.GetSpell(playerID, i);
            // renderSpell(spell, selectedSlot);
            renderSpell(spell, i);
            if ((int) spell == -1) {
                slotTiedToSpell[i] = false;
            } else {
                slotTiedToSpell[i] = true;
            }
        }
        // Give gold to players after every round
        goldAmount = playersGold.GetValue(playerID);
        goldAmount += gameConstants.goldIncrement;
        playersGold.SetValue(playerID, goldAmount);
        goldText.text = "Gold: " + goldAmount.ToString();

        // Zoom into first slot, unzoom the others
        selectedSlot = 0;
        selectedSpellInt = -1;
        selectedSpell = Spell.nullSpell;
        slotIcons[0].transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        slotIcons[1].transform.localScale = new Vector3(0.2772619f, 0.2772619f, 0.2772619f);
        slotIcons[2].transform.localScale = new Vector3(0.2772619f, 0.2772619f, 0.2772619f);
        slotIcons[3].transform.localScale = new Vector3(0.2772619f, 0.2772619f, 0.2772619f);
    }

    void Start() {
        // Separate into offensive and defensive spells
        defensiveSpellModels = new List<SpellModel>();
        offensiveSpellModels = new List<SpellModel>();
        for (int i = 0; i < allSpellModels.Length; i++) {
            switch (allSpellModels[i].Spell) {
                case Spell.teleport:
                case Spell.rush:
                case Spell.cloud:
                case Spell.wall:
                    defensiveSpellModels.Add(allSpellModels[i]);
                    break;
                case Spell.fireball:
                case Spell.lightning:
                case Spell.tornado:
                case Spell.arc:
                case Spell.splitter:
                case Spell.boomerang:
                case Spell.laser:
                case Spell.minethrow:
                case Spell.groundattack:
                case Spell.iceattack:
                case Spell.shockwave:
                    offensiveSpellModels.Add(allSpellModels[i]);
                    break;
            }
        }
        // Initialise some values
        spellInfoInitialPosition = spellInfo.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void renderSpell(Spell spell, int selectedSlot) {
        // SpellModel spellModel;
        // switch (spell) {
        //     case Spell.fireball:
        //         spellModel = allSpellModels[(int) Spell.fireball];
        //         selectedSpell = Spell.fireball;
        //         break;
        //     case Spell.teleport:
        //         spellModel = allSpellModels[(int) Spell.teleport];
        //         selectedSpell = Spell.teleport;
        //         break;
        //     case Spell.lightning:
        //         spellModel = allSpellModels[(int) Spell.lightning];
        //         selectedSpell = Spell.lightning;
        //         break;
        //     case Spell.tornado:
        //         spellModel = allSpellModels[(int) Spell.tornado];
        //         selectedSpell = Spell.tornado;
        //         break;
        //     case Spell.rush:
        //         spellModel = allSpellModels[(int) Spell.rush];
        //         selectedSpell = Spell.rush;
        //         break;
        //     case Spell.arc:
        //         spellModel = allSpellModels[(int) Spell.arc];
        //         selectedSpell = Spell.arc;
        //         break;
        //     case Spell.splitter:
        //         spellModel = allSpellModels[(int) Spell.splitter];
        //         selectedSpell = Spell.splitter;
        //         break;
        //     case Spell.boomerang:
        //         spellModel = allSpellModels[(int) Spell.boomerang];
        //         selectedSpell = Spell.boomerang;
        //         break;
        //     default:
        //         slotIcons[selectedSlot].GetComponent<RawImage>().texture = emptyIcon;
        //         selectedSpell = Spell.nullSpell;
        //         // TODO: set spellinfo to inactive?
        //         spellNameText.text = "";
        //         spellCostText.text = "";
        //         spellDescText.text = "";
        //         spellUpgradeText.text = "";
        //         return;
        // }
        // slotIcons[selectedSlot].GetComponent<RawImage>().texture = spellModel.Icon;
        // spellNameText.text = spellModel.Name;
        // spellCostText.text = spellModel.Cost.ToString();
        // spellDescText.text = spellModel.Description;
        // spellUpgradeText.text = spellModel.Upgrade;

        if (spell == Spell.nullSpell) {
            slotIcons[selectedSlot].GetComponent<RawImage>().texture = emptyIcon;
            selectedSpell = Spell.nullSpell;
            // TODO: set spellinfo to inactive?
            spellNameText.text = "";
            spellCostText.text = "";
            spellDescText.text = "";
            spellUpgradeText.text = "";
        } else {
            SpellModel spellModel = allSpellModels[(int) spell];
            selectedSpell = spell;
            slotIcons[selectedSlot].GetComponent<RawImage>().texture = spellModel.Icon;
            spellNameText.text = spellModel.Name;
            spellCostText.text = spellModel.Cost.ToString();
            spellDescText.text = spellModel.Description;
            spellUpgradeText.text = spellModel.Upgrade;
        }
    }
}
