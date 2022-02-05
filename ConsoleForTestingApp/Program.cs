using DbDataLibrary.Mapper;
using DbDataLibrary.Models;
using DbDataLibrary.Models.Entities;
using System;
using System.Collections.Generic;

namespace ConsoleForTestingApp
{
    internal class Program
    {
        private static void Main()
        {
            using (var OneTrackerContext = new OneTrackerDBContext())
            {
                var newlist = new List<DevTeam>(OneTrackerContext.DevTeam);

                //var connChecker = new ConnectionChecker();
                //bool isError = connChecker.CouldConnect();

                //var container = ContainerConfig.Configure();
                //using (var scope = container.BeginLifetimeScope())
                //{
                //    var service = scope.Resolve<IDbService<Department>>();

                //}

                var mpConfig = new AutoMaperConfig();
                var _Mapper = mpConfig.MyMapperConfig.CreateMapper();
                var devteam = new DevTeam() { TeamName = "Cos", Id = 1, Mail = "Ds3e@se3e.pl" };
                TeamForViewNew team = _Mapper.Map<TeamForViewNew>(devteam);
                foreach (var item in newlist)
                {
                    TeamForViewNew team2 = _Mapper.Map<TeamForViewNew>(item);
                }
            }
            Console.ReadKey();
        }
    }
}