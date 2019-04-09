using System;
using System.Collections;
using System.Collections.Generic;
using TellInput;
using UnityEngine;
using XInputDotNetPure;
using System.Linq;

/// <summary>
/// Classe che fornisce le informazioni sullo stato dei gamepad collegati.
/// </summary>
public class InputChecker : MonoBehaviour {

    #region Delegates
    public static Action<IntellGamePad> OnGamepadConnected;
    public static Action<IntellGamePad> OnGamepadDisconnected;
    #endregion

    #region properties
    public IntellGamePad.Settings defaultGamepadSettings;
    /// <summary>
    /// Lista dei gamepad attivi.
    /// </summary>
    public List<IntellGamePad> Activegamepads { get; protected set; }
    #endregion

    public static InputChecker instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            Activegamepads = new List<IntellGamePad>();
        }
    }

    /// <summary>
    /// Itera per tutta le vita della classe il controllo dello stato dei gamepad tramite xinput 
    /// </summary>
    /// <returns></returns>
    private void Update() {
        DoCheckInput();
    }

    /// <summary>
    /// Aggiorna la lista dello stato dei gamepad (Activegamepads).
    /// </summary>
    /// <returns></returns>
    private void DoCheckInput() {
        for (int i = 0; i < 4; ++i) {
            PlayerIndex testPlayerIndex = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(testPlayerIndex);
            if (testState.IsConnected) {
                IntellGamePad newPad = Activegamepads.FirstOrDefault(gpad => gpad.ID == i);
                if (newPad != null) {
                    newPad.CurrentGamePadState = testState;
                } else {
                    IntellGamePad padToAdd = new IntellGamePad(testState, i);
                    Activegamepads.Add(padToAdd);
                    padToAdd.SetSettings(defaultGamepadSettings);
                    OnGamepadConnected?.Invoke(padToAdd);
                }
            } else {
                IntellGamePad padToRemove = Activegamepads.FirstOrDefault(gpad => gpad.ID == i);
                if (padToRemove != null) {
                    Activegamepads.RemoveAt(i);
                    OnGamepadDisconnected?.Invoke(padToRemove);
                }
            }
        }
    }

    #region Getter

    #endregion
}
