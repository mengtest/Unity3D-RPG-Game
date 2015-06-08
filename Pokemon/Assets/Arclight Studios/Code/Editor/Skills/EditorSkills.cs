using ArclightStudios.Code.Databases;
using UnityEditor;
using UnityEngine;

namespace ArclightStudios.Code.Editor {
	public partial class EditorRPG {
		private Skill _skill;
		private bool _modifyingSkill;
		private int _skillSelectedIndex;
		private Texture2D _skillTexture;

		private Vector2 _skillListScroll;

		void Skills ( ) {
			GUILayout.BeginHorizontal ( );

				GUILayout.BeginVertical ( "Box", GUILayout.ExpandHeight ( true ), GUILayout.Width ( LIST_SIZE ) );
					if ( Database.skills != null ) {
						DisplaySkillList ( );
					}
				GUILayout.EndVertical ( );

				GUILayout.BeginVertical ( "Box", GUILayout.ExpandHeight ( true ), GUILayout.ExpandWidth ( true ) );
					if ( _skill != null ) {
						DisplaySkillInfo ( );
					} else {
						GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ), GUILayout.ExpandHeight ( true ) );
							GUILayout.Label ( "Select a Skill to view more information" );
						GUILayout.EndVertical ( );

						GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
							if ( GUILayout.Button ( "Add" ) ) {
								_skill = new Skill ( );
							}
						GUILayout.EndVertical ( );

					}
				GUILayout.EndVertical ( );

			GUILayout.EndHorizontal ( );
		}

		private void DisplaySkillList ( ) {
			_skillListScroll = GUILayout.BeginScrollView ( _skillListScroll, GUILayout.ExpandHeight ( true ) );
				DisplaySkills ( );
			GUILayout.EndScrollView ( );
		}

		private void DisplaySkills ( ) {
			for ( int i = 0; i < Database.skills.Count; i++ ) {
				GUILayout.BeginHorizontal ( );
					if ( GUILayout.Button ( Database.skills.Get ( i ).Name ) ) {
						_skill = Database.skills.Get ( i );
						_modifyingSkill = true;
						_skillSelectedIndex = i;
					}

					if ( GUILayout.Button ( trashcan, GUILayout.Width ( BUTTON_SIZE ), GUILayout.Height ( BUTTON_SIZE ) ) ) {
						if ( EditorUtility.DisplayDialog (
							"Delete " + Database.skills.Get ( i ).Name,
							"Are you sure you want to delete" + Database.skills.Get ( i ).Name + " from the database?",
							"Delete", "Cancel" )
						) {
							Database.skills.RemoveAt ( i );
							_skill = null;
						}
					}
				GUILayout.EndHorizontal ( );
			}
		}

		private void DisplaySkillInfo ( ) {
			GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ), GUILayout.ExpandHeight ( true ) );
				GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );

					if ( _skill.Icon ) {
						_skillTexture = _skill.Icon.texture;
					} else {
						_skillTexture = null;
					}

					if ( GUILayout.Button ( _skillTexture, GUILayout.Width ( SPRITE_SIZE ), GUILayout.Height ( SPRITE_SIZE ) ) ) {
						int controlID = GUIUtility.GetControlID ( FocusType.Passive );
						EditorGUIUtility.ShowObjectPicker < Sprite > ( null, false, null, controlID );
					}

					if ( Event.current.commandName == "ObjectSelectorUpdated" ) {
						_skill.Icon = EditorGUIUtility.GetObjectPickerObject ( ) as Sprite;
						Repaint ( );
					}

					GUILayout.BeginVertical ( GUILayout.ExpandWidth ( true ) );
						GUILayout.Label ( "Name:" );
						_skill.Name = EditorGUILayout.TextField ( "", _skill.Name );
					GUILayout.EndVertical ( );

				GUILayout.EndHorizontal ( );
			GUILayout.EndHorizontal ( );

			GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
				if ( GUILayout.Button ( "Save" ) ) {
					if ( _modifyingSkill ) {
						Database.skills.Replace ( _skillSelectedIndex, _skill );
					} else {
						Database.skills.Add ( _skill );
					}

					_skill = null;
					_modifyingSkill = false;
				}

				if ( !_modifyingSkill ) {
					if ( GUILayout.Button ( "Cancel" ) ) {
						_skill = null;
					}
				}
			GUILayout.EndHorizontal ( );
		}
	}
}

