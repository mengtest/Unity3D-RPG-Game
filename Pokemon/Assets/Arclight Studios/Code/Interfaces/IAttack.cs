using UnityEngine;

namespace ArclightStudios.Code.Interfaces {
	public interface IAttack {
		string Name { get; set; }
		Sprite Icon { get; set; }
		int Strength { get; set; }
	}
}