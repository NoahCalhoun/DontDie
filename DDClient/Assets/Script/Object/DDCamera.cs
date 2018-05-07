using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDCamera : DDObjectBase
{
    public Transform Target;
    public Camera Camera;
    public float FollowFactor;

    public void SetTarget(Transform target)
    {
        Target = target;
    }
    
    void Update()
    {
        if (Target != null)
        {
            FollowFactor = Mathf.Clamp(FollowFactor, 0, 1);
            var followPercent = FollowFactor * 5f;
            var followVector = (Target.position - TM.position) * followPercent * Time.deltaTime;
            followVector.y = 0;
            TM.position += followVector;

            if ((TM.position - Target.position).sqrMagnitude < 10f)
                TM.position = Target.position + Vector3.up * 15;
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.orthographicSize = Mathf.Min(10, Camera.orthographicSize + 0.5f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.orthographicSize = Mathf.Max(5, Camera.orthographicSize - 0.5f);
        }
    }
}
