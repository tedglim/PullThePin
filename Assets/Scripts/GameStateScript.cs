using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour
{
    private static bool isGameOver;
    private static bool isPinMoving;
    public static bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
        set
        {
            isGameOver = value;
        }
    }
    public static bool IsPinMoving
    {
        get
        {
            return isPinMoving;
        }
        set
        {
            isPinMoving = value;
        }
    }
}
