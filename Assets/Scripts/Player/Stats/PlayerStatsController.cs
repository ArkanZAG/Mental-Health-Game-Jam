using UnityEngine;

namespace Player.Stats
{
    public static class PlayerStatsController
    {
        private static PlayerStats _playerStats = new PlayerStats();
        public static float Exhaustion => _playerStats.exhaustion;
        public static float Stress => _playerStats.stress;
        public static float Money => _playerStats.money;

        public static void AddExhaustionPerSecond(float delta)
        {
            _playerStats.exhaustionPerSecond += delta;
        }

        public static void AddStressPerSecond(float delta)
        {
            _playerStats.stressPerSecond += delta;
        }


        public static void ReduceExhaustionPerSecond(float delta)
        {
            _playerStats.exhaustionPerSecond -= delta;
        }

        public static void ReduceStressPerSecond(float delta)
        {
            _playerStats.stressPerSecond -= delta; 
        }

        public static void AddMoney(float delta)
        {
            _playerStats.money += delta;
        }
        
        public static void Update(float deltaTime)
        {
            HandleStress(deltaTime);
            HandleExhaustion(deltaTime);
        }

        private static void HandleStress(float deltaTime)
        {
            if (_playerStats.stress >= 50)
            {
                _playerStats.stressPerSecondModifier = 1.5f;
            }else if (_playerStats.stress >= 75)
            {
                _playerStats.stressPerSecondModifier = 2f;
            }
            else
            {
                _playerStats.stressPerSecondModifier = 1f;
            }
            
            _playerStats.stress += _playerStats.stressPerSecond * _playerStats.stressPerSecondModifier * deltaTime;
            
        }

        private static void HandleExhaustion(float deltaTime)
        {
            _playerStats.exhaustion += _playerStats.exhaustionPerSecond * deltaTime;
            
            if (_playerStats.stress >= 50)
            {
                _playerStats.exhaustion += 0.05f * deltaTime;
            }else if (_playerStats.stress >= 75)
            {
                _playerStats.exhaustion += 0.1f * deltaTime;
            }else if (_playerStats.stress >= 100)
            {
                _playerStats.exhaustion += 0.2f * deltaTime;
            }
        }
    }
}