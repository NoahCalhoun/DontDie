using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public abstract class DDUnitBase : DDObjectBase
{
    virtual public DDUnitType UnitType { get { return DDUnitType.None; } }

    public NavMeshAgent Agent;
    public float MoveSpeed;

    void Awake()
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(TM.position, out hit, float.PositiveInfinity, DDDefine.AreaAll);
        TM.position = hit.position;
    }

    void Update()
    {
    }

    public void Move(DDMoveDirection direction)
    {
        if (direction == DDMoveDirection.Neutral)
            return;

        var angle = (float)direction;
        var vecDir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        NavMeshHit hit;
        NavMesh.SamplePosition(TM.position + vecDir * MoveSpeed * Time.deltaTime, out hit, float.PositiveInfinity, DDDefine.AreaAll);
        TM.position = hit.position;
    }
}
