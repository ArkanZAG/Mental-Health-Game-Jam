using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAutoChange : MonoBehaviour
{
    [SerializeField] public string SceneSelection;
    [SerializeField] public float SceneDelay;


    private void Start()
    {
        StartCoroutine(SwitchSceneAfterDelay());

    }
    private IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSeconds(SceneDelay);
        SceneManager.LoadScene(SceneSelection);
    }


}



