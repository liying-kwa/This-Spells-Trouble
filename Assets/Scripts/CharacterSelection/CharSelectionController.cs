using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelectionController : MonoBehaviour
{
    // ScriptableObjects
    public BoolArrVariable playersReady;

    // Game State
    public int playerID;
    public GameObject[] characters;
    public Text text;
    int selectedChar = 0;
    bool ready = false;
    

    private void OnPreviousCharacter() {
        characters[selectedChar].SetActive(false);
        selectedChar = (selectedChar + 1) % characters.Length;
        characters[selectedChar].SetActive(true);
    }

    private void OnNextCharacter() {
        characters[selectedChar].SetActive(false);
        selectedChar-= 1;
        if (selectedChar < 0){
            selectedChar += characters.Length;
        };
        characters[selectedChar].SetActive(true);
    }

    private void OnReady() {
        ready = !ready;
        playersReady.SetValue(playerID, ready);
        if (ready) {
            text.text = "Ready";
        } else {
            text.text = "";
        }
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        text.text = "";
        characters[selectedChar].SetActive(true);
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
