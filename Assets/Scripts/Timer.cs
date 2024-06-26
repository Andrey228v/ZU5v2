using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;

    private int _score;

    private bool _isWaiting;

    private void Start()
    {
        _score = 0;
        _isWaiting = false;
        _counter.text = _score.ToString();

        StartCoroutine(StartClock());
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
                StartCoroutine(StartClock());
            }
        }
    }

    private IEnumerator StartClock()
    {
        while(_isWaiting == false)
        {
            _counter.text = _score.ToString();
            _score += 1;
            yield return new WaitForSeconds(0.5f);
        }   
    }
}
