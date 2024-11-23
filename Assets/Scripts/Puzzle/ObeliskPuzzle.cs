using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObselikPuzzle : MonoBehaviour
{
    [SerializeField] private Transform[] obelisks; // Array of two obelisks
    [SerializeField] private Transform[] targetPositions; // Correct positions for shadows
    [SerializeField] private float alignmentThreshold = 0.5f; // How close the obelisk must be to the target
    [SerializeField] private GameObject door; // Door to unlock when puzzle is solved

    private bool isSolved = false;

    void Update()
    {
        if (!isSolved)
        {
            if (CheckAlignment())
            {
                isSolved = true;
                UnlockDoor();
            }
        }
    }

    // Check if both obelisks are aligned with their targets
    private bool CheckAlignment()
    {
        for (int i = 0; i < obelisks.Length; i++)
        {
            float distance = Vector2.Distance(obelisks[i].position, targetPositions[i].position);
            if (distance > alignmentThreshold)
            {
                return false; // One obelisk is not aligned
            }
        }
        return true; // All obelisks are aligned
    }

    // Unlock the door when the puzzle is solved
    private void UnlockDoor()
    {
        Debug.Log("Puzzle solved! Unlocking door...");
        if (door != null)
        {
            door.SetActive(false); // Deactivate the door
        }
    }

    // Move an obelisk horizontally (called by player input)
    public void MoveObelisk(int obeliskIndex, float moveAmount)
    {
        if (obeliskIndex >= 0 && obeliskIndex < obelisks.Length)
        {
            obelisks[obeliskIndex].Translate(moveAmount, 0, 0); // Move the obelisk on the X-axis
        }
    }
}
