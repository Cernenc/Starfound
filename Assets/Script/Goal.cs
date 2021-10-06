using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<ICharacter>();
        LevelClear(player);
    }

    private void LevelClear(ICharacter player)
    {
        PlayerManager manager = FindObjectOfType<PlayerManager>();
        manager.OnLevelClear();
    }
}
