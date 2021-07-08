using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelectionController : MonoBehaviour
{
    // ScriptableObjects
    public BoolArrVariable playersReady;
    public IntArrVariable playersChars;

    // Components
    private AudioSource audioSource;
    public AudioClip scrollAudio;
    public AudioClip readyAudio;

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
            audioSource.PlayOneShot(scrollAudio);
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
            audioSource.PlayOneShot(scrollAudio);
        }
    }

    private void OnReady() {
        ready = !ready;
        playersReady.SetValue(playerID, ready);
        if (ready) {
            text.text = "Ready";
            audioSource.PlayOneShot(readyAudio);
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
    }

    void Start() {
        // Get components
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
