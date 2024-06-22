using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float innerDetectionRadius = 2f;

    public bool CanFollow(Transform target, Transform detector)
    {
        return (target.position - detector.position).magnitude <= detectionRadius;
    }

    public bool CanAttack(Transform target, Transform detector)
    {
        return (target.position - detector.position).magnitude <= innerDetectionRadius;
    }

}
