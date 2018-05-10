using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDBoss : DDUnitBase
{
    #region UnitBase

    override public DDUnitType UnitType { get { return DDUnitType.Boss; } }

    #endregion

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WorldManager.Instance.UnitDic.ContainsKey(DDUnitType.Player))
        {
            var player = WorldManager.Instance.UnitDic[DDUnitType.Player][0];
            var sqrDist = UnitHelper.GetSqrDistFromUnitToUnit(this, player);
            if (sqrDist > 64)
            {
                Agent.isStopped = false;
                Agent.velocity = Agent.desiredVelocity;
                Agent.SetDestination(player.TM.position);
            }
            else
            {
                Agent.velocity = Vector3.zero;
                Agent.isStopped = true;
            }
        }
    }
}
