using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using System;

/// <summary>
/// Classe che contiene la struttura dati dei gamepad
/// </summary>
public class IntellGamePad {
    #region Delegates
    public Action<IntellGamePad, Buttons> OnButtonPressed;
    public Action<IntellGamePad, Buttons> OnButtonHold;
    public Action<IntellGamePad, Buttons> OnButtonReleased;
    public Action<IntellGamePad, Buttons, AxisValue> OnAxisUsed;
    public Action<IntellGamePad, Buttons, AxisValue> OnAxisStopUsed;
    #endregion

    #region Struct
    [Serializable]
    public struct Settings {
        [Range(0, 1)]
        public float rightStickDeadzone;
        [Range(0, 1)]
        public float leftStickDeadzone;

        public Settings(float _rightStickDeadzone, float _leftStickDeadzone) {
            rightStickDeadzone = Mathf.Abs(_rightStickDeadzone);
            leftStickDeadzone = Mathf.Abs(_leftStickDeadzone);
        }
    }

    public enum Buttons {
        None = 0,
        A = 1,
        B = 2,
        X = 3,
        Y = 4,
        RB = 5,
        LB = 6,
        Start = 7,
        Pause = 8,
        Guide = 9,
        LeftStickButton = 10,
        RightStickButton = 11,
        DPadDown = 12,
        DPadUp = 13,
        DPadRight = 14,
        DPadLeft = 15,
        LeftStick = 16,
        RightStick = 17,
        LT = 18,
        RT = 19,
    }

    public struct AxisValue {
        public float X;
        public float Y;

        public AxisValue(float _x, float _y) {
            X = _x;
            Y = _y;
        }
    }
    #endregion

    public Settings currentSettings;
    public int ID;
    public GamePadState OldGamePadState;

    public GamePadState CurrentGamePadState {
        get {
            return _currentGamePadState;
        }

        set {
            OldGamePadState = _currentGamePadState;
            _currentGamePadState = value;
            CheckButtons();
        }
    }
    private GamePadState _currentGamePadState;

    public IntellGamePad(GamePadState gamePadState, int id) {
        CurrentGamePadState = gamePadState;
        ID = id;
    }

    private void CheckButtons() {
        //X Button
        if (OldGamePadState.Buttons.X == ButtonState.Released && CurrentGamePadState.Buttons.X == ButtonState.Pressed) {
            OnButtonPressed?.Invoke(this, Buttons.X);
        } else if (OldGamePadState.Buttons.X == ButtonState.Pressed && CurrentGamePadState.Buttons.X == ButtonState.Pressed) {
            OnButtonHold?.Invoke(this, Buttons.X);
        } else if (OldGamePadState.Buttons.X == ButtonState.Pressed && CurrentGamePadState.Buttons.X == ButtonState.Released) {
            OnButtonReleased?.Invoke(this, Buttons.X);
        }

        //Left Axis
        float lsX = CurrentGamePadState.ThumbSticks.Left.X;
        float lsY = CurrentGamePadState.ThumbSticks.Left.Y;
        float oldlsX = OldGamePadState.ThumbSticks.Left.X;
        float oldlsY = OldGamePadState.ThumbSticks.Left.Y;

        if ((lsX > currentSettings.leftStickDeadzone || lsX < -currentSettings.leftStickDeadzone) ||
            (lsY > currentSettings.leftStickDeadzone || lsY < -currentSettings.leftStickDeadzone)) {
            OnAxisUsed?.Invoke(this, Buttons.LeftStick, new AxisValue(lsX, lsY));
        } else if ((currentSettings.leftStickDeadzone > lsX && lsX < -currentSettings.leftStickDeadzone) &&
                   (currentSettings.leftStickDeadzone > lsY && lsY < -currentSettings.leftStickDeadzone) &&
                   (oldlsX > currentSettings.leftStickDeadzone || oldlsX < -currentSettings.leftStickDeadzone) ||
                   (oldlsY > currentSettings.leftStickDeadzone || oldlsY < -currentSettings.leftStickDeadzone)) {
            OnAxisStopUsed?.Invoke(this, Buttons.LeftStick, new AxisValue(lsX, lsY));
        }
    }

    public void SetSettings(Settings _settings) {
        currentSettings = _settings;
    }
}
