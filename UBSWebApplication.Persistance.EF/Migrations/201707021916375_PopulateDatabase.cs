using System.Data.Entity.Migrations;

namespace UBSWebApplication.Persistance.EF.Migrations
{
    public partial class PopulateDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Eloy','Rubio','41 Denise Dr, Bilston','WV14','England','United Kingdom',1)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Ruben','Rubio','Gate St, Guildford','GU5','England','United Kingdom',2)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Ernesto','Rubio','8 Highbury Grove, Highbury East','N4','England','United Kingdom',3)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Luis','Sanz','2131 Spencer Rd, Lancing','BN15','England','United Kingdom',4)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Raul','Rueda','60 Holly Rd, Uttoxeter ST14','7DR','England','United Kingdom',5)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Tomas','Perez','60 Bank St, Paisley', 'PA1','England','United Kingdom',6)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Héctor','Garcia','Vallings Pl, Long Ditton, Surbiton','KT6','England','United Kingdom',7)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Elia','De Santis','Guy Gibson Court, 23 Gibson Dr, Kings Hill,','ME19','England','United Kingdom',8)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Barry','Lisaght','6 Little St Mary, Long Melford, Sudbury','9LQ','England','United Kingdom',9)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('James','Johnson','7 Tower Rd, Poole','BH13','England','United Kingdom',10)");
            Sql("INSERT INTO Contacts(FirstName, LastName, Street, Zip, Country, City, ImageId) VALUES ('Simon','Dean','26 Honeysuckle Dr, Dereham','BH11','England','United Kingdom',11)");
        }
        
        public override void Down()
        {
        }
    }
}
