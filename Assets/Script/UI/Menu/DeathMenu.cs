using Assets.Script.Core.Managers;
using Assets.Script.Scenes;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [field: SerializeField]
    public GameObject DeathMenuObject { get; set; }
    
    [field: SerializeField]
    public GameObject RepeatBtn { get; set; }
    
    [field: SerializeField]
    public GameObject MenuBtn { get; set; }

    public GameManager Manager { get; set; }

    private void Start()
    {
        DeathMenuObject.SetActive(false);
        Manager = FindObjectOfType<GameManager>();
    }

    public void RepeatLevel()
    {
        Loader loader = new Loader();
        StartCoroutine(loader.LoadLevelAsync());
    }
}
