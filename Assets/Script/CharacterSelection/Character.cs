using UnityEngine;

namespace Assets.Script.CharacterSelection
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Character Selection/Character")]
    public class Character : ScriptableObject
    {
        [field: SerializeField]
        public string CharacterName { get; set; } = default;

        [field: SerializeField]
        public GameObject CharacterPreviewPrefab { get; set; }

        [field: SerializeField]
        public GameObject CharacterGameplayPrefab { get; set; }

        [field: SerializeField]
        public GameObject CharacterIcon { get; set; }
    }
}
