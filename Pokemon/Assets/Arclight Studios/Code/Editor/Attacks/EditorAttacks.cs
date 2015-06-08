using ArclightStudios.Code.Databases;
using UnityEditor;
using UnityEngine;

namespace ArclightStudios.Code.Editor {
	public partial class EditorRPG {
		private Attack _attack;
		private bool _modifyingAttack;
		private int _attackSelectedIndex;
		private Texture2D _attackTexture;

		private Vector2 _attackListScroll;

		void Attacks ( ) {
			GUILayout.BeginHorizontal ( );

				GUILayout.BeginVertical ( "Box", GUILayout.ExpandHeight ( true ), GUILayout.Width ( LIST_SIZE ) );
					if ( Database.attacks != null ) {
						DisplayAttackList ( );
					}
				GUILayout.EndVertical ( );

				GUILayout.BeginVertical ( "Box", GUILayout.ExpandHeight ( true ), GUILayout.ExpandWidth ( true ) );
					if ( _attack != null ) {
						DisplayAttackInfo ( );
					} else {
						GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ), GUILayout.ExpandHeight ( true ) );
							GUILayout.Label ( "Select an Attack to view more information" );
						GUILayout.EndHorizontal ( );

						GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
							if ( GUILayout.Button ( "Add" ) ) {
								_attack = new Attack ( );
							}
						GUILayout.EndHorizontal ( );
					}
				GUILayout.EndVertical ( );

			GUILayout.EndHorizontal ( );
		}

		private void DisplayAttackList ( ) {
			_attackListScroll = GUILayout.BeginScrollView ( _attackListScroll, GUILayout.ExpandHeight ( true ) );
				DisplayAttacks ( );
			GUILayout.EndScrollView ( );
		}

		private void DisplayAttacks ( ) {
			for ( int i = 0; i < Database.attacks.Count; i++ ) {
				GUILayout.BeginHorizontal ( );
					if ( GUILayout.Button ( Database.attacks.Get ( i ).Name ) ) {
						_attack = Database.attacks.Get ( i );
						_modifyingAttack = true;
						_attackSelectedIndex = i;
					}

					if ( GUILayout.Button ( "x", GUILayout.Width ( BUTTON_SIZE ), GUILayout.Height ( BUTTON_SIZE ) ) ) {
						if ( EditorUtility.DisplayDialog (
							"Delete " + Database.attacks.Get ( i ).Name,
							"Are you sure you want to delete " + Database.attacks.Get ( i ).Name + " from the database?",
							"Delete", "Cancel" )
						) {
							Database.attacks.RemoveAt ( i );
							_attack = null;
						}
					}
				GUILayout.EndHorizontal ( );
			}
		}

		private void DisplayAttackInfo ( ) {
			GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ), GUILayout.ExpandHeight ( true ) );
				GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) ) ;

					if ( _attack.Icon ) {
						_attackTexture = _attack.Icon.texture;
					} else {
						_attackTexture = null;
					}

					if ( GUILayout.Button ( _attackTexture, GUILayout.Width ( SPRITE_SIZE ), GUILayout.Height ( SPRITE_SIZE ) ) ) {
						int controlID = GUIUtility.GetControlID ( FocusType.Passive );
						EditorGUIUtility.ShowObjectPicker < Sprite > ( null, false, null, controlID );
					}

					if ( Event.current.commandName == "ObjectSelectorUpdated" ) {
						_attack.Icon = EditorGUIUtility.GetObjectPickerObject ( ) as Sprite;
						Repaint ( );
					}

					GUILayout.BeginVertical ( GUILayout.ExpandWidth ( true ) );
						GUILayout.Label ( "Name:" );
						_attack.Name = EditorGUILayout.TextField ( "", _attack.Name );
					GUILayout.EndVertical ( );

				GUILayout.EndHorizontal ( );
			GUILayout.EndHorizontal ( );

			GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
				if ( GUILayout.Button ( "Save" ) ) {
					if ( _modifyingAttack ) {
						Database.attacks.Replace ( _attackSelectedIndex, _attack );
					} else {
						Database.attacks.Add ( _attack );
					}
					
					_attack = null;
					_modifyingAttack = false;
				}

				if ( !_modifyingAttack ) {
					if ( GUILayout.Button ( "Cancel" ) ) {
						_attack = null;
					}
				}
			GUILayout.EndHorizontal ( );
		}
	}
}

