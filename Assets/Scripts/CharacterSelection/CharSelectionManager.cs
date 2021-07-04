using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectionManager : MonoBehaviour
{
    // ScriptableObjects
    public BoolArrVariable playersJoined;
    public BoolArrVariable playersReady;

    // Game State
    bool allReady = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialise all values to false
        for (int i = 0; i < playersJoined.GetLength(); i++) {
            playersJoined.SetValue(i, false);
        }
        for (int i = 0; i < playersReady.GetLength(); i++) {
            playersReady.SetValue(i, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // At least 2 players have joined
        if (playersJoined.GetNumTrue() < 2) {
            allReady = false;
            return;
        }
        // Check if all ready, then countdown
        for (int i = 0; i < playersJoined.GetLength(); i++) {
            if (playersJoined.GetValue(i) == true) {
                if (playersReady.GetValue(i) == false) {
                    allReady = false;
                    return;
                }
            }
        }
        if (allReady) {
            // StartCountdown();
        } else {
            // Stop countdown, if running
        }
    }
}
