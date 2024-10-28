using System.Collections;
using System.Collections.Generic;
using Player.Stats;
using Unity.VisualScripting;
using UnityEngine;

public class EscInputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.activeSelf) {
            StartCoroutine(ResetStatsBeforeDisable());
        }
    }

    private IEnumerator ResetStatsBeforeDisable() {
        PlayerStatsController.SetExhaustionPerSecond(0.05f);
        PlayerStatsController.SetStressPerSecond(0f);
        
        yield return new WaitForSeconds(0.0001f);

        gameObject.SetActive(false);
    }
}
