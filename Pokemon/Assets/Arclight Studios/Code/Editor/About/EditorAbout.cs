using UnityEngine;

namespace ArclightStudios.Code.Editor {
	public partial class EditorRPG {
		private Vector2 _aboutListScroll;

		void About ( ) {
			GUIStyle style = new GUIStyle ( );
			style.wordWrap = true;

			_aboutListScroll = GUILayout.BeginScrollView ( _aboutListScroll );

			GUILayout.Label ( "'RPG Editor System' was designed, built and programmed by Tom Wright of Arclight Studios. ", style );
			GUILayout.Label ( "" );
			GUILayout.Label ( "Original code partially provided by BurgZergArcade (videos available at www.youtube.com/user/BurgZergArcade).", style );
			GUILayout.Label ( "" );

			GUILayout.EndScrollView ( );
		}
	}
}

