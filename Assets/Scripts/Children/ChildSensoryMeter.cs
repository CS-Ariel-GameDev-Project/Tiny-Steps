using UnityEngine;

public class ChildSensoryMeter : MonoBehaviour
{
    [SerializeField] private ChildProfileData profile;
    [SerializeField] private GameEvent onChildOverloaded;

    private float _currentStress;
    private bool _isOverloaded;

    private void Update()
    {
        if (_isOverloaded) return;
        AddStress(profile.passiveStressRate * Time.deltaTime);
    }

    public void AddStress(float amount)
    {
        if (_isOverloaded) return;
        _currentStress = Mathf.Clamp(_currentStress + amount, 0f, profile.maxStress);

        GetComponent<SpriteRenderer>().color = Color.Lerp(Color.green, Color.red, _currentStress / profile.maxStress);

        if (_currentStress >= profile.maxStress)
        {
            _isOverloaded = true;
            onChildOverloaded?.Raise();
        }
    }

    public void ReduceStress(float amount) => _currentStress = Mathf.Max(0f, _currentStress - amount);
}