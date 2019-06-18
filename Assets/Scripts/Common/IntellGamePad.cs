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
    public Action<IntellGamePad, Buttons, float> OnTriggerUsed;
    public Action<IntellGamePad, Buttons, float> OnTriggerStopUsed;
    #endregion  

    #region Struct
    [Serializable]
    public struct Settings {
        [Range(0, 1)]
        public float rightStickDeadzone;
        [Range(0, 1)]
        public float leftStickDeadzone;
        [Range(0, 1)]
        public float RTDeadzone;
        [Range(0, 1)]
        public float LTDeadzone;

        public Settings(float _rightStickDeadzone, float _leftStickDeadzone , float _RTDeadzone = 0, float _LTDeadzone = 0) {
            rightStickDeadzone = Mathf.Abs(_rightStickDeadzone);
            leftStickDeadzone = Mathf.Abs(_leftStickDeadzone);
            RTDeadzone = Mathf.Abs(_RTDeadzone);
            LTDeadzone = Mathf.Abs(_LTDeadzone);
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

    #region Buttons Events
    private void CheckButtons() {
        //X Button
        if (OldGamePadState.Buttons.X == ButtonState.Released && CurrentGamePadState.Buttons.X == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.X);
        }
        else if (OldGamePadState.Buttons.X == ButtonState.Pressed && CurrentGamePadState.Buttons.X == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.X);
        }
        else if (OldGamePadState.Buttons.X == ButtonState.Pressed && CurrentGamePadState.Buttons.X == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.X);
        }
        //A Button
        if (OldGamePadState.Buttons.A == ButtonState.Released && CurrentGamePadState.Buttons.A == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.A);
        }
        else if (OldGamePadState.Buttons.A == ButtonState.Pressed && CurrentGamePadState.Buttons.A == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.A);
        }
        else if (OldGamePadState.Buttons.A == ButtonState.Pressed && CurrentGamePadState.Buttons.A == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.A);
        }
        //B Button
        if (OldGamePadState.Buttons.B == ButtonState.Released && CurrentGamePadState.Buttons.B == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.B);
        }
        else if (OldGamePadState.Buttons.B == ButtonState.Pressed && CurrentGamePadState.Buttons.B == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.B);
        }
        else if (OldGamePadState.Buttons.B == ButtonState.Pressed && CurrentGamePadState.Buttons.B == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.B);
        }
        //Y Button
        if (OldGamePadState.Buttons.Y == ButtonState.Released && CurrentGamePadState.Buttons.Y == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.Y);
        }
        else if (OldGamePadState.Buttons.Y == ButtonState.Pressed && CurrentGamePadState.Buttons.Y == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.Y);
        }
        else if (OldGamePadState.Buttons.Y == ButtonState.Pressed && CurrentGamePadState.Buttons.Y == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.Y);
        }
        //Start Button
        if (OldGamePadState.Buttons.Start == ButtonState.Released && CurrentGamePadState.Buttons.Start == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.Start);
        }
        else if (OldGamePadState.Buttons.Start == ButtonState.Pressed && CurrentGamePadState.Buttons.Start == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.Start);
        }
        else if (OldGamePadState.Buttons.Start == ButtonState.Pressed && CurrentGamePadState.Buttons.Start == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.Start);
        }
        //Pause Button
        if (OldGamePadState.Buttons.Back == ButtonState.Released && CurrentGamePadState.Buttons.Back == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.Pause);
        }
        else if (OldGamePadState.Buttons.Back == ButtonState.Pressed && CurrentGamePadState.Buttons.Back == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.Pause);
        }
        else if (OldGamePadState.Buttons.Back == ButtonState.Pressed && CurrentGamePadState.Buttons.Back == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.Pause);
        }
        //RB Button
        if (OldGamePadState.Buttons.RightShoulder == ButtonState.Released && CurrentGamePadState.Buttons.RightShoulder == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.RB);
        }
        else if (OldGamePadState.Buttons.RightShoulder == ButtonState.Pressed && CurrentGamePadState.Buttons.RightShoulder == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.RB);
        }
        else if (OldGamePadState.Buttons.RightShoulder == ButtonState.Pressed && CurrentGamePadState.Buttons.RightShoulder == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.RB);
        }
        //LB Button
        if (OldGamePadState.Buttons.LeftShoulder == ButtonState.Released && CurrentGamePadState.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.LB);
        }
        else if (OldGamePadState.Buttons.LeftShoulder == ButtonState.Pressed && CurrentGamePadState.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.LB);
        }
        else if (OldGamePadState.Buttons.LeftShoulder == ButtonState.Pressed && CurrentGamePadState.Buttons.LeftShoulder == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.LB);
        }
        //Guide Button
        if (OldGamePadState.Buttons.Guide == ButtonState.Released && CurrentGamePadState.Buttons.Guide == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.Guide);
        }
        else if (OldGamePadState.Buttons.Guide == ButtonState.Pressed && CurrentGamePadState.Buttons.Guide == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.Guide);
        }
        else if (OldGamePadState.Buttons.Guide == ButtonState.Pressed && CurrentGamePadState.Buttons.Guide == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.Guide);
        }
        //LeftStick Button
        if (OldGamePadState.Buttons.LeftStick == ButtonState.Released && CurrentGamePadState.Buttons.LeftStick == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.LeftStick);
        }
        else if (OldGamePadState.Buttons.LeftStick == ButtonState.Pressed && CurrentGamePadState.Buttons.LeftStick == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.LeftStick);
        }
        else if (OldGamePadState.Buttons.LeftStick == ButtonState.Pressed && CurrentGamePadState.Buttons.LeftStick == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.LeftStick);
        }
        //RightStick Button
        if (OldGamePadState.Buttons.RightStick == ButtonState.Released && CurrentGamePadState.Buttons.RightStick == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.RightStick);
        }
        else if (OldGamePadState.Buttons.RightStick == ButtonState.Pressed && CurrentGamePadState.Buttons.RightStick == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.RightStick);
        }
        else if (OldGamePadState.Buttons.RightStick == ButtonState.Pressed && CurrentGamePadState.Buttons.RightStick == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.RightStick);
        }
        //DPadLeft Button
        if (OldGamePadState.DPad.Left == ButtonState.Released && CurrentGamePadState.DPad.Left == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.DPadLeft);
        }
        else if (OldGamePadState.DPad.Left == ButtonState.Pressed && CurrentGamePadState.DPad.Left == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.DPadLeft);
        }
        else if (OldGamePadState.DPad.Left == ButtonState.Pressed && CurrentGamePadState.DPad.Left == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.DPadLeft);
        }
        //DPadRight Button
        if (OldGamePadState.DPad.Right == ButtonState.Released && CurrentGamePadState.DPad.Right == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.DPadRight);
        }
        else if (OldGamePadState.DPad.Right == ButtonState.Pressed && CurrentGamePadState.DPad.Right == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.DPadRight);
        }
        else if (OldGamePadState.DPad.Right == ButtonState.Pressed && CurrentGamePadState.DPad.Right == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.DPadRight);
        }
        //DPadUp Button
        if (OldGamePadState.DPad.Up == ButtonState.Released && CurrentGamePadState.DPad.Up == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.DPadUp);
        }
        else if (OldGamePadState.DPad.Up == ButtonState.Pressed && CurrentGamePadState.DPad.Up == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.DPadUp);
        }
        else if (OldGamePadState.DPad.Up == ButtonState.Pressed && CurrentGamePadState.DPad.Up == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.DPadUp);
        }
        //DPadDown Button
        if (OldGamePadState.DPad.Down == ButtonState.Released && CurrentGamePadState.DPad.Down == ButtonState.Pressed)
        {
            OnButtonPressed?.Invoke(this, Buttons.DPadDown);
        }
        else if (OldGamePadState.DPad.Down == ButtonState.Pressed && CurrentGamePadState.DPad.Down == ButtonState.Pressed)
        {
            OnButtonHold?.Invoke(this, Buttons.DPadDown);
        }
        else if (OldGamePadState.DPad.Down == ButtonState.Pressed && CurrentGamePadState.DPad.Down == ButtonState.Released)
        {
            OnButtonReleased?.Invoke(this, Buttons.DPadDown);
        }
        #endregion

        //Left Axis
        float lsX = CurrentGamePadState.ThumbSticks.Left.X;
        float lsY = CurrentGamePadState.ThumbSticks.Left.Y;
        float oldlsX = OldGamePadState.ThumbSticks.Left.X;
        float oldlsY = OldGamePadState.ThumbSticks.Left.Y;
        //right Axis
        float rsX = CurrentGamePadState.ThumbSticks.Right.X;
        float rsY = CurrentGamePadState.ThumbSticks.Right.Y;
        float oldrsX = OldGamePadState.ThumbSticks.Right.X;
        float oldrsY = OldGamePadState.ThumbSticks.Right.Y;
        //RT Axis
        float rt = CurrentGamePadState.Triggers.Right;
        float oldrt = OldGamePadState.Triggers.Right;
        //LT Axis
        float lt = CurrentGamePadState.Triggers.Left;
        float oldlt = OldGamePadState.Triggers.Left;



        //Left axis
        if ((lsX > currentSettings.leftStickDeadzone || lsX < -currentSettings.leftStickDeadzone) ||
            (lsY > currentSettings.leftStickDeadzone || lsY < -currentSettings.leftStickDeadzone))
        {
            OnAxisUsed?.Invoke(this, Buttons.LeftStick, new AxisValue(lsX, lsY));
        }
        else if ((currentSettings.leftStickDeadzone > lsX && lsX < -currentSettings.leftStickDeadzone) &&
                   (currentSettings.leftStickDeadzone > lsY && lsY < -currentSettings.leftStickDeadzone) &&
                   (oldlsX > currentSettings.leftStickDeadzone || oldlsX < -currentSettings.leftStickDeadzone) ||
                   (oldlsY > currentSettings.leftStickDeadzone || oldlsY < -currentSettings.leftStickDeadzone))
        {
            OnAxisStopUsed?.Invoke(this, Buttons.LeftStick, new AxisValue(lsX, lsY));
        }

        //Rigth axis
        if ((rsX > currentSettings.rightStickDeadzone || rsX < -currentSettings.rightStickDeadzone) ||
           (rsY > currentSettings.rightStickDeadzone || rsY < -currentSettings.rightStickDeadzone))
        {
            OnAxisUsed?.Invoke(this, Buttons.RightStick, new AxisValue(rsX, rsY));
        }
        else if ((currentSettings.rightStickDeadzone > rsX && rsX < -currentSettings.rightStickDeadzone) &&
                 (currentSettings.rightStickDeadzone > rsY && rsY < -currentSettings.rightStickDeadzone) &&
                 (oldrsX > currentSettings.rightStickDeadzone || oldrsX < -currentSettings.rightStickDeadzone) ||
                 (oldrsY > currentSettings.rightStickDeadzone || oldrsY < -currentSettings.rightStickDeadzone))
        {
            OnAxisStopUsed?.Invoke(this, Buttons.RightStick, new AxisValue(rsX, rsY));
        }

        //RT axis
        if (rt > currentSettings.RTDeadzone)
        {
            OnTriggerUsed?.Invoke(this, Buttons.RT , rt);
        }
        else if (currentSettings.RTDeadzone > rt && oldrt > currentSettings.RTDeadzone)
        {
            OnTriggerStopUsed?.Invoke(this, Buttons.RT , rt);
        }
        //LT axis
        if (lt > currentSettings.LTDeadzone)
        {
            OnTriggerUsed?.Invoke(this, Buttons.LT, lt);
        }
        else if (currentSettings.LTDeadzone > lt && oldlt > currentSettings.LTDeadzone)
        {
            OnTriggerStopUsed?.Invoke(this, Buttons.LT, lt);
        }

    }

    public void SetSettings(Settings _settings) {
        currentSettings = _settings;
    }
}
