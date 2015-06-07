using UnityEngine;

namespace ArclightStudios.Code.Interfaces {
	public interface ICreature {
		string Name { get; }
		Sprite Icon { get; set; }
		Attack [ ] Attacks { get; set; }
		Skill [ ] Skills { get; set; }
	}
}