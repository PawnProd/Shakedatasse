using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLongClickBehavior : TrapBehavior {

    public Vector3 startPosition;
    public Vector3 endPosition;

    private void Start()
    {
        startPosition = transform.position;
        endPosition.y = transform.position.y + 2;
    }

    public override void TrapInputEventBehavior()
    {
        print(transform.position);
        if(transform.position.y < endPosition.y)
            transform.Translate(Vector3.up * Time.deltaTime);
    }

    public override void TrapIdleBehavior()
    {
        if(transform.position.y > startPosition.y)
            transform.Translate(Vector3.down * Time.deltaTime);
    }


}
