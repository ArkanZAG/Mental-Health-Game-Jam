using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGameStats
{
    [SerializeField] private int _coin = 0;
    [SerializeField] private int _investmentAmount = 0;

    public int Coin {
        get => _coin;
        private set => _coin = value;
    }
    
    public int InvestmentAmount {
        get => _investmentAmount;
        private set => _investmentAmount = value;
    }

    public void AddCoin() {
        Coin += 1 + InvestmentAmount;
    }

    public void BuyInvestment() {
        if (Coin >= 100000) {
            Coin -= 100000;
            InvestmentAmount += 1;
        }
    }
}
