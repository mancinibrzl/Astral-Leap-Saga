using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mancini.Core.Singleton;
using DG.Tweening;

public class CoinAnimatorManager : Singleton<CoinAnimatorManager>
{
    [SerializeField] private float _coinAnimationTime = .3f;
    [SerializeField] private float _delayBetweenCoins = .1f;

    private List<ItemCollectableCoin> _coinsList = new List<ItemCollectableCoin>();

    private bool firstFrame = true;

    public void RegisterCoin(ItemCollectableCoin coin)
    {
        _coinsList.Add(coin);
        coin.transform.localScale = Vector3.zero;
    }

    public void DeRegisterCoin(ItemCollectableCoin coin)
    {
        _coinsList.Remove(coin);
    }

    public void StartAnimation()
    {
        StartCoroutine(AnimationCoroutine());
    }

    private void Update()
    {
        if (firstFrame)
        {
            StartAnimation();
            firstFrame = false;
        }
    }

    private IEnumerator AnimationCoroutine()
    {
        WaitForSeconds waitSeconds = new WaitForSeconds(_delayBetweenCoins);
        foreach (var coin in _coinsList)
        {
            coin.transform.DOScale(1, _coinAnimationTime);
            yield return waitSeconds;
        }
    }
}
