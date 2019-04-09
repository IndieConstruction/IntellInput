using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XInputDotNetPure;

namespace TellInput {



    public class InputTester : MonoBehaviour {

        public Text TextInfo;
        private void Start() {
            InputChecker.OnGamepadConnected += HandleGamepadConnection;
            InputChecker.OnGamepadDisconnected += HandleGamepadDisconnection;
        }

        private void HandleGamepadDisconnection(IntellGamePad gpad) {
            gpad.OnButtonPressed -= HandleButtonPressed;
            gpad.OnButtonHold -= HandleButtonHold;
            gpad.OnButtonReleased -= HandleButtonReleased;
            gpad.OnAxisUsed -= HandleAxisUsed;
            gpad.OnAxisStopUsed -= HandleAxisStopUsed;
            Debug.LogFormat("Gamepad disconnesso: {0}", gpad.ID);
        }

        private void HandleGamepadConnection(IntellGamePad gpad) {
            gpad.OnButtonPressed += HandleButtonPressed;
            gpad.OnButtonHold += HandleButtonHold;
            gpad.OnButtonReleased += HandleButtonReleased;
            gpad.OnAxisUsed += HandleAxisUsed;
            gpad.OnAxisStopUsed += HandleAxisStopUsed;
            Debug.LogFormat("Gamepad connesso: {0}", gpad.ID);
        }

        private void HandleAxisUsed(IntellGamePad gpad, IntellGamePad.Buttons button, IntellGamePad.AxisValue values) {
            Debug.LogFormat("Gamepad {0} axis {1} used, values: {2},{3}", gpad.ID, button, values.X, values.Y);
        }

        private void HandleAxisStopUsed(IntellGamePad gpad, IntellGamePad.Buttons button, IntellGamePad.AxisValue values) {
            Debug.LogFormat("Gamepad {0} axis {1} stopped use, values: {2},{3}", gpad.ID, button, values.X, values.Y);
        }

        private void HandleButtonHold(IntellGamePad gpad, IntellGamePad.Buttons button) {
            Debug.LogFormat("Gamepad {0} button hold {1}", gpad.ID, button);
        }

        private void HandleButtonReleased(IntellGamePad gpad, IntellGamePad.Buttons button) {
            Debug.LogFormat("Gamepad {0} button released {1}", gpad.ID, button);
        }

        private void HandleButtonPressed(IntellGamePad gpad, IntellGamePad.Buttons button) {
            Debug.LogFormat("Gamepad {0} button pressed {1}", gpad.ID, button);
        }

        // Update is called once per frame
        void Update() {

            int c = InputChecker.instance.Activegamepads.Count;

            string textToRead = "";

            for (int i = 0; i < 4; i++) {
                bool chk = c > i;

                if (chk) {
                    textToRead += "gamepad " + i + "(id : " + InputChecker.instance.Activegamepads[i].ID + ")  connected : true";
                    textToRead += Environment.NewLine;
                } else {
                    textToRead += "gamepad " + i + " connected : false";
                    textToRead += Environment.NewLine;
                }
            }

            TextInfo.text = textToRead;

        }

        private void OnDisable() {
            InputChecker.OnGamepadConnected -= HandleGamepadConnection;
            InputChecker.OnGamepadDisconnected -= HandleGamepadDisconnection;
        }
    }
}