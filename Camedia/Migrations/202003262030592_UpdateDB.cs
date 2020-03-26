namespace Camedia.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class UpdateDB : DbMigration
	{
		public override void Up()
		{
			Sql("ALTER TABLE [dbo].[Movies] DROP CONSTRAINT [FK_dbo.Movies_dbo.Genres_GenreId]");
			Sql("DROP INDEX [IX_GenreId] ON[dbo].[Movies]; ");
			DropPrimaryKey("dbo.Genres");
			AlterColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
			AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
			AddPrimaryKey("dbo.Genres", "Id");
			CreateIndex("dbo.Movies", "GenreId");
			AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
		}
		
		public override void Down()
		{
			DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
			DropIndex("dbo.Movies", new[] { "GenreId" });
			DropPrimaryKey("dbo.Genres");
			AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
			AlterColumn("dbo.Movies", "GenreId", c => c.Int());
			AddPrimaryKey("dbo.Genres", "Id");
			RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_Id");
			AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
			CreateIndex("dbo.Movies", "Genre_Id");
			AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
		}
	}
}
