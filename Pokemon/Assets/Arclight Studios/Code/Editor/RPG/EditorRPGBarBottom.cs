using ArclightStudios.Code.Databases;
using UnityEditor;
using UnityEngine;

namespace ArclightStudios.Code.Editor {
	public partial class EditorRPG {
		void BarBottom ( ) {
			switch ( state ) {
				case State.Creatures:
					GUILayout.Label ( "Creatures: " + Database.creatures.Count );
					break;
				case State.Attacks:
					GUILayout.Label ( "Attacks: " + Database.attacks.Count );
					break;
				case State.Skills:
					GUILayout.Label ( "Skills: " + Database.skills.Count );
					break;
				default:
					GUILayout.Label ( "Designed by Tom Wright, (C) Arclight Studios 2015" );
					break;
			}
		}
	}
}