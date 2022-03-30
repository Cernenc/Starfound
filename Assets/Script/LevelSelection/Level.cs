using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class Level : ScriptableObject
{
    [field: SerializeField]
    public string LevelName { get; set; }

    [field: SerializeField]
    public GameObject LevelPreviewPrefab { get; set; }

    [field: SerializeField]
    public GameObject LevelGameplayPrefab { get; set; }
}
