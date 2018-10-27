using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDBCA
{
    public class MongoRemove
    {

        public void RemoveFighter(string fighter_id)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("cars");
            var collection = database.GetCollection<FighterProfile>("cars");

            if (fighter_id != null)
            {
                try
                {
                    var result = collection.DeleteOne(a => a._id == fighter_id);
                    MessageBox.Show("Fighter Successfuly Removes From Database!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Check the connection to databse is active!");

                }
            }
            else
            {
                MessageBox.Show("No matching records found to removes!");
            }



        }
    }
}
