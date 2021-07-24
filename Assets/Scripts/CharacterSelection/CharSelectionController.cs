using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelectionController : MonoBehaviour
{
    // ScriptableObjects
    public BoolArrVariable playersReady;
    public IntArrVariable playersChars;
    public ChosenSpellsArr playersSpells;

    // Components
    //private AudioSource audioSource;
    //public AudioClip scrollAudio;
    //public AudioClip readyAudio;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onReadyButtonPlaySound;
    public GameEvent onJoinButtonPlaySound;
    public GameEvent onArrowButtonPlaySound;

    // Game State
    public int playerID;
    public GameObject[] characters;
    public Text text;
    int selectedChar = 0;
    bool ready = false;
    

    private void OnNextCharacter() {
        if (!ready) {
            characters[selectedChar].SetActive(false);
            selectedChar = (selectedChar + 1) % characters.Length;
            characters[selectedChar].SetActive(true);
            playersChars.SetValue(playerID, selectedChar);
            //audioSource.PlayOneShot(scrollAudio);
            onArrowButtonPlaySound.Raise();
        }
    }

    private void OnPreviousCharacter() {
        if (!ready) {
            characters[selectedChar].SetActive(false);
            selectedChar-= 1;
            if (selectedChar < 0){
                selectedChar += characters.Length;
            };
            characters[selectedChar].SetActive(true);
            playersChars.SetValue(playerID, selectedChar);
            //audioSource.PlayOneShot(scrollAudio);
            onArrowButtonPlaySound.Raise();
        }
    }

    private void OnReady() {
        ready = !ready;
        playersReady.SetValue(playerID, ready);
        if (ready) {
            text.text = "Ready";
            //audioSource.PlayOneShot(readyAudio);
            onReadyButtonPlaySound.Raise();
        } else {
            text.text = "";
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        text.text = "";
        characters[selectedChar].SetActive(true);
        playersChars.SetValue(playerID, 0);
        DontDestroyOnLoad(this.gameObject);
        // Maybe shift this to somewhere else in the future
        playersSpells.SetSpell(playerID, 1, Spell.fireball);
        // Test spells here
        playersSpells.SetSpell(playerID, 0, Spell.teleport);
        playersSpells.SetSpell(playerID, 2, Spell.lightning);
        playersSpells.SetSpell(playerID, 3, Spell.tornado);
        onJoinButtonPlaySound.Raise();
        Debug.Log("onJoinButtonPlaySound played!");
    }

    void Start() {
        //audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(scrollAudio);
        //onJoinButtonPlaySound.Raise();
        //Debug.Log("onJoinButtonPlaySound played!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
