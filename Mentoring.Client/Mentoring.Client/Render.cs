﻿using Mentoring.Client.Abstract;
using Mentoring.Client.Helpers;
using Mentoring.Client.Models;
using Mentoring.Client.UI_Moduls.Controls;
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
                    case 5:
                        await Test();
                        break;
                    default:
                        PrintMenu();
                        break;
                }
            }
            while (true);
        }

        private async Task Test()
        {
            string[] options = { "first option", "second option", "third option", "fourth option", "fifth option" };

            ////////////////////////////////////////////////////////////
            //// EXAMPLE: SELECT MAX ONE OPTION; SELECTION REQUIRED ////
            ////////////////////////////////////////////////////////////

            // class init            
            var c1 = new Checkbox("Select one of the following options", true, true, options);
            var res1 = c1.Select();
            Console.WriteLine(res1);
        }

        private async Task ShowAnket()  //TODO: Як правильно побудувати архітектуру цього рендера 
        {
            PrintMenu();
            Console.WriteLine($"\tАНКЕТА");
            Console.WriteLine($"\t------------");
            var dto = new ApplicationModel();

            dto.FirstName = PrintStringField("Ім'я");
            dto.SecondName = PrintStringField("Прізвище");
            dto.PhoneNumber = PrintNumberField("Мобільний номер телефону");
            dto.AverageMark = PrintNumberField("Середній бал ЗНО");

            dto.Regions = PrintCheckBoxField("Бажаний регіон навчання [натисніть Enter та виберіть варіанти]", await _repository.GetRegionNamesAsync())
                .Select(op => new RegionModel { Name = op.Option }).ToList();
            PrintAnketaCache(dto, nameof(dto.Regions));

            dto.ProfessionalDirections = PrintCheckBoxField("Очікуваний професійний напрямок [натисніть Enter та виберіть варіанти]", await _repository.GetProfessionalDirectionNamesAsync())
                .Select(op => new ProfessionalDirectionModel { Name = op.Option }).ToList();
            PrintAnketaCache(dto, nameof(dto.ProfessionalDirections));

            Console.WriteLine($"\t------------");
            Console.WriteLine($"\tВідправити анкету[1] | Очистити анкету[2] | Головне меню[Enter]");
            Console.Write("\t");
            var inputConsent = Console.ReadLine();
            Int32.TryParse(inputConsent, out int consent);
            if (consent == 2)
            {
                await ShowAnket();
                return;
            }
            if (consent != 1)
                return;

            try
            {
                await _repository.CreateApplication(dto);
                Console.WriteLine($"\t------------");
                Console.WriteLine($"\tАнкета прийнята!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private CheckboxReturn[] PrintCheckBoxField(string fieldName, string[] options)
        {
            Console.Write($"\t{fieldName}: ");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { };
            var checkBoxForRegions = new Checkbox("Виберіть варіанти", true, true, options); //TODO: Як тестувати?
            var selectedRegions = checkBoxForRegions.Select();
            return selectedRegions;
        }

        private static int PrintNumberField(string fieldName)
        {
            Console.Write($"\t{fieldName}: ");
            var input = Console.ReadLine();
            Int32.TryParse(input, out int value);
            return value;
        }

        private static string PrintStringField(string fieldName)
        {
            Console.Write($"\t{fieldName}: ");
            return Console.ReadLine();
        }

        private void PrintAnketaCache(ApplicationModel dto, string propName)
        {
            PrintMenu();
            Console.WriteLine($"\tАНКЕТА");
            Console.WriteLine($"\t------------");

            Console.WriteLine($"\tІм'я: {dto.FirstName}");
            if (nameof(dto.FirstName) == propName) { return; }

            Console.WriteLine($"\tПрізвище: {dto.SecondName}");
            if (nameof(dto.SecondName) == propName) { return; }

            Console.WriteLine($"\tМобільний номер телефону: {dto.PhoneNumber}");
            if (nameof(dto.PhoneNumber) == propName) { return; }

            Console.WriteLine($"\tСередній бал ЗНО: {dto.AverageMark}");
            if (nameof(dto.AverageMark) == propName) { return; }

            Console.WriteLine($"\tБажаний регіон навчання: {string.Join(", ", dto.Regions.Select(m => m.Name))}");
            if (nameof(dto.Regions) == propName) { return; }

            Console.WriteLine($"\tОчікуваний професійний напрямок: {string.Join(", ", dto.ProfessionalDirections.Select(m => m.Name))}");
            if (nameof(dto.ProfessionalDirections) == propName) { return; }

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