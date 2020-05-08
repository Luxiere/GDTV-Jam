using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindObjectTracker : MonoBehaviour
{
    public float rewindTime = 2f;

    public static RewindObjectTracker instance;

    public static bool isRewinding = false;

    private struct RewindObject
    {
        public ITrackable trackable;
        public List<Vector2> positions;

        public RewindObject(ITrackable trackable, List<Vector2> positions)
        {
            this.trackable = trackable;
            this.positions = positions;
        }
    }

    private List<RewindObject> rewindObjects = new List<RewindObject>();

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    private void FixedUpdate()
    {
        if (!isRewinding) RecordPosition();
        else PlaybackPosition();
    }

    public void AddRewindObject(ITrackable trackable)
    {
        rewindObjects.Add(new RewindObject(trackable, new List<Vector2>()));
    }

    private void RecordPosition()
    {
        foreach(RewindObject rwd in rewindObjects)
        {
            if(rwd.positions.Count > rewindTime / Time.fixedDeltaTime)
            {
                rwd.positions.RemoveAt(rwd.positions.Count - 1);
            }
            rwd.positions.Insert(0, rwd.trackable.GetTransform().position);

        }
    }

    private void PlaybackPosition()
    {
        foreach(RewindObject rwd in rewindObjects)
        {
            if (rwd.positions.Count > 0)
            {
                rwd.trackable.GetTransform().position = rwd.positions[0];
                rwd.positions.RemoveAt(0);
            }
            else
            {
                print("Can't playback");
            }
        }
    }
}
