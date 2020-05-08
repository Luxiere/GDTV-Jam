using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 2f;
            RewindObjectTracker.isRewinding = true;
        }
        else
        {
            Time.timeScale = 1f;
            RewindObjectTracker.isRewinding = false;
        }
    }
}
