using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class AI_MonsterBase : MonoBehaviour
{
    public DDMonster Owner { private set; get; }

    public DDUnitBase TargetUnit;

    public AI_MonsterBase(DDMonster monster)
    {
        Owner = monster;
    }

    public virtual void UpdateAI()
    {
    }
}
