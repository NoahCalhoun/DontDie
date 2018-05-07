using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class DDUnitBase : DDObjectBase
{
    virtual public DDUnitType UnitType { get { return DDUnitType.None; } }

    public NavMeshAgent Agent;
    public float MoveSpeed;

    void Awake()
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(new Vector3(0, 0, 0), out hit, float.PositiveInfinity, -1);
        TM.position = hit.position;
        //NavMesh.SamplePosition(new Vector3(30, 30, 0), out hit, float.PositiveInfinity, -1);
        //Agent.SetDestination(hit.position);
        //Agent.velocity = Agent.desiredVelocity;

        Camera.main.gameObject.GetComponent<DDCamera>().SetTarget(TM);
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Agent.path.ClearCorners();
        //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    Physics.Raycast(ray, out hit, float.PositiveInfinity, -1);
        //    Agent.SetDestination(hit.point);
        //    Agent.updatePosition = true;
        //}

        //Agent.velocity = Agent.desiredVelocity;

        Move(UpdateMoveDirection());
    }

    public void Move(DDMoveDirection direction)
    {
        if (direction == DDMoveDirection.Neutral)
            return;

        var angle = (float)direction;
        var vecDir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        NavMeshHit hit;
        NavMesh.SamplePosition(TM.position + vecDir * MoveSpeed * Time.deltaTime, out hit, float.PositiveInfinity, -1);
        TM.position = hit.position;
    }

    public DDMoveDirection UpdateMoveDirection()
    {
        byte x = 0, y = 0;

        if (Input.GetKey(KeyCode.W))
        {
            y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x += 1;
        }

        if (x == 0)
        {
            if (y == 0)
                return DDMoveDirection.Neutral;
            else if (y == 1)
                return DDMoveDirection.Up;
            else
                return DDMoveDirection.Down;
        }
        else if (x == 1)
        {
            if (y == 0)
                return DDMoveDirection.Right;
            else if (y == 1)
                return DDMoveDirection.UpRight;
            else
                return DDMoveDirection.DownRight;
        }
        else /*if (x == 255)*/
        {
            if (y == 0)
                return DDMoveDirection.Left;
            else if (y == 1)
                return DDMoveDirection.UpLeft;
            else
                return DDMoveDirection.DownLeft;
        }
    }
}
