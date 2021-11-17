using Assets.Script.Core.Managers;
using Assets.Script.PlayableCharacters.Interfaces;
using UnityEngine;

public class Goal : MonoBehaviour
{
    /// <summary>
    /// OnTriggerEnter gets called twice -> bandaid sln
    /// </summary>
    private bool _isColliding = false;
    private void Start()
    {
        _isColliding = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (_isColliding) return;
        _isColliding = true;

        var player = other.GetComponent<ICharacter>();
        LevelClear(player);
    }

    private void LevelClear(ICharacter player)
    {
        PlayerManager manager = player.playerManager;
        manager.OnLevelClear();
    }
}
