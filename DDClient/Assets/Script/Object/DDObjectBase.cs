﻿using UnityEngine;

public class DDObjectBase : MonoBehaviour
{
    private Transform mTM;
    public Transform TM { get { if (mTM == null) mTM = transform; return mTM; } }

    private GameObject mGO;
    public GameObject GO { get { if (mGO == null) mGO = gameObject; return mGO; } }
}
