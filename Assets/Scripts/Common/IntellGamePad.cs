using UnityEngine;
using System.Collections;
using XInputDotNetPure;

/// <summary>
/// Classe che contiene la struttura dati dei gamepad
/// </summary>
public class IntellGamePad {

    public int ID;
    public GamePadState OldGamePadState;

    public GamePadState CurrentGamePadState {
        get {
            return _currentGamePadState;
        }

        set {
            OldGamePadState = _currentGamePadState;
            _currentGamePadState = value;
        }
    }
    private GamePadState _currentGamePadState;

    public IntellGamePad(GamePadState gamePadState, int id) {
        CurrentGamePadState = gamePadState;
        ID = id;
    }

    public void ButtoXPressed(ButtonState eventState) {
        // Check da 
        //if(OldGamePadState.Buttons.X == ButtonState.Pressed 
        //    && CurrentGamePadState.Buttons.X == ButtonState.Pressed)
        
    }

}
