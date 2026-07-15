using UnityEngine;

[CreateAssetMenu(fileName = "StageData",menuName = "Game/Stage Data")]
public class StageData : ScriptableObject
{
    [SerializeField] private float stageDuration = 600f;
    [SerializeField] private SpawnData[] spawnDatas;

    public float StageDuration => stageDuration;
    public SpawnData[] SpawnDatas => spawnDatas;
    
}