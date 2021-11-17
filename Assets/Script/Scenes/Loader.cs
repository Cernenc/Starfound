using UnityEngine.SceneManagement;

namespace Assets.Script.Scenes
{
    public class Loader
    {
        public void LoadCurrentLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
