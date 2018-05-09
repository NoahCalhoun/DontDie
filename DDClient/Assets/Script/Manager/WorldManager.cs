﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class WorldManager : MonoBehaviour
{
    static public WorldManager Instance { get { if (mInstance == null) mInstance = GameObject.FindGameObjectWithTag("World").GetComponent<WorldManager>(); return mInstance; } }
    static private WorldManager mInstance;

    public GameObject UnitPrefab;
    public Dictionary<DDUnitType, List<DDUnitBase>> UnitDic = new Dictionary<DDUnitType, List<DDUnitBase>>();

    public Transform WorldRoot;
    public Transform UIRoot;

    // Use this for initialization
    void Start()
    {
        SpawnUnit(DDUnitType.Player, new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public DDUnitBase SpawnUnit(DDUnitType type, Vector3 position)
    {
        switch (type)
        {
            case DDUnitType.Player:
                if (UnitDic.ContainsKey(DDUnitType.Player))
                    return null;
                var playerObj = Instantiate(UnitPrefab);
                playerObj.name = "Player";
                playerObj.GetComponentInChildren<MeshRenderer>().material.color = new Color(0, 0, 1);
                var player = playerObj.AddComponent<DDPlayer>();
                player.InitUnit();
                player.TM.SetParent(WorldRoot);
                PlaceOnGround(player, position);
                UnitDic.Add(DDUnitType.Player, new List<DDUnitBase>(1));
                UnitDic[DDUnitType.Player].Add(player);
                return player;
        }
        return null;
    }

    static public void PlaceOnGround(DDUnitBase unit, Vector3 position)
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(position, out hit, float.PositiveInfinity, DDDefine.AreaAll);
        unit.TM.position = hit.position;
    }
}
