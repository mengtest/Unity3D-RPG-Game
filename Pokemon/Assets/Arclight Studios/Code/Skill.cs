using System;
using ArclightStudios.Code.Interfaces;
using UnityEngine;

namespace ArclightStudios.Code {
	[ Serializable ]
	public class Skill : ISkill {
		[ SerializeField ]
		string _name;

		public Skill ( string name ) {
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
