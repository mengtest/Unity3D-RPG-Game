using System.Collections.Generic;
using UnityEngine;

namespace ArclightStudios.Code.Interfaces {
	public interface ICreature {
		string Name { get; set; }
		Sprite Icon { get; set; }
		List < Attack > Attacks { get; }
		List < Skill > Skills { get; }
	}
}