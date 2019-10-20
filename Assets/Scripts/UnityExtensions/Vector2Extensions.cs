using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 Unit(this Vector2 vector2){
        return vector2 / vector2.magnitude;
    }
}
