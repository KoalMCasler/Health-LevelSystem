/*

Project by Koal Casler
14/10/23

*/
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPSystem
{
    internal class Program
    {
        static int health;
        static string healthStatus;
        static int shield;
        static int lives;
        static int level;
        static int xp;
        static string StarLine;
        static int xpCostBase;
        static int xpCost;

        static void Main()
        {
            xpCostBase = 100;
            UnitTestHealthSystem();
            UnitTestXPSystem();
            Console.WriteLine("Code test complete!");
            Console.ReadKey();
            StartUp();
            ShowHUD();
            Next();
            TakeDamage(50);
            Revive();
            IncreaseXP(110);
            ShowHUD();
            Next();
            TakeDamage(-10);
            Revive();
            IncreaseXP(-110);
            ShowHUD();
            Next();
            TakeDamage(100);
            Revive();
            IncreaseXP(210);
            ShowHUD();
            Next();
            ShowHUD();
            Next();
            Heal(50);
            RegenerateShield(50);
            ShowHUD();
            Next();
            Heal(-10);
            RegenerateShield(-10);
            ShowHUD();
            Next();
            TakeDamage(100); 
            Revive();
            ShowHUD();
            Next();
            TakeDamage(300);
            Revive();
            ShowHUD();
            Next();
            TakeDamage(175);
            Revive();
            ShowHUD();
            Next();
            TakeDamage(175);
            Revive();
            ShowHUD();
            Next();
            TakeDamage(175);
            Revive();
            ShowHUD();
            Next();
            TakeDamage(175);
            Revive();
            ShowHUD();
            Next();
        }
        static void StartUp()
        {
            //Sets base Values
            xp = 0;
            level = 1;
            health = 100;
            shield = 100;
            lives = 3;
            StarLine = "*******************************************";
        }
        static void ShowHUD()
        {
            //Displays HUD in Console
            HealthString();
            Console.WriteLine(StarLine);
            Console.WriteLine(string.Format("Your health is at {0}%", health));
            Console.WriteLine(string.Format("Your heath status is: {0}", healthStatus));
            Console.WriteLine(string.Format("Your shield is at {0}%", shield));
            Console.WriteLine(string.Format("You have {0} lives remaining.", lives));
            Console.WriteLine(string.Format("You are level {0}!", level));
            Console.WriteLine(string.Format("Your xp: {0}", xp));
            Console.WriteLine(StarLine);
        }
        static void Next()
        {
            // Sets up the next test
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void TakeDamage(int damage)
        {
            // Does damage with shield overflow
            if (damage <= 0)
            {
                Console.WriteLine("Damage Cannot Be 0 or less.");
                ShowHUD();
                return;
            }
            if (damage > 0)
            {
                Console.WriteLine(string.Format("You took {0} Damage!", damage));
                if(shield > 0)
                {
                    shield -= damage;
                    if(shield < 0)
                    {
                        health += shield;
                        shield = 0;
                    }
                }
                else
                {
                    health -= damage;
                }
                if(health <= 0)
                {
                    health = 0;
                    ShowHUD();
                }
                ShowHUD();
            }
        }
        static void Heal(int HpGain)
        {
            // Heals the player
            if(HpGain <= 0)
            {
                Console.WriteLine("You cannot heal 0 or a Negative.");
                return;
            }
            health += HpGain;
            Console.WriteLine(string.Format("You gained {0} Hp!", HpGain));
            if(health > 100)
            {
                health = 100;
            }
        }
        static void RegenerateShield(int ShieldGain)
        {
            // Regenerates shield for player
            if(ShieldGain <= 0)
            {
                Console.WriteLine("You cannot regen 0 or a Negative.");
                return;
            }
            shield += ShieldGain;
            Console.WriteLine(string.Format("You Regained {0} shield!", ShieldGain));
            if(shield > 100)
            {
                shield = 100;
            }
        }
        static void Revive()
        {
            if(health == 0)
            {
                // Revives player
                health = 100;
                shield = 100;
                lives -= 1;
                Console.WriteLine("You have been revived!");
            }
            if(lives <= 0)
            {
                Console.WriteLine("You have lost, press any key to exit.");
                health = 0;
                shield = 0;
                ShowHUD();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        static void IncreaseXP(int EXPGain)
        {
            
            // Increases xp and level 
            if(EXPGain <= 0)
            {
                Console.WriteLine("You cannot lose xp...");
                return;
            }
            xp += EXPGain;
            Console.WriteLine(string.Format("You gained {0} xp!", EXPGain));
            xpCost = xpCostBase * level;
            if(xp >= xpCost)
            {
                level += 1;
                Console.WriteLine("You gained a level!");
                xp -= xpCost;
                xpCost += xpCost;
            }
        } 
        static void HealthString()
        {
            // Sets health status string
            if(health == 100)
            {
                healthStatus = "Perfect!";
            }
            if(health < 100 && health >= 75)
            {
                healthStatus = "Healthy";
            }
            if(health < 75 && health >= 50)
            {
                healthStatus = "Hurt";
            }
            if(health < 50 && health >= 25)
            {
                healthStatus = "Badly Hurt";
            }
            if(health < 25 && health >= 1)
            {
                healthStatus = "Critical!";
            }
            if(health <= 0)
            {
                healthStatus = "Dead!";
            }
        }
        static void UnitTestHealthSystem()
        {
            Debug.WriteLine("Unit testing health System started...");

            // TakeDamage()

            // TakeDamage() - only shield
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield and health
            shield = 10;
            health = 100;
            lives = 3;
            TakeDamage(50);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 60);
            Debug.Assert(lives == 3);

            // TakeDamage() - only health
            shield = 0;
            health = 50;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 40);
            Debug.Assert(lives == 3);

            // TakeDamage() - health and lives
            shield = 0;
            health = 10;
            lives = 3;
            TakeDamage(25);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield, health, and lives
            shield = 5;
            health = 100;
            lives = 3;
            TakeDamage(110);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            TakeDamage(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Heal()
            
            // Heal() - normal
            shield = 0;
            health = 90;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 95);
            Debug.Assert(lives == 3);

            // Heal() - already max health
            shield = 90;
            health = 100;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);
            
            // Heal() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Heal(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // RegenerateShield()

            // RegenerateShield() - normal
            shield = 50;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - already max shield
            shield = 100;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            RegenerateShield(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Revive()

            // Revive()
            shield = 0;
            health = 0;
            lives = 2;
            Revive();
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 1);

            Debug.WriteLine("Unit testing health System completed.");
            Console.Clear();
        }
        static void UnitTestXPSystem()
        {
            Debug.WriteLine("Unit testing XP / level Up System started...");

            // IncreaseXP()

            // IncreaseXP() - no level up; remain at level 1
            xp = 0;
            level = 1;
            IncreaseXP(10);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 1);

            // IncreaseXP() - level up to level 2 (costs 100 xp)
            xp = 0;
            level = 1;
            IncreaseXP(105);
            Debug.Assert(xp == 5);
            Debug.Assert(level == 2);

            // IncreaseXP() - level up to level 3 (costs 200 xp)
            xp = 0;
            level = 2;
            IncreaseXP(210);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 3);

            // IncreaseXP() - level up to level 4 (costs 300 xp)
            xp = 0;
            level = 3;
            IncreaseXP(315);
            Debug.Assert(xp == 15);
            Debug.Assert(level == 4);

            // IncreaseXP() - level up to level 5 (costs 400 xp)
            xp = 0;
            level = 4;
            IncreaseXP(499);
            Debug.Assert(xp == 99);
            Debug.Assert(level == 5);

            Debug.WriteLine("Unit testing XP / level Up System completed.");
            Console.Clear();
        }
    }
}
