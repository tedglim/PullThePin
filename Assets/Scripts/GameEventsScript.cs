using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventsScript : MonoBehaviour
{
    public static UnityEvent victory = new UnityEvent();
    public static UnityEvent defeat = new UnityEvent();
}
