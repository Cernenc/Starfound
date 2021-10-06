using Assets.Script.Collectables.Interfaces;

namespace Assets.Script.Collectables.Controller
{
    public class SpecialnoteController
    {
        private ISpecialnote _view;

        public SpecialnoteController(ISpecialnote view)
        {
            _view = view;
            _view.OnActivation += HandleActivation;
        }

        private void HandleActivation()
        {
            _view.HandleActivation();
        }
    }
}
