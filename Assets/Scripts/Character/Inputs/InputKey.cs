using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKey
{
    public List<InputEvent> InputEvents;

    public bool IsPressed(){
        foreach (InputEvent inputEvent in InputEvents){
            if (inputEvent.IsPressed()){
                return true;
            }
        }
        return false;
    }
}
