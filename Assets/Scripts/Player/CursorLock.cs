using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] private bool lockCursor;

    public delegate void CursorLockHandler(bool lockState);
    public static CursorLockHandler cursorLockHandler;
    private void Awake()
    {
        LockCursor(lockCursor);
    }
    /// <summary>
    /// If true bool is passed through, enabled cursor lock
    /// </summary>
    /// <param name="lockState"></param>
    public void LockCursor(bool lockState)
    {
        if (lockState)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
    /// <summary>
    /// Called by delegate, passes through bool to enable or disable cursor lock
    /// </summary>
    /// <param name="lockState"></param>
    private void ChangeCursorLock(bool lockState)
    {
        LockCursor(lockState);
    }
    private void OnEnable()
    {
        cursorLockHandler += ChangeCursorLock;
    }
    private void OnDisable()
    {
        cursorLockHandler -= ChangeCursorLock;
    }
}
