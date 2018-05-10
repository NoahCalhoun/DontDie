using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public abstract class DDUnitBase : DDObjectBase
{
    virtual public DDUnitType UnitType { get { return DDUnitType.None; } }

    public NavMeshAgent Agent;
    public float MoveSpeed;

    virtual public void InitUnit()
    {
        Agent = GetComponent<NavMeshAgent>();
        MoveSpeed = 10;
    }

    void Awake()
    {
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
        Agent.Move(vecDir * MoveSpeed * Time.deltaTime);
    }

    public void SetScale(float scale)
    {
        if (scale <= 0f)
            return;

        TM.localScale = new Vector3(scale, 1, scale);
    }
}
