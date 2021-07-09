using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Spell{
    nullSpell = -1,
	fireball = 0,
	teleport = 1
}

[CreateAssetMenu(fileName = "ChosenSpellsArr", menuName = "ScriptableObjects/ChosenSpellsArr", order = 2)]
public class ChosenSpellsArr : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "Players' chosen spells. -1 indicates player has not bought any spell / has not tied a spell to that slot.";
#endif

    private int[,] _arr = new int[4, 4] { {-1, -1, -1, -1}, 
                                            {-1, -1, -1, -1}, 
                                            {-1, -1, -1, -1}, 
                                            {-1, -1, -1, -1} };

    public Spell GetSpell(int playerID, int slot) {
        int spellInt = _arr[playerID, slot];
        return (Spell) spellInt;
    }

    public void SetSpell(int playerID, int slot, Spell spell) {
        int spellInt = (int) spell;
       _arr[playerID, slot] = spellInt;
    }

    // overload
    public void SetValue(ChosenSpellsArr arr) {
        _arr = arr._arr;
    }
}
