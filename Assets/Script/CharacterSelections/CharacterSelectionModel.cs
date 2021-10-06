using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.CharacterSelections
{
    public class CharacterSelectionModel : MonoBehaviour
    {
        [field: SerializeField]
        public GameObject CharacterHolder { get; set; }
    }
}
