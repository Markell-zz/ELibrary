using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ELibrary.DB
{
	class TablesContext : DbContext
	{
		public TablesContext()
			: base("DbConnection")
		{ }

		public DbSet<Genre>     Genres     { get; set; }
		public DbSet<Exemplar>  Exemplars  { get; set; }
		public DbSet<Book>      Books      { get; set; }
        public DbSet<Student>   Students   { get; set; }
        public DbSet<TakenBook> TakenBooks { get; set; }
    }
}
