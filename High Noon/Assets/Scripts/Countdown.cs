using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountdownSystem
{

    public class Countdown : MonoBehaviour
    {
        public delegate void CountdownDone();

        public static event CountdownDone OnCountdownDone;

        [SerializeField] private float _startCounter;

        [SerializeField] private GameObject _countdownLabel;

        [SerializeField] private Text _text;

        private float _counter;
        private int _roundedCounter;

        private void Start()
        {
            OnCountdownDone += DeactivateCounter;

            // offset counter by one to add the last "draw" second
            _counter = ++_startCounter;
        }

        private void Update()
        {
            _counter -= Time.deltaTime;
            _roundedCounter = Mathf.FloorToInt(_counter);
            _text.text = _roundedCounter < 1 ? "DRAW" : _roundedCounter.ToString();

            if (!(_counter <= 0)) return;

            if (OnCountdownDone != null)
                OnCountdownDone();
        }

        private void DeactivateCounter()
        {
            _countdownLabel.SetActive(false);
            Destroy(this);
        }
    }
}
