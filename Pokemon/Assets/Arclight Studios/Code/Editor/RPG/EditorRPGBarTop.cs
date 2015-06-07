using UnityEditor;
using UnityEngine;

namespace ArclightStudios.Code.Editor {
	public partial class EditorRPG {
		void BarTop ( ) {
			TabCreatures ( );
			TabAttacks ( );
			TabSkills ( );
		}

		private void TabCreatures ( ) {
			if ( GUILayout.Button ( "Creatures" ) ) {
				if ( state != State.Creatures ) {
					state = State.Creatures;
				} else {
					state = State.None;
				}
			}
		}

		private void TabAttacks ( ) {
			if ( GUILayout.Button ( "Attacks" ) ) {
				if ( state != State.Attacks ) {
					state = State.Attacks;
				} else {
					state = State.None;
				}
			}
		}

		private void TabSkills ( ) {
			if ( GUILayout.Button ( "Skills" ) ) {
				if ( state != State.Skills ) {
					state = State.Skills;
				} else {
					state = State.None;
				}
			}
		}
	}
}