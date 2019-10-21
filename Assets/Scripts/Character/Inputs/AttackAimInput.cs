using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInput : InputKey
{
    public AttackInput(){
        this.InputEvents = new List<InputEvent> {
            new KeypressInput {
                Buttons = new List<KeyCode> {
                    KeyCode.Mouse0,
                },
                InputType = ButtonInputType.Held
            },
            new TouchInput {
                TouchArea = new Rect(20, 0, 40, 40),
                InputType = TouchInputType.Held
            }
        };
    }
}
