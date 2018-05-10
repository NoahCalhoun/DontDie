using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitHelper
{
    public static float GetSqrDistFromUnitToUnit(this DDUnitBase unit1, DDUnitBase unit2)
    {
        return (unit1.TM.position - unit2.TM.position).sqrMagnitude;
    }
}
