using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayersSpellLevels", menuName = "ScriptableObjects/PlayersSpellLevels", order = 2)]
public class PlayersSpellLevels : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "Players' spell levels. -1 indicates player has not bought that spell.";
#endif

    private int[,] _arr;

    public int GetSpellLevel(int playerID, Spell spell) {
        int spellInt = (int) spell;
        int spellLevel = _arr[playerID, spellInt];
        return spellLevel;
    }

    public void SetSpellLevel(int playerID, Spell spell, int spellLevel) {
        int spellInt = (int) spell;
       _arr[playerID, spellInt] = spellLevel;
    }

    // overload
    public void SetValue(PlayersSpellLevels arr) {
        _arr = arr._arr;
    }

    void Awake() {
        int maxSpellInt = System.Enum.GetValues(typeof(Spell)).Length;
        _arr = new int[4, maxSpellInt];
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < maxSpellInt; j++) {
                _arr[i, j] = -1;
            }
        }
    }
}
