using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTransportationController : MonoBehaviour
{
    private int startHour;
    [SerializeField] private int hourDuration;
    private void Awake()
    {
        startHour = GameTime.Hours;
        
    }

    private void Update()
    {
        if ((startHour + hourDuration) <= GameTime.Hours)
        {
            SceneManager.LoadScene("SceneKantor");
            Debug.Log(startHour + hourDuration);
        }
    }
}
