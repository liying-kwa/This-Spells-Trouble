using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    // ScriptableObjects
    public BoolArrVariable playersAreAlive;
    public BoolVariable roundEnded;

    // GameObjects
    //public AudioSource backgroundAudio;
    //public AudioClip victoryClip;
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
                onVictoryPlaySound.Raise();
                //backgroundAudio.Stop();
                //backgroundAudio.PlayOneShot(victoryClip);
                victoryText.text = "Player " + (winnerID+1) + " wins!";
            }
        }
    }
}
