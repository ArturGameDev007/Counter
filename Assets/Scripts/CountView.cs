using System.Collections;
using TMPro;
using UnityEngine;

public class CountView :MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTime;
    [SerializeField] private ButtonCounter _counter;

    private Coroutine _coroutine = null;

    private float _delay = 0.5f;
    private bool _isCounting = false;

    private void Start()
    {
        _textTime.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
                StopCounter();
            else
                RestartCounter();
        }
    }

    private void RestartCounter()
    {
        if (_coroutine == null)
        {
            _isCounting = true;
            _coroutine = StartCoroutine(TimeCounter(_delay));
        }
    }

    private void StopCounter()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _isCounting = false;
            _coroutine = null;
        }
    }

    private IEnumerator TimeCounter(float delay)
    {
        bool isRun = true;

        var wait = new WaitForSeconds(delay);

        while (isRun)
        {
            yield return wait;

            if (_textTime != null)
            {
                _counter.Increase();
                DisplayCounter();
            }
        }
    }

    private void DisplayCounter()
    {
        _textTime.text = _counter.Count.ToString();
    }
}
