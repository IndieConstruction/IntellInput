using System;
using System.Collections;
using System.Collections.Generic;
using TellInput;
using UnityEngine;
using XInputDotNetPure;

/// <summary>
/// Classe che fornisce le informazioni sullo stato dei gamepad collegati.
/// </summary>
public class InputChecker : MonoBehaviour {

    #region Delegates
    public static Action<InputType> OnInputChanged;
    #endregion

    #region properties
    /// <summary>
    /// Lista dei gamepad attivi.
    /// </summary>
    public List<IntellGamePad> Activegamepads { get; protected set; }
    #endregion

    public static InputChecker instance;

    private bool playerIndexSet = false;
    private PlayerIndex joystickPlayerIndex;
    private InputType currentinputType;


    private void Awake() {
        if (instance == null) {
            instance = this;
            // Itera per tutta le vita della classe il controllo dello stato dei gamepad tramite xinput 
            StartCoroutine(CheckInputRoutine());
        }
    }

    /// <summary>
    /// Coroutine che in loop controlla il tipo di input in uso
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckInputRoutine() {
        while (true) {
            DoCheckInput();
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    /// <summary>
    /// Aggiorna la lista dello stato dei gamepad (Activegamepads).
    /// </summary>
    /// <returns></returns>
    private void DoCheckInput() {

        playerIndexSet = false;
        Activegamepads = new List<IntellGamePad>();
        for (int i = 0; i < 4; ++i) {
            PlayerIndex testPlayerIndex = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(testPlayerIndex);
            if (testState.IsConnected) {
                Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                joystickPlayerIndex = testPlayerIndex;
                playerIndexSet = true;
                Activegamepads.Add(new IntellGamePad(testState, i));
            }
        }

        if (currentinputType == InputType.None || (playerIndexSet && currentinputType == InputType.Keyboard)) {
            currentinputType = InputType.Joystick;
            if (OnInputChanged != null)
                OnInputChanged(currentinputType);
        } else if (currentinputType == InputType.None || (!playerIndexSet && currentinputType == InputType.Joystick)) {
            currentinputType = InputType.Keyboard;
            if (OnInputChanged != null)
                OnInputChanged(currentinputType);
        }
    }

    #region Getter
    /// <summary>
    /// Funzione che ritorna il tipo di input attuale
    /// </summary>
    /// <returns></returns>
    public static InputType GetCurrentInputType() {
        return instance.currentinputType;
    }

    /// <summary>
    /// Funzione che ritorna lo stato del joystcik collegato
    /// </summary>
    /// <returns></returns>
    public static GamePadState GetCurrentGamePadState() {
        return GamePad.GetState(instance.joystickPlayerIndex);
    }

    /// <summary>
    /// Funzione che ritorna il player index del joystick attivo
    /// </summary>
    /// <returns></returns>
    public static PlayerIndex GetJoystickPlayerIndex() {
        return instance.joystickPlayerIndex;
    }
    #endregion

}
