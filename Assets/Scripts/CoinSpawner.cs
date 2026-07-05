using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _points;

    [SerializeField] private int _defaultCountOfCoins;
    [SerializeField] private int _sizePool;
    [SerializeField] private float _deltaTime;

    private ObjectPool<Coin> _coinPool;
    private List<Transform> _occupiedPoints;

    private void Awake()
    {
        _coinPool = new ObjectPool<Coin>
        (
            createFunc: () => Instantiate(_coinPrefab),
            actionOnGet: (coin) => SetUpCoinBeforeUse(coin),
            actionOnRelease: (coin) => SetCoinBeforeReturning(coin),
            actionOnDestroy: (coin) => Destroy(coin),
            collectionCheck: true,
            defaultCapacity: _defaultCountOfCoins,
            maxSize: _sizePool
        );

        _occupiedPoints = new List<Transform>(_points.Count);
    }

    private void Start()
    {
        AddCoins();

        StartCoroutine(CreateCoins());
    }

    public void ReturnCoin(Coin coin)
    {
        _coinPool.Release(coin);

        for (int i = 0; i < _occupiedPoints.Count; i++)
        {
            if (_occupiedPoints[i] != null && _occupiedPoints[i].transform == coin.transform)
            {
                _occupiedPoints[i] = null;
            }
        }
    }

    private void SetUpCoinBeforeUse(Coin coin)
    {
        coin.Taken += ReturnCoin;

        coin.gameObject.SetActive(true);
    }

    private void SetCoinBeforeReturning(Coin coin)
    {
        coin.gameObject.SetActive(false);

        coin.Taken -= ReturnCoin;

        coin.transform.position = Vector3.zero;

        coin.transform.rotation = Quaternion.identity;
    }

    private void AddCoins()
    {
        Transform coin;

        while (_occupiedPoints.Count < _points.Count)
        {
            int index = _occupiedPoints.Count;

            coin = _coinPool.Get().transform;

            _occupiedPoints.Add(coin);

            coin.position = _points[index].position;
        }
    }

    private void ActivateInactiveCoin()
    {
        Transform coin;

        for (int i = 0; i < _occupiedPoints.Count; i++)
        {
            if (_occupiedPoints[i] == null)
            {
                coin = _coinPool.Get().transform;

                _occupiedPoints[i] = coin;

                coin.position = _points[i].position;

                break;
            }
        }
    }

    private IEnumerator CreateCoins()
    {
        WaitForSeconds wait = new WaitForSeconds(_deltaTime);

        while (true)
        {
            ActivateInactiveCoin();

            yield return wait;
        }
    }
}
