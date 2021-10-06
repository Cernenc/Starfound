﻿using UnityEngine;

namespace Assets.Script.PlayableCharacters.Attributes
{
    public interface ICharacterAttributeManager
    {
        string Name { get; set; }
        float MovementSpeed { get; set; }
        float JumpHeight { get; set; }
        float FallSpeed { get; set; }
        float GaugeMaxAmount { get; set; }
        float GaugeLossAmountPerSecond { get; }
        int IFrames { get; }
    }

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterAttributeManager", order = 1)]
    public class CharacterAttributeManager : ScriptableObject, ICharacterAttributeManager
    {
        [field: SerializeField]
        public string Name { get; set; }

        [field: SerializeField]
        public float MovementSpeed { get; set; }

        [field: SerializeField]
        public float JumpHeight { get; set; }

        [field: SerializeField]
        public float FallSpeed { get; set; }

        [field: SerializeField]
        public float GaugeMaxAmount { get; set; }

        [field:SerializeField]
        public float GaugeLossAmountPerSecond { get; set; }

        [field: SerializeField]
        public int IFrames { get; set; }
    }
}