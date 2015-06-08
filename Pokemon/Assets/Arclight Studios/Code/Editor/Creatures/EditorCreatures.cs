using ArclightStudios.Code.Databases;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ArclightStudios.Code.Editor {
	public partial class EditorRPG {
		private Creature _creature;
		private bool _modifyingCreature;
		private int _creatureSelectedIndex;
		private Texture2D _creatureTexture;

		private List < int > _attackSelectedIndexes = new List < int > ( );
		private List < int > _skillSelectedIndexes = new List < int > ( );

		private Vector2 _creatureListScroll, _displayScrollPos;

		void Creatures ( ) {
			GUILayout.BeginHorizontal ( );
				GUILayout.BeginVertical ( "Box", GUILayout.ExpandHeight ( true ), GUILayout.Width ( LIST_SIZE ) );

					if ( Database.creatures != null ) {
						DisplayCreatureList ( );
					}

				GUILayout.EndVertical ( );

				GUILayout.BeginVertical ( "Box", GUILayout.ExpandHeight ( true ) );

					if ( _creature != null ) {
						DisplayCreatureInfo ( );
					} else {
						GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ), GUILayout.ExpandHeight ( true ) );
							GUILayout.Label ( "Select a Creature to view more information" );
						GUILayout.EndHorizontal ( );
						
						GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
							if ( GUILayout.Button ( "Add" ) ) {
								_creature = new Creature ( );
							}
						GUILayout.EndHorizontal ( );
					}	

				GUILayout.EndVertical ( );
			GUILayout.EndHorizontal ( );
		}

		private void DisplayCreatureList ( ) {
			_creatureListScroll = GUILayout.BeginScrollView ( _creatureListScroll, GUILayout.ExpandHeight ( true ) );
				DisplayCreatures ( );
			GUILayout.EndScrollView ( );
		}

		private void DisplayCreatures ( ) {
			for ( int i = 0; i < Database.creatures.Count; i++ ) {
				GUILayout.BeginHorizontal ( );
					if ( GUILayout.Button ( Database.creatures.Get ( i ).Name ) ) {
						_creature = Database.creatures.Get ( i );
						_modifyingCreature = true;
						_creatureSelectedIndex = i;
					}

					if ( GUILayout.Button ( "x", GUILayout.Width ( BUTTON_SIZE ), GUILayout.Height ( BUTTON_SIZE ) ) ) {
						if ( EditorUtility.DisplayDialog (
							"Delete " + Database.creatures.Get ( i ).Name,
							"Are you sure you want to delete " + Database.creatures.Get ( i ).Name + " from the database?",
							"Delete", "Cancel" )
						) {
							Database.creatures.RemoveAt ( i );
							_creature = null;
						}
					}
				GUILayout.EndHorizontal ( );
			}
		}

		private void DisplayCreatureInfo ( ) {
			GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ), GUILayout.ExpandHeight ( true ) );
				_displayScrollPos = GUILayout.BeginScrollView ( _displayScrollPos, GUILayout.ExpandHeight ( true ) );
					
					GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) ) ;

						if ( _creature.Icon ) {
							_creatureTexture = _creature.Icon.texture;
						} else {
							_creatureTexture = null;
						}

						if ( GUILayout.Button ( _creatureTexture, GUILayout.Width ( SPRITE_SIZE ), GUILayout.Height ( SPRITE_SIZE ) ) ) {
							int controlID = GUIUtility.GetControlID ( FocusType.Passive );
							EditorGUIUtility.ShowObjectPicker < Sprite > ( null, false, null, controlID );
						}

						if ( Event.current.commandName == "ObjectSelectorUpdated" ) {
							_creature.Icon = EditorGUIUtility.GetObjectPickerObject ( ) as Sprite;
							Repaint ( );
						}

						GUILayout.BeginVertical ( GUILayout.ExpandWidth ( true ) );
							GUILayout.Label ( "Name:" );
							_creature.Name = EditorGUILayout.TextField ( "", _creature.Name );
						GUILayout.EndVertical ( );

					GUILayout.EndHorizontal ( );
				
					GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
						GUILayout.Label ( "Attacks [" + _creature.Attacks.Count + "]" );
						
						if ( GUILayout.Button ( "+", GUILayout.Width ( BUTTON_SIZE ), GUILayout.Height ( BUTTON_SIZE ) ) ) {
							if ( _creature.Attacks.Count < Database.attacks.Count ) {
								_creature.Attacks.Add ( new Attack ( ) );
								_attackSelectedIndexes.Add ( 0 );
							} else {
								EditorUtility.DisplayDialog (
									"Not Enough Attacks",
									"You cannot add any further attacks to " + _creature.Name + " since there are not enough in the Attack Database",
									"OK"
								);
							}
						}
					GUILayout.EndHorizontal ( );

					ShowAttackList ( );

					GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
						GUILayout.Label ( "Skills [" + _creature.Skills.Count + "]" );
						
						if ( GUILayout.Button ( "+", GUILayout.Width ( BUTTON_SIZE ), GUILayout.Height ( BUTTON_SIZE ) ) ) {
							if ( _creature.Skills.Count < Database.skills.Count ) {
								_creature.Skills.Add ( new Skill ( ) );
								_skillSelectedIndexes.Add ( 0 );
							} else {
								EditorUtility.DisplayDialog (
									"Not Enough Skills",
									"You cannot add any further skills to " + _creature.Name + " since there are not enough in the Skill Database",
									"OK"
								);
							}
						}
					GUILayout.EndHorizontal ( );

					ShowSkillList ( );

				GUILayout.EndScrollView ( );
			GUILayout.EndHorizontal ( );

			GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
				if ( GUILayout.Button ( "Save" ) ) {
					if ( _modifyingCreature ) {
						Database.creatures.Replace ( _creatureSelectedIndex, _creature );
					} else {
						Database.creatures.Add ( _creature );
					}
					
					_creature = null;
					_modifyingCreature = false;
				}

				if ( !_modifyingCreature ) {
					if ( GUILayout.Button ( "Cancel" ) ) {
						_creature = null;
					}
				}
			GUILayout.EndHorizontal ( );
		}

		private void ShowAttackList ( ) {
			if ( _creature.Attacks != null && _creature.Attacks.Count <= Database.attacks.Count ) {
				if ( _attackSelectedIndexes.Count != _creature.Attacks.Count ) {
					for ( int i = 0; i < _creature.Attacks.Count; i++ ) {
						_attackSelectedIndexes.Insert ( i, Database.attacks.IndexOf ( _creature.Attacks [ i ] ) );
					}
				}

				for ( int i = 0; i < _creature.Attacks.Count; i++ ) {
					string [ ] options = new string [ Database.attacks.Count ];

					for ( int opt = 0; opt < options.Length; opt++ ) {
						options [ opt ] = Database.attacks.Get ( opt ).Name;
					}

					GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
						_attackSelectedIndexes [ i ] = EditorGUILayout.Popup ( "", _attackSelectedIndexes [ i ], options );
						_creature.Attacks [ i ] = Database.attacks.Get ( _attackSelectedIndexes [ i ] );

						if ( GUILayout.Button ( "x", GUILayout.Width ( BUTTON_SIZE ), GUILayout.Height ( BUTTON_SIZE ) ) ) {
							_creature.Attacks.RemoveAt ( i );
						}
					GUILayout.EndHorizontal ( );
				}
			}
		}

		private void ShowSkillList ( ) {
			if ( _skillSelectedIndexes.Count != _creature.Skills.Count ) {
				for ( int i = 0; i < _creature.Skills.Count; i++ ) {
					_skillSelectedIndexes.Insert ( i, Database.skills.IndexOf ( _creature.Skills [ i ] ) );
				}
			}

			if ( _creature.Skills != null && _creature.Skills.Count <= Database.skills.Count ) {
				for ( int i = 0; i < _creature.Skills.Count; i++ ) {
					string [ ] options = new string [ Database.skills.Count ];

					for ( int opt = 0; opt < options.Length; opt++ ) {
						options [ opt ] = Database.skills.Get ( i ).Name;
					}

					GUILayout.BeginHorizontal ( GUILayout.ExpandWidth ( true ) );
						_skillSelectedIndexes [ i ] = EditorGUILayout.Popup ( "", _skillSelectedIndexes [ i ], options );
						_creature.Skills [ i ] = Database.skills.Get ( _skillSelectedIndexes [ i ] );

						if ( GUILayout.Button ( "x", GUILayout.Width ( BUTTON_SIZE ), GUILayout.Height ( BUTTON_SIZE ) ) ) {
							_creature.Skills.RemoveAt ( i );
						}
					GUILayout.EndHorizontal ( );
				}
			}
		}
	}
}
