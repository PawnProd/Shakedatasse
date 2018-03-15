using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapClickBehavior : TrapBehavior {

    public override void TrapInputEventBehavior()
    {
        Destroy(gameObject);
    }

    public override void TrapIdleBehavior()
    {
        throw new System.NotImplementedException();
    }
}
