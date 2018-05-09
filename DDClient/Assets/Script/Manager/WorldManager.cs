using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject UnitPrefab;
    public Dictionary<DDUnitType, List<DDUnitBase>> UnitDic = new Dictionary<DDUnitType, List<DDUnitBase>>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public DDUnitBase SpawnUnit(DDUnitType type, Vector3 position)
    {
        return null;
    }
}
