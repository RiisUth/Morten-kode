using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBlayerrr
{
    public class CityDB
    {
        fandomDBDataContext db = new fandomDBDataContext();
        public void InsertCity(City city)
        {
            var c = city;
            db.Cities.InsertOnSubmit(c);
            db.SubmitChanges();
        }


    }
}
