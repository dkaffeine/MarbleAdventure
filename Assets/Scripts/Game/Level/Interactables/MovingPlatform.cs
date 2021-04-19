using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for platform moving
/// </summary>
public class MovingPlatform : InteractableElement
{

    #region Time Control

    /// <summary>
    /// Loop type enumerator
    /// </summary>
    public enum LoopType
    {
        Once,
        PingPong,
        Repeat
    }

    /// <summary>
    /// Loop type
    /// </summary>
    public LoopType loopType;

    /// <summary>
    /// Animation duration in seconds
    /// </summary>
    public float duration = 1.0f;

    /// <summary>
    /// Inner rescaled time
    /// </summary>
    private float time = 0.0f;

    #endregion

    #region Space Control

    public enum Interpolation
    {
        Identity,
        Linear    
    }

    public Interpolation interpolation;

    /// <summary>
    /// Editor position
    /// </summary>
    [Range(0, 1)]
    public float editorPosition;

    /// <summary>
    /// Position
    /// </summary>
    private float position;

    /// <summary>
    /// Relative start position
    /// </summary>
    public Vector3 startPosition;

    /// <summary>
    /// Relative end position
    /// </summary>
    public Vector3 endPosition;

    #endregion

    private void Start()
    {
        // On start, set position to initial position
        UpdatePosition(0.0f);
    }

    private void FixedUpdate()
    {

        if (interactableActivated == false)
        {
            // If the platform is not activated, return without doing anything
            return;
        }

        // Update time
        time += Time.fixedDeltaTime / duration;

        // Update position, depending on time and position repeat
        switch (loopType)
        {
            case LoopType.PingPong:
                PositionPingPong();
                break;
            case LoopType.Repeat:
                PositionRepeat();
                break;
            case LoopType.Once:
                PositionLoopOnce();
                break;
        }

        UpdatePosition(position);

    }

    #region Time Loop Functions

    private void PositionPingPong()
    {
        position = Mathf.PingPong(time, 1.0f);
    }

    private void PositionRepeat()
    {
        position = Mathf.Repeat(time, 1.0f);
    }

    private void PositionLoopOnce()
    {
        position = Mathf.Clamp01(time);
        if (position >= 1.0f)
        {
            interactableActivated = false;
        }
    }

    #endregion

    /// <summary>
    /// Get interpolation point
    /// </summary>
    /// <param name="timePos">Time position, between 0 and 1</param>
    /// <returns>Space position</returns>
    public float GetInterpolationPoint(float timePos)
    {
        switch(interpolation)
        {
            case Interpolation.Identity:
                return timePos;
            case Interpolation.Linear:
                const float threshold = 0.1f;
                if (timePos < threshold)
                    return 0.0f;
                if (timePos > 1.0f - threshold)
                    return 1.0f;
                return (timePos - threshold) / (1.0f - 2 * threshold);
            default:
                return 0.0f;
        }
    }

    public void UpdatePosition(float timePos)
    {
        float interpPos = GetInterpolationPoint(timePos);
        Vector3 spacePos = Vector3.Lerp(startPosition, endPosition, interpPos);
        transform.position = spacePos;
    }

}
