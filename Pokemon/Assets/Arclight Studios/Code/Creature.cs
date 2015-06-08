using ArclightStudios.Code.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace ArclightStudios.Code {
	[ System.Serializable ]
	public class Creature : ICreature {
		[ SerializeField ]
		string _name;

		[ SerializeField ]
		Sprite _icon;

		[ SerializeField ]
		List < Attack > _attacks;

		[ SerializeField ]
		List < Skill > _skills;

		public Creature ( ) {
			_name = "";
			_icon = new Sprite ( );
			_attacks = new List < Attack > ( );
			_skills = new List < Skill > ( );
		}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public Sprite Icon {
			get { return _icon; }
			set { _icon = value; }
		}

		public List < Attack > Attacks {
			get { return _attacks; }
		}

		public List < Skill > Skills {
			get { return _skills; }
		}

		public override string ToString ( ) {
			return "ArclightStudios.Code.Creature." + _name;
		}
	}
}
