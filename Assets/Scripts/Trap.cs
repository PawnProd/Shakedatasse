using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public TrapType type;

    public TrapBehavior behavior;

    private void Update()
    {
        if(type == TrapType.click && InputManager.MouseButtonDown())
        {
            behavior.TrapInputEventBehavior();
        }
        else if (type == TrapType.longclick && InputManager.MouseButton())
        {

        }
        else if(type == TrapType.swipe)
        {

        }
    }
}

public enum TrapType
{
    click,
    longclick,
    swipe
}
