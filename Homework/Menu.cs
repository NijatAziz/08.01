using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Menu
    {
        private Course course = new Course();

        public void Run()
        {
            int choise;
            do
            {
               
                Console.WriteLine("Menu");
                Console.WriteLine("1. Qrup elave et");
                Console.WriteLine("2. Butun qruplara bax");
                Console.WriteLine("3. Verilmish point araligindaki qruplara bax");
                Console.WriteLine("4. Verilmish nomreli qrupa bax");
                Console.WriteLine("0. Menudan cix");

                if (int.TryParse(Console.ReadLine(), out choise))
                {
                    switch (choise)
                    {
                        case 1:
                            Console.Clear();
                            AddGroup();
                            break;
                        case 2:
                            Console.Clear();

                            Allgroup();
                            break;
                        case 3:
                            Console.Clear();

                            ViewGroupsByPointRange();
                            break;
                        case 4:
                            Console.Clear();

                            ViewGroupByNo();
                            break;
                        case 0:
                            Console.Clear();

                            Console.WriteLine("Menudan cixilir...");
                            break;
                        default:
                            Console.WriteLine("Yanlis secim etdiniz. Zehmet olmasa duzgun secim edin");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Yanlis secim etdiniz. Zehmet olmasa duzgun secim edin");
                }


            } while (choise != 0);
        }



        private void AddGroup()
        {
            Console.WriteLine("Qrupun nomresini daxil edin");
            string no = Console.ReadLine();
            Console.WriteLine("Qrupun ortalama balini daxil edin");
            if (double.TryParse(Console.ReadLine(), out double point))
            {
                Group newgroup = new Group { GroupNo = no, Point = point };
                course.AddGroup(newgroup);
                Console.WriteLine("Qrup elave edildi");

            }
            else
            {
                Console.WriteLine("DUzgun ortala bal daxil edin");
            }
        }


        public void Allgroup()
        {
            Console.WriteLine("Butun qruplar:");

            foreach (Group group in course.groups)
            {
                Console.WriteLine($"Qrup nomresi:{group.GroupNo} , Ortalama bal : {group.Point}");
            }
        }

        private void ViewGroupsByPointRange()
        {
            Console.WriteLine("Minimum pointı daxil edin:");
            if (double.TryParse(Console.ReadLine(), out double minPoint))
            {
                Console.WriteLine("Maksimum pointı daxil edin:");
                if (double.TryParse(Console.ReadLine(), out double maxPoint))
                {
                    Group[] groupsInRange = course.GetGroupsByPoint(minPoint, maxPoint);
                    if (groupsInRange.Length > 0)
                    {
                        Console.WriteLine($"Araliqda olan qruplar:");
                        foreach (var group in groupsInRange)
                        {
                            Console.WriteLine($"Qrup nomresi: {group.GroupNo}, Ortalama bal: {group.Point}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Verilmis araliqda qrup tapilmadi!");
                    }
                }
                else
                {
                    Console.WriteLine("Duzgun maksimum point daxil edin!");
                }
            }
            else
            {
                Console.WriteLine("Duzgun minimum point daxil edin!");
            }
        }

        private void ViewGroupByNo()
        {
            Console.WriteLine("Qrup nömresini daxil edin:");
            string no = Console.ReadLine();

            Group group = course.GetGroupByNo(no);
            if (group != null)
            {
                Console.WriteLine($"Qrup nomresi: {group.GroupNo}, Ortalama bal: {group.Point}");
            }
            else
            {
                Console.WriteLine($"Verilmis nomreli qrup tapilmadi!");
            }
        }
    }
}
