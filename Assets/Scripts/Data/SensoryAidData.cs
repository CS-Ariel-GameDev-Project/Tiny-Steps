using UnityEngine;

[CreateAssetMenu(fileName = "NewSensoryAid", menuName = "TinySteps/Data/Sensory Aid")]
public class SensoryAidData : ScriptableObject
{
    public string aidName;
    public Color aidColor = Color.cyan;
    public float stressReliefAmount = 40f;
}