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
    public BoolArrVariable playersReady;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onArrowButtonPlaySound;
    public GameEvent onBuySpellPlaySound;
    public GameEvent onSellSpellPlaySound;
    public GameEvent onLockSlotPlaySound;
    public GameEvent onUnlockSlotPlaySound;
    public GameEvent onNotAllowedPlaySound;
    public GameEvent onReadyButtonPlaySound;

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
    public GameObject readyPanelObject;

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
    private bool slotIsLocked = false;
    bool ready = false;

    void OnLeftButton() {
        if (ready) {
            return;
        }
        if (!slotIsLocked) {
            // SELECT SLOT ON THE LEFT
            // Do nothing if a left slot is already selected
            if (selectedSlot == 0 || selectedSlot == 2) {
                return;
            }
            // Zoom and render the correct spell icon
            unrenderAndUnzoom(selectedSlot);
            selectedSlot -= 1;
            renderAndZoom(selectedSlot);
            onArrowButtonPlaySound.Raise();
        } else {
            // PREVIOUS SPELL
            // Do nothing if this is fireball slot OR if a spell is bought and tied to this slot
            if (selectedSlot == 1 || slotTiedToSpell[selectedSlot]) {
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
            onLockSlotPlaySound.Raise();
        }
    }

    void OnRightButton() {
        if (ready) {
            return;
        }
        if (!slotIsLocked) {
            // SELECT SLOT ON THE RIGHT
            // Do nothing if a right slot is already selected
            if (selectedSlot == 1 || selectedSlot == 3) {
                return;
            }
            // Zoom and render the correct spell icon
            unrenderAndUnzoom(selectedSlot);
            selectedSlot += 1;
            renderAndZoom(selectedSlot);
            onArrowButtonPlaySound.Raise();
        } else {
            // Next spell
            // Do nothing if this is fireball slot OR if a spell is bought for this slot
            if (selectedSlot == 1 || slotTiedToSpell[selectedSlot]) {
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
            onLockSlotPlaySound.Raise();
        }
    }

    void OnUpButton() {
        if (ready) {
            return;
        }
        if (slotIsLocked) {
            return;
        }
        // SELECT SLOT ABOVE
        // Do nothing if a slot at the top is already selected
        if (selectedSlot == 0 || selectedSlot == 1) {
            return;
        }
        // Zoom and render the correct spell icon
        unrenderAndUnzoom(selectedSlot);
        selectedSlot -= 2;
        renderAndZoom(selectedSlot);
        onArrowButtonPlaySound.Raise();
    }

    void OnDownButton() {
        if (ready) {
            return;
        }
        if (slotIsLocked) {
            return;
        }
        // SELECT SLOT BELOW
        // Do nothing if a slot at the bottom is already selected
        if (selectedSlot == 2 || selectedSlot == 3) {
            return;
        }
        // Zoom and render the correct spell icon
        unrenderAndUnzoom(selectedSlot);
        selectedSlot += 2;
        renderAndZoom(selectedSlot);
        onArrowButtonPlaySound.Raise();
    }

    void OnButtonA() {
        if (ready) {
            return;
        }
        // Select slot
        if (!slotIsLocked && selectedSlot != 1) {
            slotIsLocked = true;
            slotIcons[selectedSlot].GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
            onLockSlotPlaySound.Raise();
            return;
        }
        // BUY/UPGRADE SPELL
        // Do nothing if slot is not locked OR if a spell is tied to that slot OR if it is an empty spell
        if (!slotIsLocked || slotTiedToSpell[selectedSlot] || selectedSpellInt == -1) {
            return;
        }
        // Check if enough gold
        if (goldAmount < allSpellModels[(int) selectedSpell].Cost) {
            onNotAllowedPlaySound.Raise();
            return;
        }
        goldAmount -= allSpellModels[(int) selectedSpell].Cost;
        goldText.text = "Gold: " + goldAmount;
        playersGold.SetValue(playerID, goldAmount);
        slotTiedToSpell[selectedSlot] = true;
        playersSpells.SetSpell(playerID, selectedSlot, selectedSpell);
        onBuySpellPlaySound.Raise();
    }

    void OnButtonB() {
        if (ready) {
            return;
        }
        // Unselect slot
        if (slotIsLocked && selectedSlot != 1) {
            slotIsLocked = false;
            slotIcons[selectedSlot].GetComponent<RawImage>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
        }
        // Unrender if nothing is bought
        if (!slotTiedToSpell[selectedSlot]) {
            renderSpell(Spell.nullSpell, selectedSlot);
            selectedSpell = Spell.nullSpell;
            selectedSpellInt = -1;
        }
        onUnlockSlotPlaySound.Raise();
    }

    void OnButtonY() {
        if (ready) {
            return;
        }
        // SELL/DOWNGRADE SPELL
        // Do nothing if slot is not locked OR if it is the fireball slot OR no spell is bought for that slot
        if (!slotIsLocked || selectedSlot == 1 || !slotTiedToSpell[selectedSlot]) {
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
        onSellSpellPlaySound.Raise();
    }

    private void OnButtonStart() {
        ready = !ready;
        playersReady.SetValue(playerID, ready);
        if (ready) {
            readyPanelObject.SetActive(true);
            onReadyButtonPlaySound.Raise();
        } else {
            readyPanelObject.SetActive(false);
        }
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
        ready = false;
        slotIsLocked = false;
        selectedSlot = 0;
        selectedSpellInt = -1;
        selectedSpell = Spell.nullSpell;
        slotIcons[0].transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        slotIcons[1].transform.localScale = new Vector3(0.2772619f, 0.2772619f, 0.2772619f);
        slotIcons[2].transform.localScale = new Vector3(0.2772619f, 0.2772619f, 0.2772619f);
        slotIcons[3].transform.localScale = new Vector3(0.2772619f, 0.2772619f, 0.2772619f);
        slotIcons[0].GetComponent<RawImage>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
        slotIcons[1].GetComponent<RawImage>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
        slotIcons[2].GetComponent<RawImage>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
        slotIcons[3].GetComponent<RawImage>().color = new Color(0.6f, 0.6f, 0.6f, 0.8f);
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

    void unrenderAndUnzoom(int slot) {
        // Render earlier slot icon to be nothing if no spell is bought and unzoom that slot
        if (!slotTiedToSpell[slot]) {
            renderSpell(Spell.nullSpell, slot);
        }
        slotIcons[slot].transform.localScale = new Vector3(0.2772619f, 0.2772619f, 0.2772619f);
    }

    void renderAndZoom(int slot) {
        // Render icon to display spell bought or empty if nothing and zoom chosen slot
        if (slotTiedToSpell[slot] == false) {
            selectedSpellInt = -1;
        }
        Spell spell = playersSpells.GetSpell(playerID, slot);
        renderSpell(spell, slot);
        slotIcons[slot].transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
    }
}
