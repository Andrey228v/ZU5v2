using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;
    [Min(0)][SerializeField] private float _deleyCounter;

    private int _score;

    private bool _isWaiting;

    private void Start()
    {
        _score = 0;
        _counter.text = _score.ToString();

        StartCoroutine(StartClock(_deleyCounter));
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_isWaiting == false)
            {
                _isWaiting = true;
            }
            else
            {
                _isWaiting = false;
                StartCoroutine(StartClock(_deleyCounter));
            }
        }
    }

    private IEnumerator StartClock(float deley)
    {
        WaitForSeconds wait = new WaitForSeconds(deley);

        while (_isWaiting == false)
        {
            _counter.text = _score.ToString();
            _score += 1;
            yield return wait;
        }   
    }
}
