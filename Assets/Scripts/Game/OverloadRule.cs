using UnityEngine;

public class OverloadRule : MonoBehaviour
{
    [SerializeField] private GameEvent onDayLost;
    private bool _isLost;

    public void TriggerLoss()
    {
        if (_isLost) return;
        _isLost = true;
        onDayLost?.Raise();
    }
}