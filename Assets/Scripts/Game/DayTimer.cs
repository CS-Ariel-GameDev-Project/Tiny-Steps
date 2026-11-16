using UnityEngine;

public class DayTimer : MonoBehaviour
{
    [SerializeField] private float dayDuration = 60f;
    [SerializeField] private GameEvent onDayWon;

    private float _timer;
    private bool _dayFinished;

    private void Update()
    {
        if (_dayFinished) return;

        _timer += Time.deltaTime;
        if (_timer >= dayDuration)
        {
            _dayFinished = true;
            onDayWon?.Raise();
        }
    }
}