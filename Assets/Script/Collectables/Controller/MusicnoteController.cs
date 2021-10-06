using Assets.Script.Collectables.Interfaces;
using Assets.Script.Collectables.Model;
using Assets.Script.PlayableCharacters.Interfaces;

namespace Assets.Script.Collectables.Controller
{
    public class MusicnoteController
    {
        private readonly IMusicnote _view;
        private readonly IMusicnoteModel _model;
        
        public MusicnoteController(IMusicnote view)
        {
            _view = view;
            _model = new MusicnoteModel();
            
            _view.OnCollect += HandleCollect;
        }

        private void HandleCollect()
        {
            _model.FillGauge(_view.FillAmount);
            _view.AddToSpeedCounter();
            _view.Collect();
        }
    }
}
