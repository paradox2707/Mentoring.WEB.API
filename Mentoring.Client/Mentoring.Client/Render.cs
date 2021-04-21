using Mentoring.Client.Abstract;
using Mentoring.Client.Helpers;
using System;
using System.Threading.Tasks;

namespace Mentoring.Client
{
    public class Render
    {
        private readonly IRepository _repository;

        public Render(IRepository Repository)
        {
            _repository = Repository;
        }

        public async Task Run()
        {
            PrintMenu();
            do
            {
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case (int)Menu.Universities:
                        await ShowUniversities();
                        break;
                    case (int)Menu.Specialities:
                        await ShowSpecialities();
                        break;
                    case (int)Menu.SpecialitiesWithSpecialities:
                        await ShowUniversitiesWithSpecialities();
                        break;
                    default:
                        PrintMenu();
                        break;
                }
            }
            while (true);
        }

        private async Task ShowUniversities()
        {
            PrintMenu();
            Console.WriteLine($"\tУНІВЕРСИТЕТИ");
            Console.WriteLine($"\t------------");
            var allUniversities = await _repository.GetUniversitiesAsync();
            foreach (var item in allUniversities)
            {
                Console.WriteLine($"\t{item.Name}");
            }
        }

        private async Task ShowSpecialities()
        {
            PrintMenu();
            Console.WriteLine($"\tСПЕЦІАЛЬНОСТІ");
            Console.WriteLine($"\t-------------");
            var allSpecialities = await _repository.GetSpecialitiesAsync();
            foreach (var item in allSpecialities)
            {
                Console.WriteLine($"\t{item.Name}");
            }
        }

        private async Task ShowUniversitiesWithSpecialities()
        {
            PrintMenu();
            Console.WriteLine($"\tУНІВЕРСИТЕТИ");
            Console.WriteLine($"\t\tСПЕЦІАЛЬНОСТІ");
            Console.WriteLine($"\t---------------------");
            var allUniversitiesWithSpecialities = await _repository.GetUniversitiesWithSpecialitiesAsync();
            foreach (var university in allUniversitiesWithSpecialities)
            {
                Console.WriteLine($"\t{university.Name}");
                foreach (var speciality in university.Specialities)
                {
                    Console.WriteLine($"\t\t- {speciality.Name}");
                }
            }
        }

        void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine(  $"{Menu.Universities.GetDescription()} [{(int)Menu.Universities}] " +
                                $"| {Menu.Specialities.GetDescription()} [{(int)Menu.Specialities}] " +
                                $"| {Menu.SpecialitiesWithSpecialities.GetDescription()} [{(int)Menu.SpecialitiesWithSpecialities}]" );
            Console.WriteLine();
        }
    }
}