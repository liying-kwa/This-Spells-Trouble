using UnityEngine;

[CreateAssetMenu(fileName =  "SkillName", menuName =  "ScriptableObjects/Skill", order =  1)]
public  class SkillModel : ScriptableObject
{
	// set your data here
    public string Name;
    public string Description;
    public float Damage;
    public int Cost;
    public GameObject SkillPrefab;
    public string Upgrade;

}