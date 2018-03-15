using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public TrapType type;
    public bool isMoving;
    public float speedMoving = 2f;
    private TrapBehavior _behavior;

    private bool clickRelease = true;

    private void Start()
    {
        _behavior = GetComponent<TrapBehavior>();
    }

    private void Update()
    {
        if (type == TrapType.longclick && clickRelease)
        {
            _behavior.TrapIdleBehavior();
        }

        if(isMoving)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speedMoving);
        }
    }

    private void OnMouseDown()
    {
        if (type == TrapType.click)
        {
            _behavior.TrapInputEventBehavior();
        }
    }

    private void OnMouseDrag()
    {
        if (type == TrapType.longclick)
        {
            clickRelease = false;
            _behavior.TrapInputEventBehavior();
        }
    }

    private void OnMouseUp()
    {
        if (type == TrapType.longclick)
        {
            clickRelease = true;
        }
    }
}


public enum TrapType
{
    click,
    longclick,
    swipe
}
