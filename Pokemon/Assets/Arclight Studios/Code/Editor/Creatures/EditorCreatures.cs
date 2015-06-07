using ArclightStudios.Code.Databases;
using UnityEditor;
using UnityEngine;

namespace ArclightStudios.Code.Editor {
	public partial class EditorRPG {
		private Creature _creature;

		void Creatures ( ) {
			GUILayout.BeginHorizontal ( );

				GUILayout.BeginVertical ( "Box", GUILayout.ExpandHeight ( true ), GUILayout.Width ( 200 ) );

					if ( Database.creatures != null ) {
						GUILayout.Label ( "Creature List", GUILayout.ExpandHeight ( true ) );
					}

					if ( GUILayout.Button ( "+" ) ) {
						
					}

				GUILayout.EndVertical ( );

				GUILayout.BeginVertical ( "Box", GUILayout.ExpandHeight ( true ) );

					if ( _creature != null ) {
						GUILayout.Label ( "Creature Info" );
					} else {
						GUILayout.Label ( "Select a creature to view information" );
					}	

				GUILayout.EndVertical ( );

			GUILayout.EndHorizontal ( );
		}
	}
}
