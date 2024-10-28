using UnityEngine;

namespace Player.Stats
{
    public static class PlayerStatsController
    {
        private static PlayerStats _playerStats = new PlayerStats();
        public static float Exhaustion => _playerStats.exhaustion;
        public static float Stress => _playerStats.stress;
        public static float Money => _playerStats.money;

        public static void SetExhaustionPerSecond(float value)
        {
            _playerStats.exhaustionPerSecond = value;
        }

        public static void SetStressPerSecond(float value)
        {
            _playerStats.stressPerSecond = value;
        }

        public static void AddExhaustion(float value)
        {
            _playerStats.exhaustion += value;
        }

        public static void AddStress(float value)
        {
            _playerStats.stress += value;
        }

        public static void AddExhaustionPerSecond(float delta)
        {
            _playerStats.exhaustionPerSecond += delta;
        }

        public static void AddStressPerSecond(float delta)
        {
            _playerStats.stressPerSecond += delta;
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
            if (_playerStats.stress <= _playerStats.maximumStress)
            {
                _playerStats.stress += _playerStats.stressPerSecond * _playerStats.stressPerSecondModifier * deltaTime;
            }
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
        }

        private static void HandleExhaustion(float deltaTime)
        {
            if (_playerStats.exhaustion <= _playerStats.maximumExhaustion)
            {
                _playerStats.exhaustion += _playerStats.exhaustionPerSecond * deltaTime;
            }
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

        // Minigame related player stats function
        public static int GetWorkMinigameAmount() => _playerStats.workGameStats.CompleteAmount;

        public static void ResetWorkMinigameAmount() => _playerStats.workGameStats.Reset();

        public static void IncrementWorkMinigameAmount() => _playerStats.workGameStats.Increment();

        public static void IncrementIdleCoin() => _playerStats.idleGameStats.AddCoin();
        
        public static int GetIdleGameCoin() => _playerStats.idleGameStats.Coin;

        public static int GetIdleGameInvestment() => _playerStats.idleGameStats.InvestmentAmount;

        public static void BuyInvestmentIdleGame() => _playerStats.idleGameStats.BuyInvestment();
    }
}