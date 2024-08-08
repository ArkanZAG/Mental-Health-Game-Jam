using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaxiController : MonoBehaviour
{
    private int startHour;
    [SerializeField] private int hourDuration;
    
    
    private void Awake()
    { 
        float randomValue = Random.value;
        startHour = GameTime.Hours;
        if (randomValue < 0.15f)
        {
            SomethingHappen();
        }
    }

    public void SomethingHappen()
    {
        Debug.Log("Something Happen");
    }

    private void Update()
    {
        if ((startHour + hourDuration) <= GameTime.Hours)
        {
            SceneManager.LoadScene("SceneKantor");
        }
    }
    
}
