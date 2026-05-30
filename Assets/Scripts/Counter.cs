using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeBetweenNumberUpdates = 0.5f;
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private int _number;
    private bool _isCounterWorking;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isCounterWorking = _isCounterWorking ? false : true;

            if (_isCounterWorking)
            {
                StartCoroutine(IncreaseNumber());
            }
            else
            {
                StopCoroutine(IncreaseNumber());
            }
        }
    }

    private IEnumerator IncreaseNumber()
    {
        while (_isCounterWorking)
        {
            _number++;
            UpdateNumber(_number);

            yield return new WaitForSeconds(_timeBetweenNumberUpdates);
        }
    }

    private void UpdateNumber(int number)
    {
        _textMeshPro.text = number.ToString();

        Debug.Log(number);
    }
}
