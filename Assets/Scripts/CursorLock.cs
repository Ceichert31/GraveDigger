using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] private bool lockCursor;
    private void Awake()
    {
        LockCursor(lockCursor);
    }
    public void LockCursor(bool lockState)
    {
        if (lockState)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
