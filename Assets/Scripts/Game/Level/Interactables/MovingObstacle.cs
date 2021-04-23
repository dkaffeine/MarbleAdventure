using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MovingPlatform
{
    public override void UpdatePosition(float timePos)
    {
        float interpPos = GetInterpolationPoint(timePos);
        Vector3 spacePos = Vector3.Lerp(startPosition, endPosition, interpPos);
        if (objectToMove != null)
        {
            objectToMove.transform.position = transform.TransformPoint(spacePos);
        }
    }
}
