using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Other
{
    public class SettingsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public static List<SettingsModel> GetSettings()
        {
            return new List<SettingsModel>()
            {
                new SettingsModel(){Id = 1, Name = "Favourite Restaurants", Image = "sett_favourite.png"},
                new SettingsModel(){Id = 2, Name = "My Comments", Image = "sett_comment.png"},
                new SettingsModel(){Id = 3, Name = "My Images", Image = "sett_image.png"},
                new SettingsModel(){Id = 4,  Name = "Delete My Account", Image = "sett_delete.png"}
            };
        }
    }
}
