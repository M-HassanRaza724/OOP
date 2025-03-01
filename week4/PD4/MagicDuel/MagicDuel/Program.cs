using System;
using System.Collections.Generic;
using MagicDuel;

class Program
{
    static void Main(string[] args)
    {
        List<Player> players = new List<Player>(); 
        List<Stats> skills = new List<Stats>();
        int choice;
        do
        {
            choice = Menu();

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Player Name: ");
                    string playerName = Console.ReadLine();
                    Console.Write("Enter Player Health: ");
                    float health = float.Parse(Console.ReadLine());
                    Console.Write("Enter Player Energy: ");
                    float energy = float.Parse(Console.ReadLine());
                    Console.Write("Enter Player Armor: ");
                    float armor = float.Parse(Console.ReadLine());

                    Player newPlayer = new Player(playerName, health, energy, armor);
                    players.Add(newPlayer);
                    Console.WriteLine("Player added successfully!");
                    break;

                case 2: 
                    Console.Write("Enter Skill Name: ");
                    string skillName = Console.ReadLine();
                    Console.Write("Enter Skill Damage: ");
                    float damage = float.Parse(Console.ReadLine());
                    Console.Write("Enter Skill Penetration: ");
                    float penetration = float.Parse(Console.ReadLine());
                    Console.Write("Enter Skill Heal: ");
                    float heal = float.Parse(Console.ReadLine());
                    Console.Write("Enter Skill Cost: ");
                    float cost = float.Parse(Console.ReadLine());
                    Console.Write("Enter Skill Description: ");
                    string description = Console.ReadLine();

                    Stats newSkill = new Stats(skillName, damage, penetration, heal, cost, description);
                    skills.Add(newSkill);
                    Console.WriteLine("Skill added successfully!");
                    break;

                case 3:
                    if (players.Count == 0)
                    {
                        Console.WriteLine("No players available!");
                    }
                    else
                    {
                        Console.WriteLine("\nPlayer Information:");
                        foreach (Player player in players)
                        {
                            Console.WriteLine($"Name: {player.Name}, Health: {player.Hp}/{player.MaxHp}, Energy: {player.Energy}/{player.MaxEnergy}, Armor: {player.Armor}");
                        }
                    }
                    break;

                case 4: 
                    if (players.Count == 0 || skills.Count == 0)
                    {
                        Console.WriteLine("No players or skills available!");
                    }
                    else
                    {
                        Console.Write("Enter Player Name: ");
                        string learnPlayerName = Console.ReadLine();
                        Player learnPlayer = null;

                        foreach (Player player in players)
                        {
                            if (player.Name == learnPlayerName)
                            {
                                learnPlayer = player;
                                break;
                            }
                        }

                        if (learnPlayer == null)
                        {
                            Console.WriteLine("Player not found!");
                        }
                        else
                        {
                            Console.Write("Enter Skill Name: ");
                            string learnSkillName = Console.ReadLine();
                            Stats learnSkill = null;

                            foreach (Stats skill in skills)
                            {
                                if (skill.Name == learnSkillName)
                                {
                                    learnSkill = skill;
                                    break;
                                }
                            }

                            if (learnSkill == null)
                            {
                                Console.WriteLine("Skill not found!");
                            }
                            else
                            {
                                learnPlayer.LearnSkill(learnSkill);
                                Console.WriteLine($"{learnPlayerName} learned {learnSkillName} successfully!");
                            }
                        }
                    }
                    break;

                case 5: 
                    if (players.Count < 2)
                    {
                        Console.WriteLine("Not enough players to attack!");
                    }
                    else
                    {
                        Console.Write("Enter Attacker's Name: ");
                        string attackerName = Console.ReadLine();
                        Player attacker = null;

                        foreach (Player player in players)
                        {
                            if (player.Name == attackerName)
                            {
                                attacker = player;
                                break;
                            }
                        }

                        if (attacker == null)
                        {
                            Console.WriteLine("Attacker not found!");
                        }
                        else
                        {
                            Console.Write("Enter Target's Name: ");
                            string targetName = Console.ReadLine();
                            Player target = null;

                            foreach (Player player in players)
                            {
                                if (player.Name == targetName)
                                {
                                    target = player;
                                    break;
                                }
                            }

                            if (target == null)
                            {
                                Console.WriteLine("Target not found!");
                            }
                            else if (attacker.SkillStatistics == null)
                            {
                                Console.WriteLine($"{attackerName} has no skill to attack!");
                            }
                            else
                            {
                                string result = attacker.Attack(target);
                                Console.WriteLine(result);
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
            Console.Clear();
            choice = Menu();
        } while (choice != 6);
        Console.WriteLine("Exiting the program...");
    }
    static int Menu()
    {
        Console.WriteLine("\nMagical Duel Menu:");
        Console.WriteLine("1. Add Player");
        Console.WriteLine("2. Add Skill Statistics");
        Console.WriteLine("3. Display Player Info");
        Console.WriteLine("4. Learn a Skill");
        Console.WriteLine("5. Attack");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
        return int.Parse(Console.ReadLine());
    }
}