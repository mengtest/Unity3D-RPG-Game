using ArclightStudios.Code.Databases;
using UnityEditor;
using UnityEngine;

namespace ArclightStudios.Code.Editor {
	public partial class EditorRPG : EditorWindow {
		enum State {
			None,
			Creatures,
			Attacks,
			Skills
		}

		private Texture2D trashcan = Resources.Load ( "trashcan" ) as Texture2D;

		State state;
		const int BUTTON_SIZE = 18;
		const int SPRITE_SIZE = 30;
		const int LIST_SIZE = 200;

		[ MenuItem ( "Arclight/RPG Editor %#e" ) ]
		public static void Init ( ) {
			EditorRPG window = GetWindow < EditorRPG > ( );
			window.title = "RPG Editor";
			window.minSize = new Vector2 ( 500, 300 );
			window.Show ( );

			Database.Create ( );
		}

		private void OnGUI ( ) {
			GUILayout.BeginHorizontal ( "Box", GUILayout.ExpandWidth ( true ) );
			BarTop ( );
			GUILayout.EndHorizontal ( );

			GUILayout.BeginVertical ( "Box", GUILayout.ExpandWidth ( true ), GUILayout.ExpandHeight ( true ) );
			switch ( state ) {
				case State.Creatures:
					Creatures ( );
					break;
				case State.Attacks:
					Attacks ( );
					break;
				case State.Skills:
					Skills ( );
					break;
				default:
					About ( );
					break;
			}
			GUILayout.EndVertical ( );

			GUILayout.BeginHorizontal ( "Box", GUILayout.ExpandWidth ( true ) );
			BarBottom ( );
			GUILayout.EndHorizontal ( );
		}

		void ResetAllSelections ( ) {
			_creature = null;
			_attack = null;
			_skill = null;
		}
	}
}
