using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Daily_Menu;

namespace RestMap.Model
{
    public static class DailyMenuService
    {
        private static readonly ZomatoClient _zomatoClient = new ZomatoClient();
        private static readonly  ZomatoService _zomatoService = new ZomatoService(_zomatoClient);

        public static async Task<List<DailyMenuContainer>> GetDailyMenus(string id)
        {
            var dailyMenusContainer = await _zomatoService.GetDailyMenusAsync(id);

            if (dailyMenusContainer != null)
            {
                return dailyMenusContainer.daily_menus;
            }

            return null;
        }
    }
}
