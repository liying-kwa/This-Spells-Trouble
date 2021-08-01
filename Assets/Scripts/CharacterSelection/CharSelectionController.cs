using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelectionController : MonoBehaviour
{
    // ScriptableObjects
    public BoolArrVariable playersReady;
    public IntArrVariable playersChars;
    public PlayersSpells playersSpells;
    public IntArrVariable playersGold;
    public IntArrVariable playersPoints;

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

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        text.text = "";
        characters[selectedChar].SetActive(true);
        // Initialise some values
        playersChars.SetValue(playerID, 0);
        playersGold.SetValue(playerID, 0);
        playersPoints.SetValue(playerID, 0);
        playersSpells.SetSpell(playerID, 1, Spell.fireball);
        // TODO: fireball spell level
        onJoinButtonPlaySound.Raise();
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
