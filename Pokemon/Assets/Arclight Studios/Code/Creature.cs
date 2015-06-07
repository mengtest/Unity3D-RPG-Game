using System;
using ArclightStudios.Code.Interfaces;
using UnityEngine;

namespace ArclightStudios.Code {
	[ Serializable ]
	public class Creature : ICreature {
		[ SerializeField ]
		string _name;

		public Creature ( string name ) {
			_name = name;
		}
		
		public string Name {
			get { return _name; }
		}

		public Sprite Icon {
			get { throw new NotImplementedException ( ); }
			set { throw new NotImplementedException ( ); }
		}
		public Attack [ ] Attacks {
			get { throw new NotImplementedException ( ); }
			set { throw new NotImplementedException ( ); }
		}


		public Skill [ ] Skills {
			get { throw new NotImplementedException ( ); }
			set { throw new NotImplementedException ( ); }
		}
	}
}
