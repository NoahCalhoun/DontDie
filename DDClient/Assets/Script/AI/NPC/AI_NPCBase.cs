using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class AI_NPCBase : MonoBehaviour
{
    public DDNPC Owner { private set; get; }

    public DDUnitBase TargetUnit;
    
    public AI_NPCBase(DDNPC npc)
    {
        Owner = npc;
    }

    public virtual void UpdateAI()
    {
    }
}