using Assets.Script.Scenes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    [field: SerializeField]
    public GameObject DeathMenuObject { get; set; }
    
    [field: SerializeField]
    public Button RepeatBtn { get; set; }
    
    [field: SerializeField]
    public Button MenuBtn { get; set; }

    private void Start()
    {
        DeathMenuObject.SetActive(false);
    }

    public void LevelLost()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(RepeatBtn.gameObject);
    }

    public void RepeatLevel()
    {
        Loader loader = new Loader();
        loader.LoadCurrentLevel();
    }
}
