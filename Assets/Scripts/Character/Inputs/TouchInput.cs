using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : InputEvent
{
    public Rect TouchArea;
    // The type of input types this event supports
    public TouchInputType InputType;

    public override bool IsPressed(){
        for (int i = 0 ; i < Input.touchCount; i++){
            Vector2 touchLocation = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            if (this.TouchArea.Contains(touchLocation)){
                return true;
            }
        }
        return false;
    }
}

public enum TouchInputType {
    TouchDown,
    TouchUp,
    Held,
}
