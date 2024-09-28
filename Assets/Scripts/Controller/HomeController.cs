using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using RandomEvents;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    [SerializeField] private RandomEvent randomEvent;
    void Start()
    {
        WorkingState.SetWorkingState(false);
    }
}
