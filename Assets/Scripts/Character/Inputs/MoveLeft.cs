using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : InputKey
{
    public MoveLeft(){
        this.InputEvents = new List<InputEvent> {
            new KeypressInput {
                Buttons = new List<KeyCode> {
                    KeyCode.A,
                    KeyCode.LeftArrow
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
