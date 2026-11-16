using UnityEngine;

[CreateAssetMenu(fileName = "NewChildProfile", menuName = "TinySteps/Data/Child Profile")]
public class ChildProfileData : ScriptableObject
{
    public string childName;
    public SensoryAidData requiredAid;
    public float passiveStressRate = 3f;
    public float maxStress = 100f;
}