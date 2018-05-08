using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class DDPlayer : DDUnitBase
{
    #region UnitBase

    override public DDUnitType UnitType { get { return DDUnitType.Player; } }

    #endregion

    // Use this for initialization
    void Start()
    {
        Camera.main.gameObject.GetComponent<DDCamera>().SetTarget(TM);
    }

    // Update is called once per frame
    void Update()
    {
        Move(UpdateMoveDirection());
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
