using UnityEngine;

namespace ArclightStudios.Code.Interfaces {
	public interface ISkill {
		string Name { get; set; }
		Sprite Icon { get; set; }
		int Strength { get; set; }
	}
}