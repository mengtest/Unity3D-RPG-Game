using System;
using ArclightStudios.Code.Interfaces;
using UnityEngine;

namespace ArclightStudios.Code {
	[ Serializable ]
	public class Attack : IAttack {
		[ SerializeField ]
		string _name;

		public Attack ( string name ) {
			_name = name;
		}

		public string Name {
			get { return _name; }
		}

		public int Strength {
			get { throw new NotImplementedException ( ); }
			set { throw new NotImplementedException ( ); }
		}
	}
}
