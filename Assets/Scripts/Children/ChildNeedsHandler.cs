using UnityEngine;

[RequireComponent(typeof(ChildSensoryMeter))]
public class ChildNeedsHandler : MonoBehaviour
{
    [SerializeField] private ChildProfileData profile;
    private ChildSensoryMeter _meter;

    private void Awake() => _meter = GetComponent<ChildSensoryMeter>();

    public bool TryApplyAid(SensoryAidData aid)
    {
        if (aid == profile.requiredAid)
        {
            _meter.ReduceStress(aid.stressReliefAmount);
            return true;
        }
        return false;
    }
}