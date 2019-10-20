using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypressInput : InputEvent
{
    // The list of keycode buttons that trigger this input
    public List<KeyCode> Buttons;
    // The Area in which the touch must occur to trigger this input
    public ButtonInputType InputType;

    public override bool IsPressed(){
        foreach (KeyCode button in this.Buttons){
            if (InputType == ButtonInputType.Held){
                if (Input.GetKey(button)){
                    return true;
                }
            }
            else if (InputType == ButtonInputType.KeyDown){
                if (Input.GetKeyDown(button)){
                    return true;
                }
            }
            else if (InputType == ButtonInputType.KeyUp){
                if (Input.GetKeyUp(button)){
                    return true;
                }
            }
        }

        return false;
    }
}

public enum ButtonInputType{
    KeyDown,
    KeyUp,
    Held,
}


