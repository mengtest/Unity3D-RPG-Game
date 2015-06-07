using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ArclightStudios.Code.Databases {
	public class DatabaseScriptableObject < T > : ScriptableObject where T : class {
		[ SerializeField ]
		List < T > database = new List < T > ( );

		public int Count { get { return database.Count; } }

		public void Add ( T item ) {
			database.Add ( item );
			MarkDirty ( );
		}

		public void Insert ( int index, T item ) {
			database.Insert ( index, item );
			MarkDirty ( );
		}

		public void Replace ( int index, T item ) {
			database [ index ] = item;
			MarkDirty ( );
		}

		public void Remove ( T item ) {
			database.Remove ( item );
			MarkDirty ( );
		}

		public void RemoveAt ( int index ) {
			database.RemoveAt ( index );
			MarkDirty ( );
		}

		public T Get ( int index ) {
			return database.ElementAt ( index );
		}

		private void MarkDirty ( ) {
			EditorUtility.SetDirty ( this );
		}

		public static U GetDatabase < U > ( string databasePath, string databaseName ) where U : ScriptableObject {
			string fullPath = @"Assets/" + databasePath + "/" + databaseName + ".asset";

			U database = AssetDatabase.LoadAssetAtPath ( fullPath, typeof ( U ) ) as U;

			if ( database == null ) {
				if ( !AssetDatabase.IsValidFolder ( @"Assets/" + databasePath ) ) {
					AssetDatabase.CreateFolder ( @"Assets", databasePath );
				}

				database = CreateInstance<U> ( ) as U;

				AssetDatabase.CreateAsset ( database, fullPath );
				AssetDatabase.SaveAssets ( );
				AssetDatabase.Refresh ( );
			}

			return database;
		}
	}
}

