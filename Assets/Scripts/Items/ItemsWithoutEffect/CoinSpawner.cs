using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _points;

    [SerializeField] private int _defaultCountOfCoins;
    [SerializeField] private int _sizePool;
    [SerializeField] private float _deltaTime;

    private List<Coin> _occupiedPoints;

    private void Awake()
    {
        _occupiedPoints = new List<Coin>(_points.Count);
    }

    private void Start()
    {
        AddCoins();

        StartCoroutine(CreateCoins());
    }

    private void AddCoins()
    {
        Coin coin;

        for (int i = 0; i < _points.Count; i++)
        {
            coin = Instantiate(_coinPrefab, _points[i].position, Quaternion.identity);

            _occupiedPoints.Add(coin);
        }
    }

    private void ActivateInactiveCoin()
    {
        for (int i = 0; i < _occupiedPoints.Count; i++)
        {
            if (_occupiedPoints[i].gameObject.activeSelf == false)
            {
                _occupiedPoints[i].gameObject.SetActive(true);

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
