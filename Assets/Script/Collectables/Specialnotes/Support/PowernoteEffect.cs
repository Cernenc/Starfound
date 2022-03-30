using UnityEngine;

namespace Assets.Script.Collectables.View.Specialnotes.Support
{
    public class PowernoteEffect
    {
        public IEnemyHolder Enemy { get; set; }
        public ICollectionHolder Collectable { get; set; }

        public void EffectBasedOnCount(int index)
        {
            switch (index)
            {
                case 0:
                    DestroyOnScreen(Enemy);
                    break;
                case 1:
                    CollectOnScreen(Collectable);
                    EffectBasedOnCount(--index);
                    break;
                case 2:
                    OpenSecretPath();
                    EffectBasedOnCount(--index);
                    break;
                default:
                    break;
            }
        }

        private void DestroyOnScreen(IEnemyHolder enemies)
        {
            foreach (var enemy in enemies.Holder)
            {
                if (enemy.Components.Transform.GetComponent<Renderer>().isVisible)
                {
                    enemy.Components.Transform.gameObject.SetActive(false);
                }
            }
        }

        private void CollectOnScreen(ICollectionHolder collectables)
        {
            foreach (var collectable in collectables.Holder)
            {
                if (collectable.Components.Transform.GetComponent<Renderer>().isVisible)
                {
                }
            }
        }

        private void OpenSecretPath(/*ISpecialblock block*/)
        {
            //block.OpenPath();
        }
    }
}
