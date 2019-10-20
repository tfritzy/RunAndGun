using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : InputKey
{
    public Jump(){
        this.InputEvents = new List<InputEvent> {
            new KeypressInput {
                Buttons = new List<KeyCode> {
                    KeyCode.Space,
                    KeyCode.UpArrow
                },
                InputType = ButtonInputType.Held
            },
            new TouchInput {
                TouchArea = new Rect(-20, 0, 40, 40),
                InputType = TouchInputType.Held
            }
        };
    }
}
