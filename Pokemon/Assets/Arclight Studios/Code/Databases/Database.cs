namespace ArclightStudios.Code.Databases {
	public static class Database {
		private static string DATABASE_FOLDER_NAME = @"Arclight Studios/Databases";

		public static DatabaseCreature creatures;
		public static DatabaseAttack attacks;
		public static DatabaseSkill skills;

		public static void Create ( bool forceFileCreation = false ) {
			creatures = DatabaseCreature.GetDatabase < DatabaseCreature > ( DATABASE_FOLDER_NAME, "arcCreatures", forceFileCreation );
			attacks = DatabaseAttack.GetDatabase < DatabaseAttack > ( DATABASE_FOLDER_NAME, "arcAttacks", forceFileCreation );
			skills = DatabaseSkill.GetDatabase < DatabaseSkill > ( DATABASE_FOLDER_NAME, "arcSkills", forceFileCreation );
		}
	}
}