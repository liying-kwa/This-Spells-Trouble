using UnityEngine;

[CreateAssetMenu(fileName =  "SpellModel", menuName =  "ScriptableObjects/SpellModel", order =  1)]
public  class SpellModel : ScriptableObject
{
	// set your data here
    public string Name;
    public Spell Spell;
    public string Description;
    public Texture Icon;
    public int Cost;
    public string Upgrade;

}