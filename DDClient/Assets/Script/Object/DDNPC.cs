using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDNPC : DDUnitBase
{
    #region UnitBase

    override public DDUnitType UnitType { get { return DDUnitType.NPC; } }

    #endregion

    public AI_NPCBase AIComponent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
