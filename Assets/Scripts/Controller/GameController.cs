using Player.Stats;
using UnityEngine;

namespace Controller
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private float gameSpeed = 1;
        
    
        void Update()
        {
            GameTime.Update(Time.deltaTime * gameSpeed);
            PlayerStatsController.Update(Time.deltaTime * gameSpeed);

            Debug.Log("Jam : " + GameTime.Hours + ", Menit : " + GameTime.Minutes + ", Exhaustion : " +
                      PlayerStatsController.Exhaustion + ", Day : " + GameTime.DayCount + ", Money : " +
                PlayerStatsController.Money);
            //PlayerStatsController.AddStress(0.05f);
        }
        public void SetGameSpeed(float value)
        {
            gameSpeed = value;
        }
    }
}
