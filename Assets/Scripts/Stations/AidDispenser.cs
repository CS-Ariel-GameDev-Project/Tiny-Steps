using UnityEngine;

public class AidDispenser : MonoBehaviour
{
    [SerializeField] private SensoryAidData aidToDispense;
    public SensoryAidData DispenseAid() => aidToDispense;
}