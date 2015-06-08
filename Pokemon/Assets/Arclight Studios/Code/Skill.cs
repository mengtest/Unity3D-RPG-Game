using ArclightStudios.Code.Interfaces;
using UnityEngine;

namespace ArclightStudios.Code {
	[ System.Serializable ]
	public class Skill : ISkill {
		[ SerializeField ]
		string _name;

		[ SerializeField ]
		Sprite _icon;

		[ SerializeField ]
		int _strength;

		public Skill ( ) {
			_name = "";
			_icon = new Sprite ( );
			_strength = 0;
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public Sprite Icon {
			get { return _icon; }
			set { _icon = value; }
		}

		public int Strength {
			get { return _strength; }
			set { _strength = value; }
		}

		public override string ToString ( ) {
			return "ArclightStudios.Code.Skill." + _name;
		}
	}
}
