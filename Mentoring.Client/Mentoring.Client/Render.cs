using Mentoring.Client.Abstract;
using Mentoring.Client.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mentoring.Client
{
    internal class Render
    {
        private readonly IRepository _repository;

        public Render(IRepository Repository)
        {
            _repository = Repository;
        }

        public async Task Run()
        {
            PrintMenu();
            int input;
            do
            {
                int.TryParse(Console.ReadLine(), out input);
                switch (input)
                {
                    case (int)Menu.UpdateUniversity:
                        PrintMenu();
                        break;
                    case (int)Menu.AllUniversity:
                        PrintMenu();
                        await ShowUniversity();
                        break;
                    default:
                        PrintMenu();
                        break;
                }
            }
            while (true);
        }

        private async Task ShowUniversity()
        {
            PrintMenu();
            var allUniversities = await _repository.GetUniversityAsync();
            foreach (var item in allUniversities)
            {
                Console.WriteLine($"\t{item.Name}");
            }
            //allUniversities.Select(u => Console.WriteLine($"{u.Name} | {u.ShortName} "));
        }

        void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine($"{Menu.UpdateUniversity.GetDescription()} [{(int)Menu.UpdateUniversity}] | {Menu.AllUniversity.GetDescription()} [{(int)Menu.AllUniversity}]");
            Console.WriteLine();
        }
    }
}