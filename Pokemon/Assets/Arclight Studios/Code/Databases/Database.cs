namespace ArclightStudios.Code.Databases {
	public static class Database {
		private static string DATABASE_FOLDER_NAME = @"Arclight Studios/Databases";

		public static DatabaseCreature creatures = DatabaseCreature.GetDatabase < DatabaseCreature > ( DATABASE_FOLDER_NAME, "arcCreatures" );
	}
}