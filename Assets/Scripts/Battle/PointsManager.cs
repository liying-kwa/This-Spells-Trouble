using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    // ScriptableObjects
    public BoolArrVariable playersAreAlive;
    public BoolVariable roundEnded;
    public IntArrVariable playersPoints;
    public IntVariable currentRound;
    public PlayerInputsArr playerInputsArr;

    // GameObjects
    public Text victoryText;

    // Game state
    bool ended = false;

    // Sound Events
    [Header("Sound Events")]
    public GameEvent onVictoryPlaySound;

    // Start is called before the first frame update
    void Awake()
    {
        roundEnded.SetValue(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ended) {
            if (playersAreAlive.GetNumTrue() == 1) {
                int winnerID = -1;
                for (int i = 0; i < playersAreAlive.GetLength(); i++) {
                    if (playersAreAlive.GetValue(i)) {
                        winnerID = i;
                        break;
                    }
                }
                ended = true;
                roundEnded.SetValue(true);
                StartCoroutine(Victory(winnerID));
            }
        }
    }

    private IEnumerator Victory(int winnerID) {
        onVictoryPlaySound.Raise();
        playersPoints.SetValue(winnerID, playersPoints.GetValue(winnerID) + 1);
        // victoryText.text = "Player " + (winnerID+1) + " wins!";
        string toShow = "";
        for (int i = 0; i < 4; i++) {
            toShow += "Player " + (i+1) + " score: " + playersPoints.GetValue(i) + "\n";
        }
        victoryText.text = toShow;
        yield return new WaitForSeconds(10);
        // if (currentRound.Value < 1) {
        if (currentRound.Value < 5) {
            StartCoroutine(ChangeScene("SpellShopScene"));
        } else {
            // Destroy all playerObjects and move to victory scene
            for (int i = 0; i < 4; i++) {
                if (playerInputsArr.GetValue(i) != null) {
                    Destroy(playerInputsArr.GetValue(i).gameObject);
                    playerInputsArr.SetValue(i, null);
                }
            }
            StartCoroutine(ChangeScene("VictoryScene"));
        }
    }

    private IEnumerator ChangeScene(string sceneName) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }
}
