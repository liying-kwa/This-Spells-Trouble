using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // ScriptableObjects
    public IntArrVariable playersChars;
    public PlayersSpells playersSpells;
    public IntArrVariable playersGold;
    public IntArrVariable playersPoints;

    // GameObjects
    public Button[] buttons;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onReadyButtonPlaySound;
    public GameEvent onArrowButtonPlaySound;

    // Game State
    int selectedButton = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set frame rate to be 50 FPS
	    Application.targetFrameRate =  50;

        // Select first button
        buttons[0].Select();
        buttons[0].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        // Initialise values for all scriptable objects
        for (int i = 0; i < 4; i++) {
            playersChars.SetValue(i, -1);
            playersGold.SetValue(i, -1);
            playersPoints.SetValue(i, -1);
            playersSpells.SetSpell(i, 0, Spell.nullSpell);
            playersSpells.SetSpell(i, 1, Spell.nullSpell);
            playersSpells.SetSpell(i, 2, Spell.nullSpell);
            playersSpells.SetSpell(i, 3, Spell.nullSpell);
            // TODO: spell levels
            // TODO: Maybe move currentRound and currentMap from CharSelectionManager into here?
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoined(PlayerInput playerInput) {
        GameObject playerObject = playerInput.gameObject;
        playerObject.GetComponent<MenuController>().menuManager = this;
    }

    public void previousButton() {
        buttons[selectedButton].transform.localScale = new Vector3(1, 1, 1);
        selectedButton -= 1;
        if (selectedButton < 0) {
            selectedButton += buttons.Length;
        }
        buttons[selectedButton].Select();
        buttons[selectedButton].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        onArrowButtonPlaySound.Raise();
    }

    public void nextButton() {
        buttons[selectedButton].transform.localScale = new Vector3(1, 1, 1);
        selectedButton += 1;
        if (selectedButton >= buttons.Length) {
            selectedButton -= buttons.Length;
        }
        buttons[selectedButton].Select();
        buttons[selectedButton].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        onArrowButtonPlaySound.Raise();
    }

    public void clickButton() {
        ExecuteEvents.Execute(buttons[selectedButton].gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
        onReadyButtonPlaySound.Raise();
    }

    public void PlayGame() {
        // SceneManager.LoadScene("NAME_OF_SCENE_HERE");
        StartCoroutine(ChangeScene("CharSelectionScene"));
        Debug.Log("Loading Scene...");
    }

    public void QuitGame() {
        Application.Quit();
    }

    IEnumerator ChangeScene(string sceneName) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
