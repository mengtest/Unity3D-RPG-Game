using UnityEngine;

namespace ArclightStudios.Code.Editor {
	public partial class EditorRPG {
		void BarTop ( ) {
			if ( Databases.Database.attacks == null ) {
				Databases.Database.Create ( );
			}

			TabCreatures ( );
			TabAttacks ( );
			TabSkills ( );
		}

		private void TabCreatures ( ) {
			if ( GUILayout.Button ( "Creatures" ) ) {
				ResetAllSelections ( );

				if ( state != State.Creatures ) {
					state = State.Creatures;
				} else {
					state = State.None;
				}
			}
		}

		private void TabAttacks ( ) {
			if ( GUILayout.Button ( "Attacks" ) ) {
				ResetAllSelections ( );

				if ( state != State.Attacks ) {
					state = State.Attacks;
				} else {
					state = State.None;
				}
			}
		}

		private void TabSkills ( ) {
			if ( GUILayout.Button ( "Skills" ) ) {
				ResetAllSelections ( );

				if ( state != State.Skills ) {
					state = State.Skills;
				} else {
					state = State.None;
				}
			}
		}
	}
}