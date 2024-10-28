using System.Collections;
using System.Collections.Generic;
using Player.Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_IdleMinigame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinAmountText;
    [SerializeField] private TextMeshProUGUI _investmentAmountText;
    [SerializeField] private Button _buyInvestmentButton;

    // Start is called before the first frame update
    void Start()
    {
        _coinAmountText.text = PlayerStatsController.GetIdleGameCoin().ToString();
        _investmentAmountText.text = string.Format("Investment Rate: {0}/0.5s", PlayerStatsController.GetIdleGameInvestment());
        _buyInvestmentButton.onClick.AddListener(() => {
            PlayerStatsController.BuyInvestmentIdleGame();
        });
        CheckCoin();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _coinAmountText.text = PlayerStatsController.GetIdleGameCoin().ToString();
        _investmentAmountText.text = string.Format("Investment Rate: {0}/0.5s", PlayerStatsController.GetIdleGameInvestment());
        CheckCoin();
    }

    private void CheckCoin() {
        if (PlayerStatsController.GetIdleGameCoin() < 100000) {
            _buyInvestmentButton.interactable = false;
        } else {
            _buyInvestmentButton.interactable = true;
        }
    }

    public void ReduceStress() {
        PlayerStatsController.SetStressPerSecond(-0.05f);
    }

    public void CancelReduceStress() {
        PlayerStatsController.SetStressPerSecond(0f);
    }
}
