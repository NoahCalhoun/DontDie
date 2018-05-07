using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class DDUnitBase : DDObjectBase
{
    virtual public DDUnitType UnitType { get { return DDUnitType.None; } }

    public NavMeshAgent Agent;

    void Awake()
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(new Vector3(0, 0, 0), out hit, float.PositiveInfinity, -1);
        TM.position = hit.position;
        //NavMesh.SamplePosition(new Vector3(30, 30, 0), out hit, float.PositiveInfinity, -1);
        //Agent.SetDestination(hit.position);
        //Agent.velocity = Agent.desiredVelocity;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Agent.path.ClearCorners();
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, float.PositiveInfinity, -1);
            Agent.SetDestination(hit.point);
            Agent.updatePosition = true;
        }

        Agent.velocity = Agent.desiredVelocity;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Agent.updatePosition = false;
            TM.Translate(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Agent.updatePosition = false;
            TM.Translate(0, 0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Agent.updatePosition = false;
            TM.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Agent.updatePosition = false;
            TM.Translate(1, 0, 0);
        }
    }
}
