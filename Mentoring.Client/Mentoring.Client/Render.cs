using Mentoring.Client.Abstract;
using Mentoring.Client.Helpers;
using Mentoring.Client.Models;
using System;
using System.Linq;
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
                    case (int)Menu.Application:
                        await ShowAnket();
                        break;
                    default:
                        PrintMenu();
                        break;
                }
            }
            while (true);
        }

        private async Task ShowAnket()
        {
            PrintMenu();
            Console.WriteLine($"\tАНКЕТА");
            Console.WriteLine($"\t------------");
            Console.Write($"\tСередній бал ЗНО: ");
            var dto = new ApplicationModel();
            var inputAvgMark = Console.ReadLine();
            Int32.TryParse(inputAvgMark, out int avgMark);
            dto.AverageMark = avgMark;
            Console.Write($"\tБажаний регіон навчання: ");
            dto.Regions = Console.ReadLine().Split(",").ToList<string>();

            try
            {
                await _repository.CreateApplication(dto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
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
                                $"| {Menu.SpecialitiesWithSpecialities.GetDescription()} [{(int)Menu.SpecialitiesWithSpecialities}] " +
                                $"| {Menu.Application.GetDescription()} [{(int)Menu.Application}]");
            Console.WriteLine();
        }
    }
}