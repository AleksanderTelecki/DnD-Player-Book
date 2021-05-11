using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using DungensAndDragonsGenerator.DataBase.DBClasses;
using System.Configuration;
using System.Data;

namespace DungensAndDragonsGenerator.DataBase
{
    public class SqliteDataAccess
    {
        private static string LoadConnectionString(string id = "DBase")=>ConfigurationManager.ConnectionStrings[id].ConnectionString;



        #region Player

        public Player LoadPlayer()
        {
            throw new NotImplementedException();

        }

        public void SavePlayer()
        {
            throw new NotImplementedException();

        }

        public void ModifyPlayer()
        {
            throw new NotImplementedException();

        }

        #endregion


        #region Class-SubClass

        public List<Class> LoadClasses()
        {
            List<Class> classes = new List<Class>();
            List<SubClass> subclasses = new List<SubClass>();

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Class>("SELECT * FROM Class", new DynamicParameters());
                classes = output.ToList();
            }

            subclasses = LoadSubClasses();

            foreach (var item in classes)
            {
                item.SubClasses = subclasses.Where(x => item.id == x.class_id).ToList();
            }

            return classes;

        }

        private List<SubClass> LoadSubClasses()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SubClass>("SELECT * FROM SubClass", new DynamicParameters());
                return output.ToList();
            }
        }

        #endregion


        #region Race-Subrace

        public List<Race> LoadRaces()
        {
            List<Race> races = new List<Race>();
            List<SubRace> subraces = new List<SubRace>();

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Race>("SELECT * FROM Race", new DynamicParameters());
                races = output.ToList();
            }

            subraces = LoadSubRaces();


            foreach (var item in races)
            {
                item.SubRaces = subraces.Where(x => item.id == x.race_id).ToList();
            }

            return races;
        }




        private List<SubRace> LoadSubRaces()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SubRace>("SELECT * FROM SubRace", new DynamicParameters());
                return output.ToList();
            }

        }


        #endregion


        #region Ability

        public Ability LoadAbility()
        {
            throw new NotImplementedException();

        }

        public void SaveAbility()
        {
            throw new NotImplementedException();

        }

        public void ModifyAbility()
        {
            throw new NotImplementedException();

        }

        #endregion


        #region ClassLevel
        public ClassLevel LoadClassLevel()
        {
            throw new NotImplementedException();

        }

        public void SaveClassLevel()
        {
            throw new NotImplementedException();

        }

        public void ModifyClassLevel()
        {
            throw new NotImplementedException();

        }

        #endregion



        #region Conditions

        public List<Condition> LoadConditions()
        {
            throw new NotImplementedException();

        }

        public void SaveConditions()
        {
            throw new NotImplementedException();

        }

        public void ModifyConditions()
        {
            throw new NotImplementedException();

        }

        #endregion



        #region Equipments
        public List<Equipment> LoadEquipments()
        {
            throw new NotImplementedException();

        }

        public void SaveEquipments()
        {
            throw new NotImplementedException();

        }

        public void ModifyEquipments()
        {
            throw new NotImplementedException();

        }


        #endregion


        #region Skills

        public Skill LoadSkills()
        {
            throw new NotImplementedException();

        }

        public void SaveSkills()
        {
            throw new NotImplementedException();

        }

        public void ModifySkills()
        {
            throw new NotImplementedException();

        }

        #endregion


        #region Spells

        public List<Spell> LoadSpells()
        {
            throw new NotImplementedException();

        }

        public void SaveSpells()
        {
            throw new NotImplementedException();

        }

        public void ModifySpells()
        {
            throw new NotImplementedException();

        }


        #endregion


        #region Weapons

        public List<Weapon> LoadWeapons()
        {
            throw new NotImplementedException();

        }

        public void SaveWeapons()
        {
            throw new NotImplementedException();

        }

        public void ModifyWeapons()
        {
            throw new NotImplementedException();

        }




        #endregion






    }
}
