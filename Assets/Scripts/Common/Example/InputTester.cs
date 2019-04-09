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

        // Update is called once per frame
        void Update() {

            int c = InputChecker.instance.Activegamepads.Count;

            string textToRead = "";

            for (int i = 0; i < 4; i++) {
                bool chk = c > i;
                
                if (chk) {
                    textToRead += "gamepad " + i + "(id : " + InputChecker.instance.Activegamepads[i].ID +  ")  connected : true";
                    textToRead += Environment.NewLine;
                } else {
                    textToRead += "gamepad " + i + " connected : false";
                    textToRead += Environment.NewLine;
                }
            }
            
            TextInfo.text = textToRead;
                
        }
    }
}